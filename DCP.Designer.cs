
namespace DesktopCleanPlan
{
    partial class DCP
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCP));
            this.DCPTuopan = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DCPHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.DCPOption = new System.Windows.Forms.ToolStripMenuItem();
            this.DCPStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.DCPSimple = new System.Windows.Forms.ToolStripMenuItem();
            this.DCPEight = new System.Windows.Forms.ToolStripMenuItem();
            this.DCPStartup = new System.Windows.Forms.ToolStripMenuItem();
            this.DCPYes = new System.Windows.Forms.ToolStripMenuItem();
            this.DCPNo = new System.Windows.Forms.ToolStripMenuItem();
            this.DCPMaid = new System.Windows.Forms.ToolStripMenuItem();
            this.DCPRubbish = new System.Windows.Forms.ToolStripMenuItem();
            this.DCPUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.DCPControl = new System.Windows.Forms.ToolStripMenuItem();
            this.DCPTask = new System.Windows.Forms.ToolStripMenuItem();
            this.DCPRegedit = new System.Windows.Forms.ToolStripMenuItem();
            this.DCPProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.DCPRickRoll = new System.Windows.Forms.ToolStripMenuItem();
            this.DCPIpv4 = new System.Windows.Forms.ToolStripMenuItem();
            this.DCPIpv6 = new System.Windows.Forms.ToolStripMenuItem();
            this.DCPWeather = new System.Windows.Forms.ToolStripMenuItem();
            this.DCPScreenshot = new System.Windows.Forms.ToolStripMenuItem();
            this.DCPKyuu = new System.Windows.Forms.ToolStripMenuItem();
            this.DCPAuthor = new System.Windows.Forms.ToolStripMenuItem();
            this.DCPDrcomTool = new System.Windows.Forms.ToolStripMenuItem();
            this.DCPExit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DCPTuopan
            // 
            this.DCPTuopan.ContextMenuStrip = this.contextMenuStrip1;
            this.DCPTuopan.Icon = ((System.Drawing.Icon)(resources.GetObject("DCPTuopan.Icon")));
            this.DCPTuopan.Text = "DCP";
            this.DCPTuopan.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.contextMenuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.contextMenuStrip1.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DCPHelp,
            this.DCPOption,
            this.DCPStyle,
            this.DCPStartup,
            this.DCPMaid,
            this.DCPDrcomTool,
            this.DCPAuthor,
            this.DCPExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(237, 202);
            // 
            // DCPHelp
            // 
            this.DCPHelp.Name = "DCPHelp";
            this.DCPHelp.Size = new System.Drawing.Size(236, 22);
            this.DCPHelp.Text = "☆我是谁我该干什么☆";
            this.DCPHelp.Click += new System.EventHandler(this.DCPHelp_Click);
            // 
            // DCPOption
            // 
            this.DCPOption.Name = "DCPOption";
            this.DCPOption.Size = new System.Drawing.Size(236, 22);
            this.DCPOption.Text = "☆换个文件夹打开嗷☆";
            this.DCPOption.Click += new System.EventHandler(this.DCPOption_Click);
            // 
            // DCPStyle
            // 
            this.DCPStyle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DCPSimple,
            this.DCPEight});
            this.DCPStyle.Name = "DCPStyle";
            this.DCPStyle.Size = new System.Drawing.Size(236, 22);
            this.DCPStyle.Text = "☆太花哨了换个风格☆";
            // 
            // DCPSimple
            // 
            this.DCPSimple.Name = "DCPSimple";
            this.DCPSimple.Size = new System.Drawing.Size(236, 22);
            this.DCPSimple.Text = "简单明了";
            this.DCPSimple.Click += new System.EventHandler(this.DCPSimple_Click);
            // 
            // DCPEight
            // 
            this.DCPEight.Name = "DCPEight";
            this.DCPEight.Size = new System.Drawing.Size(236, 22);
            this.DCPEight.Text = "☆大家都是八个字呢☆";
            this.DCPEight.Click += new System.EventHandler(this.DCPEight_Click);
            // 
            // DCPStartup
            // 
            this.DCPStartup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DCPYes,
            this.DCPNo});
            this.DCPStartup.Name = "DCPStartup";
            this.DCPStartup.Size = new System.Drawing.Size(236, 22);
            this.DCPStartup.Text = "☆要不开机自启动吧☆";
            // 
            // DCPYes
            // 
            this.DCPYes.Name = "DCPYes";
            this.DCPYes.Size = new System.Drawing.Size(236, 22);
            this.DCPYes.Text = "☆我看行就这么办吧☆";
            this.DCPYes.Click += new System.EventHandler(this.DCPYes_Click);
            // 
            // DCPNo
            // 
            this.DCPNo.Name = "DCPNo";
            this.DCPNo.Size = new System.Drawing.Size(236, 22);
            this.DCPNo.Text = "☆咱觉着大可不必嗷☆";
            this.DCPNo.Click += new System.EventHandler(this.DCPNo_Click);
            // 
            // DCPMaid
            // 
            this.DCPMaid.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DCPRubbish,
            this.DCPUndo,
            this.DCPControl,
            this.DCPTask,
            this.DCPRegedit,
            this.DCPProperty,
            this.DCPRickRoll,
            this.DCPIpv4,
            this.DCPIpv6,
            this.DCPWeather,
            this.DCPScreenshot,
            this.DCPKyuu});
            this.DCPMaid.Name = "DCPMaid";
            this.DCPMaid.Size = new System.Drawing.Size(236, 22);
            this.DCPMaid.Text = "☆好像有个妹抖来着☆";
            // 
            // DCPRubbish
            // 
            this.DCPRubbish.Name = "DCPRubbish";
            this.DCPRubbish.Size = new System.Drawing.Size(236, 22);
            this.DCPRubbish.Text = "☆帮我清空回收站吧☆";
            this.DCPRubbish.Click += new System.EventHandler(this.DCPRubbish_Click);
            // 
            // DCPUndo
            // 
            this.DCPUndo.Name = "DCPUndo";
            this.DCPUndo.Size = new System.Drawing.Size(236, 22);
            this.DCPUndo.Text = "☆爷刚刚丢错东西了☆";
            this.DCPUndo.Click += new System.EventHandler(this.DCPUndo_Click);
            // 
            // DCPControl
            // 
            this.DCPControl.Name = "DCPControl";
            this.DCPControl.Size = new System.Drawing.Size(236, 22);
            this.DCPControl.Text = "☆控制面板在哪儿呢☆";
            this.DCPControl.Click += new System.EventHandler(this.DCPControl_Click);
            // 
            // DCPTask
            // 
            this.DCPTask.Name = "DCPTask";
            this.DCPTask.Size = new System.Drawing.Size(236, 22);
            this.DCPTask.Text = "☆找不着任务管理器☆";
            this.DCPTask.Click += new System.EventHandler(this.DCPTask_Click);
            // 
            // DCPRegedit
            // 
            this.DCPRegedit.Name = "DCPRegedit";
            this.DCPRegedit.Size = new System.Drawing.Size(236, 22);
            this.DCPRegedit.Text = "☆我自启动注册表捏☆";
            this.DCPRegedit.Click += new System.EventHandler(this.DCPRegedit_Click);
            // 
            // DCPProperty
            // 
            this.DCPProperty.Name = "DCPProperty";
            this.DCPProperty.Size = new System.Drawing.Size(236, 22);
            this.DCPProperty.Text = "☆电脑属性在哪儿看☆";
            this.DCPProperty.Click += new System.EventHandler(this.DCPProperty_Click);
            // 
            // DCPRickRoll
            // 
            this.DCPRickRoll.Name = "DCPRickRoll";
            this.DCPRickRoll.Size = new System.Drawing.Size(236, 22);
            this.DCPRickRoll.Text = "☆？？？？？？？？☆";
            this.DCPRickRoll.Click += new System.EventHandler(this.DCPRickRoll_Click);
            // 
            // DCPIpv4
            // 
            this.DCPIpv4.Name = "DCPIpv4";
            this.DCPIpv4.Size = new System.Drawing.Size(236, 22);
            this.DCPIpv4.Text = "☆咱的ipv4地址是啥☆";
            this.DCPIpv4.Click += new System.EventHandler(this.DCPIpv4_Click);
            // 
            // DCPIpv6
            // 
            this.DCPIpv6.Name = "DCPIpv6";
            this.DCPIpv6.Size = new System.Drawing.Size(236, 22);
            this.DCPIpv6.Text = "☆顺便查查ipv6地址☆";
            this.DCPIpv6.Click += new System.EventHandler(this.DCPIpv6_Click);
            // 
            // DCPWeather
            // 
            this.DCPWeather.Name = "DCPWeather";
            this.DCPWeather.Size = new System.Drawing.Size(236, 22);
            this.DCPWeather.Text = "☆这外面天气咋样啊☆";
            this.DCPWeather.Click += new System.EventHandler(this.DCPWeather_Click);
            // 
            // DCPScreenshot
            // 
            this.DCPScreenshot.Name = "DCPScreenshot";
            this.DCPScreenshot.Size = new System.Drawing.Size(236, 22);
            this.DCPScreenshot.Text = "☆自带截图工具在哪☆";
            this.DCPScreenshot.Click += new System.EventHandler(this.DCPScreenshot_Click);
            // 
            // DCPKyuu
            // 
            this.DCPKyuu.Name = "DCPKyuu";
            this.DCPKyuu.Size = new System.Drawing.Size(236, 22);
            this.DCPKyuu.Text = "☆琪露诺的算数教室☆";
            this.DCPKyuu.Click += new System.EventHandler(this.DCPKyuu_Click);
            // 
            // DCPAuthor
            // 
            this.DCPAuthor.Name = "DCPAuthor";
            this.DCPAuthor.Size = new System.Drawing.Size(236, 22);
            this.DCPAuthor.Text = "☆哪个小天才设计的☆";
            this.DCPAuthor.Click += new System.EventHandler(this.DCPAuthor_Click);
            // 
            // DCPDrcomTool
            // 
            this.DCPDrcomTool.Name = "DCPDrcomTool";
            this.DCPDrcomTool.Size = new System.Drawing.Size(236, 22);
            this.DCPDrcomTool.Text = "☆深带人专用小工具☆";
            this.DCPDrcomTool.Click += new System.EventHandler(this.DCPDrcomTool_Click);
            // 
            // DCPExit
            // 
            this.DCPExit.Name = "DCPExit";
            this.DCPExit.Size = new System.Drawing.Size(236, 22);
            this.DCPExit.Text = "☆这个绝不是退出键☆";
            this.DCPExit.Click += new System.EventHandler(this.DCPExit_Click);
            // 
            // DCP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(136, 122);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DCP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DCP";
            this.Load += new System.EventHandler(this.DCP_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DCP_MouseClick);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon DCPTuopan;
        private System.Windows.Forms.ToolStripMenuItem DCPExit;
        private System.Windows.Forms.ToolStripMenuItem DCPOption;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem DCPMaid;
        private System.Windows.Forms.ToolStripMenuItem DCPRubbish;
        private System.Windows.Forms.ToolStripMenuItem DCPControl;
        private System.Windows.Forms.ToolStripMenuItem DCPTask;
        private System.Windows.Forms.ToolStripMenuItem DCPAuthor;
        private System.Windows.Forms.ToolStripMenuItem DCPRickRoll;
        private System.Windows.Forms.ToolStripMenuItem DCPUndo;
        private System.Windows.Forms.ToolStripMenuItem DCPStyle;
        private System.Windows.Forms.ToolStripMenuItem DCPSimple;
        private System.Windows.Forms.ToolStripMenuItem DCPEight;
        private System.Windows.Forms.ToolStripMenuItem DCPStartup;
        private System.Windows.Forms.ToolStripMenuItem DCPYes;
        private System.Windows.Forms.ToolStripMenuItem DCPNo;
        private System.Windows.Forms.ToolStripMenuItem DCPRegedit;
        private System.Windows.Forms.ToolStripMenuItem DCPHelp;
        private System.Windows.Forms.ToolStripMenuItem DCPIpv4;
        private System.Windows.Forms.ToolStripMenuItem DCPIpv6;
        private System.Windows.Forms.ToolStripMenuItem DCPProperty;
        private System.Windows.Forms.ToolStripMenuItem DCPWeather;
        private System.Windows.Forms.ToolStripMenuItem DCPScreenshot;
        private System.Windows.Forms.ToolStripMenuItem DCPKyuu;
        private System.Windows.Forms.ToolStripMenuItem DCPDrcomTool;
    }
}

