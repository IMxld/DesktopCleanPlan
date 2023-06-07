using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopCleanPlan
{
    public partial class SIMSHelp : Form
    {
        public SIMSHelp()
        {
            InitializeComponent();
            //隐藏标题栏
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void Mouse_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
