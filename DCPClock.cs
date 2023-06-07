using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopCleanPlan
{
    public partial class DCPClock : Form
    {
        public DCPClock()
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

        //内存清理
        [DllImport("kernel32.dll")]
        private static extern bool SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);

        private void DCPClock_Load(object sender, EventArgs e)
        {
            List<string> clockType = new List<string>() { "每年","每月", "每天", "星期", "单次" };
        }

        private void DCPClock_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void ClockClose_Click(object sender, EventArgs e)
        {
            this.Close();
            FlushMemory();
        }

        //刷新内存
        private static void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
        }

        private void Github_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/IMxld");
        }

        private void Bilibili_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://space.bilibili.com/5353636");
        }

        private void Mail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText("imxld@foxmail.com");
            MessageBox.Show("邮件地址已复制到剪切板");
        }

        private void ClockAdd_Click(object sender, EventArgs e)
        {
            AlarmClock aNewClock = new AlarmClock();
            
            Console.WriteLine(aNewClock.ToString());
        }

        private List<DayOfWeek> GetWeeks(CheckedListBox checkedListBox)
        {
            List<DayOfWeek> weeks = new List<DayOfWeek>();
            IEnumerator week = checkedListBox.CheckedIndices.GetEnumerator();
            int index;
            while (week.MoveNext())
            {
                index = (int)week.Current;
                switch(index)
                {
                    case 0:
                        weeks.Add(DayOfWeek.Monday);
                        break;
                    case 1:
                        weeks.Add(DayOfWeek.Tuesday);
                        break;
                    case 2:
                        weeks.Add(DayOfWeek.Wednesday);
                        break;
                    case 3:
                        weeks.Add(DayOfWeek.Thursday);
                        break;
                    case 4:
                        weeks.Add(DayOfWeek.Friday);
                        break;
                    case 5:
                        weeks.Add(DayOfWeek.Saturday);
                        break;
                    case 6:
                        weeks.Add(DayOfWeek.Sunday);
                        break;
                }
            }
            return weeks;
        }

        private void SelectClear_Click(object sender, EventArgs e)
        {

        }

        private void Help_Click(object sender, EventArgs e)
        {

        }

        private void ClockEdit_Click(object sender, EventArgs e)
        {

        }

        private void ClockDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
