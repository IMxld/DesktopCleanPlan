using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DesktopCleanPlan.DCPDrcom;

namespace DesktopCleanPlan
{
    public partial class DCPSIMS : Form
    {
        //声明（传参）委托
        public delegate void GiveSIMSCookie(String value);
        public delegate void GiveSIMSClientIp(String value);
        public delegate void GiveSIMSRoomId(String value);
        public delegate void GiveSIMSRoomName(String value);
        public delegate void GiveSIMSBuilding(String value);

        public DCPSIMS()
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

        private void DCPSIMS_Load(object sender, EventArgs e)
        {
            DCPSIMSCookie.Text = DCPSettings.cookie;
            DCPSIMSClientIp.Text = DCPSettings.clientIp;
            DCPSIMSRoomId.Text = DCPSettings.roomId;
            DCPSIMSRoomName.Text = DCPSettings.roomName;
            DCPSIMSBuilding.Text = DCPSettings.building;
        }

        private void DCPSIMS_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        //注册传参事件
        public event GiveSIMSCookie CookieStr;
        public event GiveSIMSClientIp ClientIpStr;
        public event GiveSIMSRoomId RoomIdStr;
        public event GiveSIMSRoomName RoomNameStr;
        public event GiveSIMSBuilding BuildingStr;
        private void DCPSIMSSave_Click(object sender, EventArgs e)
        {
            CookieStr(DCPSIMSCookie.Text);
            ClientIpStr(DCPSIMSClientIp.Text);
            RoomIdStr(DCPSIMSRoomId.Text);
            RoomNameStr(DCPSIMSRoomName.Text);
            BuildingStr(DCPSIMSBuilding.Text);
            this.Close();
            this.Dispose();
        }

        private void Help_Click(object sender, EventArgs e)
        {
            SIMSHelp simsHelpWindow = new SIMSHelp();
            simsHelpWindow.ShowDialog();
        }
    }
}
