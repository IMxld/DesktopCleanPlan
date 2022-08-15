using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DesktopCleanPlan
{
    public partial class DCPDrcom : Form
    {
        //声明（传参）委托
        public delegate void GiveDrcomUser(String value);
        public delegate void GiveDrcomPasswd(String value);

        private string notice = "DCP（全称DesktopCleanPlan，以下简称DCP）是由个人开发使用的用于快捷使用其他程序的工具。DCP提供的所有服务均为软件作者编写，不得用于任何商业用途。\n\n" + 
            "DCP之著作权归软件作者所有。用户可以自由选择是否使用DCP。如果用户下载、安装、使用DCP，即表明用户信任该软件作者，软件作者对任何原因在使用DCP时可能对用户自己或他人造成的任何形式的损失和伤害不承担责任。\n\n" + 
            "任何单位或个人认为通过DCP可能涉嫌侵犯其合法权益，应该及时向【imxld@foxmail.com】书面反馈，并提供身份证明、权属证明及详细侵权情况证明，软件作者在收到上述法律文件后，将会尽快移除被控侵权软件。";
        private string promise = "软件作者承诺不会收集用户个人信息，联网请求仅来自登录校园网功能。\n若发现有个人信息泄露情况来自DCP，请立即停止使用盗版软件，保留相关证据并向【imxld@foxmail.com】反馈。";

        public DCPDrcom()
        {
            InitializeComponent();
            //隐藏标题栏
            this.FormBorderStyle = FormBorderStyle.None;
        }

        //拖动窗口
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        private void DCPDrcom_Load(object sender, EventArgs e)
        {
            DCPDrcomUser.Text = DCP.userid;
            DCPDrcomPasswd.Text = DCP.passwd;
        }

        //注册（传参）事件
        public event GiveDrcomUser UserId;
        public event GiveDrcomUser Passwd;
        private void DCPDrcomSave_Click(object sender, EventArgs e)
        {
            UserId(DCPDrcomUser.Text);
            Passwd(DCPDrcomPasswd.Text);
            this.Close();
        }

        private void DCPDrcomRetry_Click(object sender, EventArgs e)
        {
            DCP.DrcomConnect(DCPDrcomUser.Text, DCPDrcomPasswd.Text);
        }

        private void Github_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("下个版本的时候我应该会把软件源代码放上去\n现在姑且是没有的");
            Process.Start("https://github.com/IMxld");
        }

        private void Notice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(notice, "免责声明");
            MessageBox.Show(promise, "承诺");
        }

        private void DCPDrcom_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
    }
}