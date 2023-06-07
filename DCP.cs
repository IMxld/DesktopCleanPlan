using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using System.Configuration;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        //private List<string> res = new List<string>();
        private string configPath = Application.StartupPath + "\\DCPconfig.json";
        //private List<IPAddress> ips = new List<IPAddress>();
        private Dictionary<string, string> datas = new Dictionary<string, string>();
        private int loopLock = 2;
        private static bool stayAtSchool = true;
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

        //判断网络状况的方法,返回值true为连接，false为未连接  
        [DllImport("wininet")]
        public extern static bool InternetGetConnectedState(out int conState, int reder);

        //连接校园网
        public static void DrcomConnect(string userid, string passwd)
        {
            string ip = ""; //为了通过编译
            try
            {
                //ping校园网ip获得DHCP服务器分发的ip
                System.Net.Sockets.TcpClient tcpClient = new System.Net.Sockets.TcpClient();
                tcpClient.Connect("172.30.255.42", 80);
                ip = ((IPEndPoint)tcpClient.Client.LocalEndPoint).Address.ToString();
                tcpClient.Close();
            }
            catch (System.Net.Sockets.SocketException)
            {
                stayAtSchool = false;
                return; //在校外，直接跳出
            }

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
                        .AddText("1.账户或密码输入错误；2.该账户已经登录；3.没网费了；4.DCP被ban了（小概率事件）。")
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

        //闹钟中控
        public void ClockCenterControll()
        {

        }

        //加载时
        private void DCP_Load(object sender, EventArgs e)
        {
            this.DCPNo.Checked = true;
            this.DCPEight.Checked = true;

            /*以前用读取imxld文件的方式
            if (System.IO.File.Exists(configPath))
            {
                res = IMxldFile.IMxldRead(configPath, "0");
                if (res.Count() != 10)
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
                IMxldFile.IMxldWrite(configPath, "0", folderPath, style, startup, userid, passwd, cookie, clientIp, roomId, roomName, building);
            }
            */

            if (!System.IO.File.Exists(configPath))
            {
                FileStream c = System.IO.File.Create(configPath);
                c.Close();
                c.Dispose();
                JsonConfig.WriteJson();
            }

            //DistributeData();
            JsonConfig.DistributeData();

            switch (DCPSettings.style)
            {
                case "0":
                    DCPSimple_Click(null, null);
                    break;
                case "1":
                    DCPEight_Click(null, null);
                    break;
            }
            switch (DCPSettings.startup)
            {
                case "0":
                    DCPNo_Click(null, null);
                    break;
                case "1":
                    DCPYes_Click(null, null);
                    break;
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



            //人在学校再开启该功能
            if (stayAtSchool)
            {
                if (DCPSettings.userid.Equals("") || DCPSettings.passwd.Equals("")) { }
                else
                {
                    DrcomConnect(DCPSettings.userid, DCPSettings.passwd);
                }

                try
                {
                    DCPLastPower_Click(null, null);
                }
                catch { }
            }

            //开启闹钟线程
            Thread clock = new Thread(ClockCenterControll);
            clock.Start();
        }

        //退出键
        private void DCPExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        //点击透明窗口
        private void DCP_MouseClick(object sender, MouseEventArgs e)
        {
            //读取注册表项
            //RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\IMxld\\DCP", true);
            //folderPath = registryKey.GetValue("OpenFolderPath").ToString();
            //registryKey.Close();

            //打开文件夹
            //string strpath = @"D:\DesktopCleanPlan";
            Process.Start("explorer.exe", DCPSettings.folderPath);
        }

        //选择快捷打开的文件夹
        private void DCPOption_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                DCPSettings.folderPath = dlg.SelectedPath;
                JsonConfig.WriteJson();
                //WriteConfig("folderPath", folderPath);

                //RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\IMxld\\DCP", true);
                //registryKey.SetValue("OpenFolderPath", folderPath);
                //registryKey.Close();

                dlg.Dispose();
            }
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
            this.DCPOption.Text = "更改文件夹";
            this.DCPMaid.Text = "工具箱";
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
            this.DCPDrcomTool.Text = "登录校园网（Drcom）";
            this.DCPCheckPower.Text = "查询剩余电量（SIMS）";
            this.DCPLastPower.Text = "查看余电";
            this.DCPBindMyRoom.Text = "绑定房间";
            this.DCPClock.Text = "语音闹钟";

            DCPSettings.style = "0";
            JsonConfig.WriteJson();
            //WriteConfig("style", "0");

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
            this.DCPCheckPower.Text = "☆咱们家还有电用吗☆";
            this.DCPLastPower.Text = "☆点我查看剩余电量☆";
            this.DCPBindMyRoom.Text = "☆绑定一下我的房间☆";
            this.DCPClock.Text = "☆一个很有趣的闹钟☆";

            DCPSettings.style = "1";
            JsonConfig.WriteJson();
            //WriteConfig("style", "1");

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

            DCPSettings.startup = "1";
            JsonConfig.WriteJson();
            //WriteConfig("startup", "1");

            //修改注册表
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            registryKey.SetValue("DCP", Application.ExecutablePath);
            registryKey.Close();
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

            DCPSettings.startup = "0";
            JsonConfig.WriteJson();
            //WriteConfig("startup", "0");

            //修改注册表
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            registryKey.SetValue("DCP", false);
            registryKey.Close();
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
            if (DCPSettings.style.Equals("1"))
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

            JsonConfig.WriteJson();
            //WriteConfig("userid", userid);
            //WriteConfig("passwd", passwd);
        }

        private void DrcomWindows_Passwd(string value)
        {
            DCPSettings.passwd = value;
        }

        private void DrcomWindows_UserId(string value)
        {
            DCPSettings.userid = value;
        }
        #endregion

        //添加header
        public void SetHeaderValue(WebHeaderCollection header, string name, string value)
        {
            var property = typeof(WebHeaderCollection).GetProperty("InnerCollection", BindingFlags.Instance | BindingFlags.NonPublic);
            if (property != null)
            {
                var collection = property.GetValue(header, null) as NameValueCollection;
                collection[name] = value;
            }
        }

        //向网站post
        public string Post(string url, Dictionary<string, string> dic)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            SetHeaderValue(req.Headers, "Cookie", DCPSettings.cookie);
            SetHeaderValue(req.Headers, "Host", "192.168.84.3:9090");
            SetHeaderValue(req.Headers, "Origin", "http://192.168.84.3:9090");
            SetHeaderValue(req.Headers, "Referer", "http://192.168.84.3:9090/cgcSims/login.do");
            SetHeaderValue(req.Headers, "User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/105.0.0.0 Safari/537.36");
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            #region 添加Post 参数
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in dic)
            {
                if (i > 0)
                    builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }
            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        #region 绑定房间
        private void DCPBindMyRoom_Click(object sender, EventArgs e)
        {
            DCPSIMS simsWindows = new DCPSIMS();
            //注册事件
            simsWindows.CookieStr += SimsWindows_CookieStr;
            simsWindows.ClientIpStr += SimsWindows_ClientIpStr;
            simsWindows.RoomIdStr += SimsWindows_RoomIdStr;
            simsWindows.RoomNameStr += SimsWindows_RoomNameStr;
            simsWindows.BuildingStr += SimsWindows_BuildingStr;
            simsWindows.ShowDialog();

            JsonConfig.WriteJson();
            //WriteConfig("cookie", cookie);
            //WriteConfig("clientIp", clientIp);
            //WriteConfig("roomId", roomId);
            //WriteConfig("roomName", roomName);
            //WriteConfig("building", building);
        }

        private void SimsWindows_BuildingStr(string value)
        {
            DCPSettings.building = value;
        }

        private void SimsWindows_RoomNameStr(string value)
        {
            DCPSettings.roomName = value;
        }

        private void SimsWindows_RoomIdStr(string value)
        {
            DCPSettings.roomId =value;
        }

        private void SimsWindows_ClientIpStr(string value)
        {
            DCPSettings.clientIp = value;
        }

        private void SimsWindows_CookieStr(string value)
        {
            DCPSettings.cookie = value;
        }
        #endregion

        //查询剩余电量
        private void DCPLastPower_Click(object sender, EventArgs e)
        {
            //Process.Start(@"F:\visual studio 2019\code\SIMSQueryPowerConsumption\SIMSQueryPowerConsumption.py");
            datas["hiddenType"] = "";
            datas["isHost"] = "";
            datas["beginTime"] = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            datas["endTime"] = DateTime.Now.ToString("yyyy-MM-dd");
            datas["type"] = "2";
            datas["client"] = DCPSettings.clientIp;
            datas["roomId"] = DCPSettings.roomId;
            datas["roomName"] = DCPSettings.roomName;
            datas["building"] = DCPSettings.building;

            try
            {
                string powerResult = Post("http://192.168.84.3:9090/cgcSims/selectList.do", datas);
                MatchCollection matchCol = Regex.Matches(powerResult, @"(?<=<td width=""13%"" align=""center"">)[\s\S]+?(?=</td>)");
                Match match = Regex.Match(matchCol[2].Value, @"[\d\.]+");
                if (Convert.ToSingle(match.Value) < 30)
                {
                    MessageBox.Show("剩余电量：" + match.Value, "余电查询");
                    MessageBox.Show("该充电费啦！", "余电查询");
                }
                else
                {
                    MessageBox.Show("剩余电量：" + match.Value, "余电查询");
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                loopLock--;
                if(loopLock <= 0)
                {
                    MessageBox.Show("查询不到昨日甚至是两天内的用点记录！");
                    return;
                }
                //查不到今天就查昨天的凑合用
                datas["beginTime"] = DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd");
                datas["endTime"] = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                DCPLastPower_Click(null, null);
            }
            catch (System.Net.Sockets.SocketException) { /*在校外*/}
            catch
            {
                MessageBox.Show("请先绑定房间再重试。\n如仍有疑问，请联系软件作者。", "警告");
            }
            finally
            {
                loopLock = 2;
            }
        }

        //语音闹钟
        private void DCPClock_Click(object sender, EventArgs e)
        {
            DCPClock clockWindows = new DCPClock();

            clockWindows.ShowDialog();
        }

        #region 弃用的老代码
        //创建桌面和开始菜单快捷方式，暂时弃用
        //private bool CrtShortCut(string FilePath, string fileName)
        //{
        //    WshShell shell = new WshShell();

        //    //创建桌面快捷方式
        //    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + fileName + ".lnk");
        //    shortcut.TargetPath = FilePath;
        //    shortcut.WorkingDirectory = Environment.CurrentDirectory;
        //    shortcut.WindowStyle = 1;
        //    shortcut.Description = fileName;
        //    shortcut.Save();

        //    //创建开始菜单快捷方式
        //    IWshShortcut shortcut1 = (IWshShortcut)shell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + "\\" + fileName + ".lnk");
        //    shortcut1.TargetPath = FilePath;
        //    shortcut1.WorkingDirectory = Environment.CurrentDirectory;
        //    shortcut1.WindowStyle = 1;
        //    shortcut1.Description = fileName;
        //    shortcut1.Save();
        //    return true;
        //}

        //编辑DCPconfig.imxld
        //现改用app.config
        //private void IMxldEdit()
        //{
        //    if (System.IO.File.Exists(configPath))
        //    {
        //        res = IMxldFile.IMxldRead(configPath, "0");
        //        IMxldFile.IMxldWrite(configPath, "0", folderPath, style, startup, userid, passwd, cookie, clientIp, roomId, roomName, building);
        //    }
        //    else
        //    {
        //        FileStream c = System.IO.File.Create(configPath);
        //        c.Close();
        //        IMxldFile.IMxldWrite(configPath, "0", folderPath, style, startup, userid, passwd, cookie, clientIp, roomId, roomName, building);

        //        //创建注册表
        //        RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
        //        registryKey.CreateSubKey("IMxld\\DCP");
        //        registryKey.Close();
        //    }
        //}

        //更改并保存config
        //private void WriteConfig(string key, string value)
        //{
        //    Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //    if (configuration.AppSettings.Settings[key] != null)
        //    {
        //        configuration.AppSettings.Settings[key].Value = value;
        //    }
        //    else
        //    {
        //        configuration.AppSettings.Settings.Add(key, value);
        //    }
        //    configuration.Save(ConfigurationSaveMode.Modified);
        //    ConfigurationManager.RefreshSection("appSettings");
        //}

        //无论网络通不通都能获取到Ip，暂时弃用
        //public static List<IPAddress> GetByNetworkInterface()
        //{
        //    try
        //    {
        //        NetworkInterface[] intf = NetworkInterface.GetAllNetworkInterfaces();
        //        List<IPAddress> ls = new List<IPAddress>();
        //        foreach (NetworkInterface item in intf)
        //        {
        //            IPInterfaceProperties adapterPropertis = item.GetIPProperties();
        //            UnicastIPAddressInformationCollection coll = adapterPropertis.UnicastAddresses;
        //            foreach (UnicastIPAddressInformation col in coll)
        //            {
        //                ls.Add(col.Address);
        //            }
        //        }
        //        return ls;
        //    }
        //    catch (Exception)
        //    {
        //        return new List<IPAddress>();

        //    }
        //}

        //分发变量和初始化
        //private void DistributeData(List<string> res)
        //{
        //    folderPath = res[0];
        //    style = res[1];
        //    startup = res[2];

        //    userid = res[3];
        //    passwd = res[4];

        //    cookie = res[5];
        //    clientIp = res[6];
        //    roomId = res[7];
        //    roomName = res[8];
        //    building = res[9];

        //    datas["hiddenType"] = "";
        //    datas["isHost"] = "";
        //    datas["beginTime"] = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
        //    datas["endTime"] = DateTime.Now.ToString("yyyy-MM-dd");
        //    datas["type"] = "2";
        //    datas["client"] = clientIp;
        //    datas["roomId"] = roomId;
        //    datas["roomName"] = roomName;
        //    datas["building"] = building;
        //}

        //读取app.config
        //private void DistributeData()
        //{
        //    folderPath = ConfigurationManager.AppSettings.Get("folderPath");
        //    style = ConfigurationManager.AppSettings.Get("style");
        //    startup = ConfigurationManager.AppSettings.Get("startup");

        //    userid = ConfigurationManager.AppSettings.Get("userid");
        //    passwd = ConfigurationManager.AppSettings.Get("passwd");

        //    cookie = ConfigurationManager.AppSettings.Get("cookie");
        //    clientIp = ConfigurationManager.AppSettings.Get("clientIp");
        //    roomId = ConfigurationManager.AppSettings.Get("roomId");
        //    roomName = ConfigurationManager.AppSettings.Get("roomName");
        //    building = ConfigurationManager.AppSettings.Get("building");

        //    datas["hiddenType"] = "";
        //    datas["isHost"] = "";
        //    datas["beginTime"] = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
        //    datas["endTime"] = DateTime.Now.ToString("yyyy-MM-dd");
        //    datas["type"] = "2";
        //    datas["client"] = clientIp;
        //    datas["roomId"] = roomId;
        //    datas["roomName"] = roomName;
        //    datas["building"] = building;
        //}
        #endregion
    }

    //模拟用户输入类，弃用
    //static class KeyboardSend
    //{
    //    [DllImport("user32.dll")]
    //    private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

    //    private const int KEYEVENTF_EXTENDEDKEY = 1;
    //    private const int KEYEVENTF_KEYUP = 2;

    //    public static void KeyDown(Keys vKey)
    //    {
    //        keybd_event((byte)vKey, 0, KEYEVENTF_EXTENDEDKEY, 0);
    //    }

    //    public static void KeyUp(Keys vKey)
    //    {
    //        keybd_event((byte)vKey, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
    //    }
    //}
}