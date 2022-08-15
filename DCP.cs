using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using IWshRuntimeLibrary;
using Microsoft.Win32;
using Microsoft.Toolkit.Uwp.Notifications;
using FileTest;

namespace DesktopCleanPlan
{
    public partial class DCP : Form
    {
        #region 一些变量
        private string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private string style = "1";
        private string startup = "0";
        private List<string> res = new List<string>();
        private string configPath = Application.StartupPath + "\\DCPconfig.imxld";
        private List<IPAddress> ips = new List<IPAddress>();
        public static string userid = "";
        public static string passwd = "";
        #endregion

        public DCP()
        {
            InitializeComponent();

            //隐藏标题栏
            this.FormBorderStyle = FormBorderStyle.None;
            //窗体透明
            this.BackColor = Color.FromArgb(0, 0, 1);
            this.TransparencyKey = this.BackColor;
            //不显示在任务栏
            this.ShowInTaskbar = false;

            this.contextMenuStrip1.Padding = new Padding(0, 0, 0, 0);
        }

        //回收站
        [DllImportAttribute("shell32.dll")]          //声明API函数
        private static extern int SHEmptyRecycleBin(IntPtr handle, string root, int falgs);

        //创建桌面和开始菜单快捷方式，暂时弃用
        private bool CrtShortCut(string FilePath, string fileName)
        {
            WshShell shell = new WshShell();

            //创建桌面快捷方式
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + fileName + ".lnk");
            shortcut.TargetPath = FilePath;
            shortcut.WorkingDirectory = Environment.CurrentDirectory;
            shortcut.WindowStyle = 1;
            shortcut.Description = fileName;
            shortcut.Save();

            //创建开始菜单快捷方式
            IWshShortcut shortcut1 = (IWshShortcut)shell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + "\\" + fileName + ".lnk");
            shortcut1.TargetPath = FilePath;
            shortcut1.WorkingDirectory = Environment.CurrentDirectory;
            shortcut1.WindowStyle = 1;
            shortcut1.Description = fileName;
            shortcut1.Save();
            return true;
        }

        //如果不存在DCPconfig.imxld
        private void IMxldEdit()
        {
            if (System.IO.File.Exists(configPath))
            {
                res = IMxldFile.IMxldRead(configPath, "0");
                IMxldFile.IMxldWrite(configPath, "0", folderPath, style, startup, userid, passwd);
            }
            else
            {
                FileStream c = System.IO.File.Create(configPath);
                c.Close();
                IMxldFile.IMxldWrite(configPath, "0", folderPath, style, startup, userid, passwd);
            }
        }

        //无论网络通不通都能获取到Ip，暂时弃用
        public static List<IPAddress> GetByNetworkInterface()
        {
            try
            {
                NetworkInterface[] intf = NetworkInterface.GetAllNetworkInterfaces();
                List<IPAddress> ls = new List<IPAddress>();
                foreach (NetworkInterface item in intf)
                {
                    IPInterfaceProperties adapterPropertis = item.GetIPProperties();
                    UnicastIPAddressInformationCollection coll = adapterPropertis.UnicastAddresses;
                    foreach (UnicastIPAddressInformation col in coll)
                    {
                        ls.Add(col.Address);
                    }
                }
                return ls;
            }
            catch (Exception)
            {
                return new List<IPAddress>();

            }
        }

        //连接校园网
        public static void DrcomConnect(string userid, string passwd)
        {
            //ping校园网ip获得DHCP服务器分发的ip
            System.Net.Sockets.TcpClient tcpClient = new System.Net.Sockets.TcpClient();
            tcpClient.Connect("172.30.255.42", 80);
            string ip = ((IPEndPoint)tcpClient.Client.LocalEndPoint).Address.ToString();
            tcpClient.Close();

            string drcomUrl = "http://172.30.255.42:801/eportal/portal/login?callback=dr1003&login_method=1&user_account=%2C0%2C" + userid + 
                "&user_password=" + passwd +
                "&wlan_user_ip=" + ip;

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(drcomUrl);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string res = reader.ReadToEnd();

            //MessageBox.Show(res);
            //(?<="result":).*?(?=,"msg")
            //c#中正则匹配双引号要用""，\不能转义"
            Regex regex = new Regex(@"""result"":1,""msg""");
            Regex regexplus = new Regex(@"已经在线");
            switch (regex.IsMatch(res))
            {
                case true:
                    new ToastContentBuilder()
                    .AddArgument("action", "viewConversation")
                    .AddArgument("conversationId", 114514)
                    .AddText("校园网连接成功！")
                    .AddText(DateTime.Now.ToString())
                    .Show(toast =>
                    {
                        //被忽略后通知自动消失
                        toast.ExpirationTime = DateTime.Now.AddSeconds(5);
                    });
                    break;
                default:
                    if (regexplus.IsMatch(res))
                    {
                        new ToastContentBuilder()
                        .AddArgument("action", "viewConversation")
                        .AddArgument("conversationId", 414141)
                        .AddText("校园网已经连接！")
                        .AddText(DateTime.Now.ToString())
                        .Show(toast =>
                        {
                            //被忽略后通知自动消失
                            toast.ExpirationTime = DateTime.Now.AddSeconds(5);
                        });
                    }
                    else
                    {
                        new ToastContentBuilder()
                        .AddArgument("action", "viewConversation")
                        .AddArgument("conversationId", 1919810)
                        .AddText("校园网连接失败！有以下四种可能原因：")
                        .AddText("1.账户或密码输入错误；2.该账户已经登录；3.您就没在咱校园里；4.DCP被ban了（小概率事件）。")
                        .AddText(DateTime.Now.ToString())
                        .Show(toast =>
                        {
                            //被忽略后通知自动消失
                            toast.ExpirationTime = DateTime.Now.AddSeconds(5);
                        });
                    }
                    break;
            }
        }

        //分发变量
        private void DistributeData(List<string> res)
        {
            folderPath = res[0];
            style = res[1];
            startup = res[2];
            userid = res[3];
            passwd = res[4];
        }

        //加载时
        private void DCP_Load(object sender, EventArgs e)
        {
            this.DCPNo.Checked = true;
            this.DCPEight.Checked = true;

            if (System.IO.File.Exists(configPath))
            {
                res = IMxldFile.IMxldRead(configPath, "0");
                if (res.Count() != 5)
                {
                    MessageBox.Show("检查到版本更新！配置文件将被重置！");
                    System.IO.File.Delete(configPath);
                    try
                    {
                        DistributeData(res);
                    }
                    catch { }
                    IMxldEdit();
                    res = IMxldFile.IMxldRead(configPath, "0");
                }
                DistributeData(res);
                switch (style)
                {
                    case "0":
                        DCPSimple_Click(null, null);
                        break;
                    case "1":
                        DCPEight_Click(null, null);
                        break;
                }
                switch (startup)
                {
                    case "0":
                        DCPNo_Click(null, null);
                        break;
                    case "1":
                        DCPYes_Click(null, null);
                        break;
                }
            }
            else
            {
                MessageBox.Show("注意!", "注意");
                MessageBox.Show("首次运行请仔细阅读以下说明!", "注意");
                MessageBox.Show("[作者] IMxld: 给你也整一个！\n[作者] IMxld: 【程序】在【系统托盘区】。\n[作者] IMxld: 程序正确运行的前提是\n[作者] IMxld: 你【没有更改】任何系统相关【环境变量】和【注册表信息】！\n[作者] IMxld:该指引只会出现【一次】，除非删除程序同目录下的【DCPconfig.imxld】文件！\n[本体] DCP: 我TM莱纳！\n[系统] DCP +1", "注意");
                MessageBox.Show("[作者] IMxld: 若使用【校园网自动登录】工具，\n[作者] IMxld: 请【务必】保护好自己的【DCPconfig.imxld】文件！\n[作者] IMxld: 【不要】随意外传，避免被不法之徒破解！\n[作者] IMxld: 虽然我对我的文件加密方式还是有些自信的w\n[作者] IMxld: 总之谨慎些是极好的（自己想怎么处理它就怎么处理它）", "注意");

                //CrtShortCut(Application.ExecutablePath, "DCP");

                FileStream c = System.IO.File.Create(configPath);
                c.Close();
                IMxldFile.IMxldWrite(configPath, "0", folderPath, style, startup, userid, passwd);
            }

            //通知
            new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", 5353636)
                .AddText("DCP已启动！")
                .AddText(DateTime.Now.ToString())
                .Show(toast =>
                {
                    //被忽略后通知自动消失
                    toast.ExpirationTime = DateTime.Now.AddSeconds(5);
                });

            if (userid.Equals("") || passwd.Equals("")) { }
            else
            {
                DrcomConnect(userid, passwd);
            }

            //ips = GetByNetworkInterface();
            //Regex regex = new Regex(@"^((2((5[0-5])|([0-4]\d)))|([0-1]?\d{1,2}))(\.((2((5[0-5])|([0-4]\d)))|([0-1]?\d{1,2}))){3}$");
            //foreach (IPAddress ip in ips)
            //{
            //    if (regex.IsMatch(ip.ToString()))
            //    {
            //        MessageBox.Show(ip.ToString());
            //        //break;
            //    }
            //}
        }

        //退出键
        private void DCPExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        //点击透明窗口
        private void DCP_MouseClick(object sender, MouseEventArgs e)
        {
            //打开文件夹
            //string strpath = @"D:\DesktopCleanPlan";
            Process.Start("explorer.exe", folderPath);
        }

        //选择快捷打开的文件夹
        private void DCPOption_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                folderPath = dlg.SelectedPath;
                IMxldEdit();
            }

            //if (File.Exists("DCPoption.config"))
            //{
            //    FileStream fs = new FileStream("DCPoption.config", FileMode.Open, FileAccess.Write);
            //    byte[] vs = Encoding.UTF8.GetBytes(folderPath);
            //    fs.Write(vs, 0, vs.Length);
            //    fs.Close();
            //}
            //else
            //{
            //    FileStream c = File.Create("DCPoption.config");
            //    c.Close();
            //    FileStream fs = new FileStream("DCPoption.config", FileMode.Open, FileAccess.Write);
            //    byte[] vs = Encoding.UTF8.GetBytes(folderPath);
            //    fs.Write(vs, 0, vs.Length);
            //    fs.Close();
            //}
        }

        //作者信息
        private void DCPAuthor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("你好！我是IMxld");
            MessageBox.Show("写作IMxld读作/'eksəʊd/");
            MessageBox.Show("给你讲个冷笑话吧");
            MessageBox.Show("它系かに  ≧( ° ° )≦");

            System.Diagnostics.Process.Start("https://space.bilibili.com/5353636");
        }

        //清空回收站
        private void DCPRubbish_Click(object sender, EventArgs e)
        {
            SHEmptyRecycleBin(this.Handle, "", 0);
        }

        //rickroll彩蛋
        private void DCPRickRoll_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.bilibili.com/video/BV1GJ411x7h7");
        }

        //任务管理器
        private void DCPTask_Click(object sender, EventArgs e)
        {
            //ProcessStartInfo info = new ProcessStartInfo();
            //info.FileName = Path.Combine(Environment.GetEnvironmentVariable("windir"), "explorer.exe");
            Process.Start(@"C:\Windows\System32\Taskmgr.exe");
        }

        //控制面板
        private void DCPControl_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Windows\System32\control.exe");
        }

        //打开回收站
        private void DCPUndo_Click(object sender, EventArgs e)
        {
            Process.Start("::{645FF040-5081-101B-9F08-00AA002F954E}");
        }

        //简约风格
        private void DCPSimple_Click(object sender, EventArgs e)
        {
            this.DCPStyle.Text = "风格设置";
            this.DCPOption.Text = "更改目标文件夹";
            this.DCPMaid.Text = "快捷操作";
            this.DCPAuthor.Text = "作者";
            this.DCPExit.Text = "退出";
            this.DCPRubbish.Text = "清空回收站";
            this.DCPUndo.Text = "回收站";
            this.DCPControl.Text = "控制面板";
            this.DCPTask.Text = "任务管理器";
            this.DCPRickRoll.Text = "？";
            this.DCPStartup.Text = "开机自启动";
            this.DCPYes.Text = "开启";
            this.DCPNo.Text = "关闭";
            this.DCPRegedit.Text = "注册表";
            this.DCPHelp.Text = "帮助";
            this.DCPIpv4.Text = "查询ip地址";
            this.DCPIpv6.Text = "测试ipv6连接";
            this.DCPProperty.Text = "本机属性";
            this.DCPWeather.Text = "天气";
            this.DCPScreenshot.Text = "截图工具";
            this.DCPKyuu.Text = "计算器";
            this.DCPDrcomTool.Text = "登录校园网（深大特供）";

            style = "0";
            IMxldEdit();

            if ((this.DCPSimple as ToolStripMenuItem).Checked)
            {
                return;
            }
            else
            {
                (this.DCPSimple as ToolStripMenuItem).Checked = true;
                (this.DCPEight as ToolStripMenuItem).Checked = false;
            }
        }

        //全是八个字风格
        private void DCPEight_Click(object sender, EventArgs e)
        {
            this.DCPStyle.Text = "☆太花哨了换个风格☆";
            this.DCPOption.Text = "☆换个文件夹打开嗷☆";
            this.DCPMaid.Text = "☆好像有个妹抖来着☆";
            this.DCPAuthor.Text = "☆哪个小天才设计的☆";
            this.DCPExit.Text = "☆这个绝不是退出键☆";
            this.DCPRubbish.Text = "☆帮我清空回收站吧☆";
            this.DCPUndo.Text = "☆爷刚刚丢错东西了☆";
            this.DCPControl.Text = "☆控制面板在哪儿呢☆";
            this.DCPTask.Text = "☆找不着任务管理器☆";
            this.DCPRickRoll.Text = "☆？？？？？？？？☆";
            this.DCPStartup.Text = "☆要不开机自启动吧☆";
            this.DCPYes.Text = "☆我看行就这么办吧☆";
            this.DCPNo.Text = "☆咱觉着大可不必嗷☆";
            this.DCPRegedit.Text = "☆我自启动注册表捏☆";
            this.DCPHelp.Text = "☆我是谁我该干什么☆";
            this.DCPIpv4.Text = "☆咱的ipv4地址是啥☆";
            this.DCPIpv6.Text = "☆顺便查查ipv6地址☆";
            this.DCPProperty.Text = "☆电脑属性在哪儿看☆";
            this.DCPWeather.Text = "☆这外面天气咋样啊☆";
            this.DCPScreenshot.Text = "☆自带截图工具在哪☆";
            this.DCPKyuu.Text = "☆琪露诺的算数教室☆";
            this.DCPDrcomTool.Text = "☆深带人专用小工具☆";

            style = "1";
            IMxldEdit();

            if ((this.DCPEight as ToolStripMenuItem).Checked)
            {
                return;
            }
            else
            {
                (this.DCPSimple as ToolStripMenuItem).Checked = false;
                (this.DCPEight as ToolStripMenuItem).Checked = true;
            }
        }

        //启用开机自启动
        private void DCPYes_Click(object sender, EventArgs e)
        {
            if ((this.DCPYes as ToolStripMenuItem).Checked)
            {
                return;
            }
            else
            {
                (this.DCPYes as ToolStripMenuItem).Checked = true;
                (this.DCPNo as ToolStripMenuItem).Checked = false;
            }

            startup = "1";
            IMxldEdit();

            //修改注册表
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            registryKey.SetValue("DCP", Application.ExecutablePath);
        }

        //关闭开机自启动
        private void DCPNo_Click(object sender, EventArgs e)
        {
            if ((this.DCPNo as ToolStripMenuItem).Checked)
            {
                return;
            }
            else
            {
                (this.DCPYes as ToolStripMenuItem).Checked = false;
                (this.DCPNo as ToolStripMenuItem).Checked = true;
            }

            startup = "0";
            IMxldEdit();

            //修改注册表
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            registryKey.SetValue("DCP", false);
        }

        //打开注册表
        private void DCPRegedit_Click(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Applets\Regedit", "LastKey", @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run");
            Process.Start(@"C:\Windows\regedit.exe");
        }

        //帮助
        private void DCPHelp_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            this.TransparencyKey = Color.Black;

            MessageBox.Show("看到我身后的【白板】了吗？");
            MessageBox.Show("↖如果没有的话请手动最小化其他所有应用↗");
            MessageBox.Show("记住它的【位置】嗷！");
            MessageBox.Show("【记住】嗷！");
            MessageBox.Show("【嗷】！");

            this.BackColor = Color.FromArgb(0, 0, 1);
            this.TransparencyKey = this.BackColor;

            MessageBox.Show("就是现在！点确定，然后【点一下】它所在的【位置】！");
        }

        //查询ipv4地址
        private void DCPIpv4_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.ip138.com/");
        }

        //查询ipv6
        private void DCPIpv6_Click(object sender, EventArgs e)
        {
            Process.Start("http://test-ipv6.com/");
        }

        //电脑属性
        private void DCPProperty_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Windows\System32\control.exe", "system");
        }

        //查看天气
        private void DCPWeather_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.baidu.com/s?wd=%E5%A4%A9%E6%B0%94");
        }

        //打开截图工具，win10不知道为什么打不开
        //Win10的截图工具在@"C:\Windows\System32\SnippingTool.exe"
        private void DCPScreenshot_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    ProcessStartInfo Info = new ProcessStartInfo();
                    Info.FileName = "snippingtool.exe";
                    Process.Start(Info);
                }
                //System.ComponentModel.Win32Exception
                catch
                {
                    Process.Start(@"C:\Windows\System32\SnippingTool.exe");
                }
            }
            catch
            {
                MessageBox.Show("当你看到这条消息时，说明没有找到系统自带的截图工具。\n我偷懒了没做Win11-64位系统以外的测试。\n姑且做了Win10适配，直接两层try catch了事。", "提示");
            }
            //Process.Start(@"C:\Windows\System32\cmd.exe", "--snippingtool");
            //Process.Start("snippingtool");

            //Win11可用！
            //MessageBox.Show("如果没有启动截图工具，极大可能是玄学问题\n我无能为力，sorry\n因为我没有在代码中使用try catch程序依然能正确运行");

            //Process pCmd = new Process();
            //pCmd.StartInfo.FileName = "cmd.exe";
            //pCmd.StartInfo.UseShellExecute = false;
            //pCmd.StartInfo.RedirectStandardInput = true;
            //pCmd.StartInfo.RedirectStandardOutput = true;
            //pCmd.StartInfo.RedirectStandardError = true;
            //pCmd.StartInfo.CreateNoWindow = true;
            //bool res = pCmd.Start();

            ////向cmd窗口发送输入信息
            //pCmd.StandardInput.WriteLine("snippingtool&exit");
            //pCmd.StandardInput.AutoFlush = true;

            #region 各种奇奇怪怪的尝试
            //Process[] prosCmd = Process.GetProcessesByName("cmd");
            //foreach (Process p in prosCmd)
            //{
            //    p.Kill();
            //}

            //Process p = new Process();
            //p.StartInfo.FileName = "cmd.exe";
            //p.StartInfo.CreateNoWindow = true;
            //p.StartInfo.Arguments = "/c snippingtool";
            //p.Start();

            //snippingtool
            //KeyboardSend.KeyDown(Keys.LWin);
            //KeyboardSend.KeyDown(Keys.R);
            //KeyboardSend.KeyUp(Keys.R);
            //KeyboardSend.KeyUp(Keys.LWin);

            //KeyboardSend.KeyDown(Keys.S);
            //KeyboardSend.KeyUp(Keys.S);
            //KeyboardSend.KeyDown(Keys.N);
            //KeyboardSend.KeyUp(Keys.N);
            //KeyboardSend.KeyDown(Keys.I);
            //KeyboardSend.KeyUp(Keys.I);
            //KeyboardSend.KeyDown(Keys.P);
            //KeyboardSend.KeyUp(Keys.P);
            //KeyboardSend.KeyDown(Keys.P);
            //KeyboardSend.KeyUp(Keys.P);
            //KeyboardSend.KeyDown(Keys.I);
            //KeyboardSend.KeyUp(Keys.I);
            //KeyboardSend.KeyDown(Keys.N);
            //KeyboardSend.KeyUp(Keys.N);
            //KeyboardSend.KeyDown(Keys.G);
            //KeyboardSend.KeyUp(Keys.G);
            //KeyboardSend.KeyDown(Keys.T);
            //KeyboardSend.KeyUp(Keys.T);
            //KeyboardSend.KeyDown(Keys.O);
            //KeyboardSend.KeyUp(Keys.O);
            //KeyboardSend.KeyDown(Keys.O);
            //KeyboardSend.KeyUp(Keys.O);
            //KeyboardSend.KeyDown(Keys.L);
            //KeyboardSend.KeyUp(Keys.L);
            //KeyboardSend.KeyDown(Keys.Enter);
            //KeyboardSend.KeyUp(Keys.Enter);
            #endregion
        }

        //计算器
        private void DCPKyuu_Click(object sender, EventArgs e)
        {
            if (style.Equals("1"))
            {
                MessageBox.Show("⑨");
            }

            ProcessStartInfo Info = new ProcessStartInfo();
            Info.FileName = "calc.exe";//"calc.exe"为计算器，"notepad.exe"为记事本
            Process.Start(Info);
        }

        #region 自动连接校园网
        //获取用户名和密码
        private void DCPDrcomTool_Click(object sender, EventArgs e)
        {
            DCPDrcom drcomWindows = new DCPDrcom();
            //注册事件
            drcomWindows.UserId += DrcomWindows_UserId;
            drcomWindows.Passwd += DrcomWindows_Passwd;
            drcomWindows.ShowDialog();
            IMxldEdit();
        }

        private void DrcomWindows_Passwd(string value)
        {
            passwd = value;
        }

        private void DrcomWindows_UserId(string value)
        {
            userid = value;
        }
        #endregion
    }

    //模拟用户输入类，弃用
    static class KeyboardSend
    {
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        private const int KEYEVENTF_EXTENDEDKEY = 1;
        private const int KEYEVENTF_KEYUP = 2;

        public static void KeyDown(Keys vKey)
        {
            keybd_event((byte)vKey, 0, KEYEVENTF_EXTENDEDKEY, 0);
        }

        public static void KeyUp(Keys vKey)
        {
            keybd_event((byte)vKey, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }
    }
}