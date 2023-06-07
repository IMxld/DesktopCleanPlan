namespace DesktopCleanPlan
{
    partial class DCPClock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCPClock));
            this.ClockPanel = new System.Windows.Forms.Panel();
            this.Mail = new System.Windows.Forms.LinkLabel();
            this.Bilibili = new System.Windows.Forms.LinkLabel();
            this.Github = new System.Windows.Forms.LinkLabel();
            this.ClockClose = new System.Windows.Forms.Button();
            this.Help = new System.Windows.Forms.Button();
            this.ClockEdit = new System.Windows.Forms.Button();
            this.SelectClear = new System.Windows.Forms.Button();
            this.ClockDelete = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ClockTip = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.VoiceSelect = new System.Windows.Forms.ComboBox();
            this.ClockNoticeMode = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ClockAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ClockTitle = new System.Windows.Forms.TextBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ClockYear = new System.Windows.Forms.TextBox();
            this.ClockSecond = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ClockMinute = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ClockHour = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ClockDay = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ClockMonth = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ClockWeek = new System.Windows.Forms.CheckedListBox();
            this.AlarmClock = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ClockPanel.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClockPanel
            // 
            this.ClockPanel.BackColor = System.Drawing.Color.Transparent;
            this.ClockPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ClockPanel.BackgroundImage")));
            this.ClockPanel.Controls.Add(this.label11);
            this.ClockPanel.Controls.Add(this.AlarmClock);
            this.ClockPanel.Controls.Add(this.Mail);
            this.ClockPanel.Controls.Add(this.Bilibili);
            this.ClockPanel.Controls.Add(this.Github);
            this.ClockPanel.Controls.Add(this.ClockClose);
            this.ClockPanel.Controls.Add(this.Help);
            this.ClockPanel.Controls.Add(this.ClockEdit);
            this.ClockPanel.Controls.Add(this.SelectClear);
            this.ClockPanel.Controls.Add(this.ClockDelete);
            this.ClockPanel.Controls.Add(this.groupBox3);
            this.ClockPanel.Controls.Add(this.ClockAdd);
            this.ClockPanel.Controls.Add(this.groupBox2);
            this.ClockPanel.Controls.Add(this.GroupBox1);
            this.ClockPanel.Location = new System.Drawing.Point(0, 0);
            this.ClockPanel.Name = "ClockPanel";
            this.ClockPanel.Size = new System.Drawing.Size(788, 444);
            this.ClockPanel.TabIndex = 0;
            this.ClockPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DCPClock_MouseDown);
            // 
            // Mail
            // 
            this.Mail.AutoSize = true;
            this.Mail.Location = new System.Drawing.Point(250, 373);
            this.Mail.Name = "Mail";
            this.Mail.Size = new System.Drawing.Size(29, 12);
            this.Mail.TabIndex = 24;
            this.Mail.TabStop = true;
            this.Mail.Text = "Mail";
            this.Mail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Mail_LinkClicked);
            // 
            // Bilibili
            // 
            this.Bilibili.AutoSize = true;
            this.Bilibili.Location = new System.Drawing.Point(134, 373);
            this.Bilibili.Name = "Bilibili";
            this.Bilibili.Size = new System.Drawing.Size(53, 12);
            this.Bilibili.TabIndex = 23;
            this.Bilibili.TabStop = true;
            this.Bilibili.Text = "Bilibili";
            this.Bilibili.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Bilibili_LinkClicked);
            // 
            // Github
            // 
            this.Github.AutoSize = true;
            this.Github.Location = new System.Drawing.Point(39, 373);
            this.Github.Name = "Github";
            this.Github.Size = new System.Drawing.Size(41, 12);
            this.Github.TabIndex = 22;
            this.Github.TabStop = true;
            this.Github.Text = "Github";
            this.Github.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Github_LinkClicked);
            // 
            // ClockClose
            // 
            this.ClockClose.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClockClose.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClockClose.Location = new System.Drawing.Point(599, 7);
            this.ClockClose.Name = "ClockClose";
            this.ClockClose.Size = new System.Drawing.Size(93, 26);
            this.ClockClose.TabIndex = 21;
            this.ClockClose.Text = "关闭窗口";
            this.ClockClose.UseVisualStyleBackColor = false;
            this.ClockClose.Click += new System.EventHandler(this.ClockClose_Click);
            // 
            // Help
            // 
            this.Help.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Help.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Help.Location = new System.Drawing.Point(217, 334);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(93, 26);
            this.Help.TabIndex = 20;
            this.Help.Text = "获取帮助";
            this.Help.UseVisualStyleBackColor = false;
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // ClockEdit
            // 
            this.ClockEdit.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClockEdit.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClockEdit.Location = new System.Drawing.Point(401, 7);
            this.ClockEdit.Name = "ClockEdit";
            this.ClockEdit.Size = new System.Drawing.Size(93, 26);
            this.ClockEdit.TabIndex = 19;
            this.ClockEdit.Text = "编辑闹钟";
            this.ClockEdit.UseVisualStyleBackColor = false;
            this.ClockEdit.Click += new System.EventHandler(this.ClockEdit_Click);
            // 
            // SelectClear
            // 
            this.SelectClear.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.SelectClear.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectClear.Location = new System.Drawing.Point(114, 334);
            this.SelectClear.Name = "SelectClear";
            this.SelectClear.Size = new System.Drawing.Size(93, 26);
            this.SelectClear.TabIndex = 18;
            this.SelectClear.Text = "清除选择";
            this.SelectClear.UseVisualStyleBackColor = false;
            this.SelectClear.Click += new System.EventHandler(this.SelectClear_Click);
            // 
            // ClockDelete
            // 
            this.ClockDelete.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClockDelete.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClockDelete.Location = new System.Drawing.Point(500, 7);
            this.ClockDelete.Name = "ClockDelete";
            this.ClockDelete.Size = new System.Drawing.Size(93, 26);
            this.ClockDelete.TabIndex = 17;
            this.ClockDelete.Text = "删除闹钟";
            this.ClockDelete.UseVisualStyleBackColor = false;
            this.ClockDelete.Click += new System.EventHandler(this.ClockDelete_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.ClockTip);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.VoiceSelect);
            this.groupBox3.Controls.Add(this.ClockNoticeMode);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(12, 205);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(298, 123);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "提示设置";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(6, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 16);
            this.label10.TabIndex = 12;
            this.label10.Text = "提示内容";
            // 
            // ClockTip
            // 
            this.ClockTip.Location = new System.Drawing.Point(6, 90);
            this.ClockTip.Name = "ClockTip";
            this.ClockTip.Size = new System.Drawing.Size(286, 25);
            this.ClockTip.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(102, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 16);
            this.label9.TabIndex = 11;
            this.label9.Text = "语音选择";
            // 
            // VoiceSelect
            // 
            this.VoiceSelect.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.VoiceSelect.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VoiceSelect.FormattingEnabled = true;
            this.VoiceSelect.Items.AddRange(new object[] {
            "系统通知",
            "语音提示",
            "两者都有"});
            this.VoiceSelect.Location = new System.Drawing.Point(105, 42);
            this.VoiceSelect.Name = "VoiceSelect";
            this.VoiceSelect.Size = new System.Drawing.Size(187, 24);
            this.VoiceSelect.TabIndex = 10;
            // 
            // ClockNoticeMode
            // 
            this.ClockNoticeMode.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClockNoticeMode.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClockNoticeMode.FormattingEnabled = true;
            this.ClockNoticeMode.Items.AddRange(new object[] {
            "系统通知",
            "语音提示",
            "两者都有"});
            this.ClockNoticeMode.Location = new System.Drawing.Point(6, 42);
            this.ClockNoticeMode.Name = "ClockNoticeMode";
            this.ClockNoticeMode.Size = new System.Drawing.Size(87, 24);
            this.ClockNoticeMode.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(3, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "通知模式";
            // 
            // ClockAdd
            // 
            this.ClockAdd.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClockAdd.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClockAdd.Location = new System.Drawing.Point(12, 334);
            this.ClockAdd.Name = "ClockAdd";
            this.ClockAdd.Size = new System.Drawing.Size(93, 26);
            this.ClockAdd.TabIndex = 8;
            this.ClockAdd.Text = "添加闹钟";
            this.ClockAdd.UseVisualStyleBackColor = false;
            this.ClockAdd.Click += new System.EventHandler(this.ClockAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ClockTitle);
            this.groupBox2.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 58);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "闹钟备注";
            // 
            // ClockTitle
            // 
            this.ClockTitle.Location = new System.Drawing.Point(6, 24);
            this.ClockTitle.Name = "ClockTitle";
            this.ClockTitle.Size = new System.Drawing.Size(286, 25);
            this.ClockTitle.TabIndex = 7;
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.Controls.Add(this.ClockYear);
            this.GroupBox1.Controls.Add(this.ClockSecond);
            this.GroupBox1.Controls.Add(this.label1);
            this.GroupBox1.Controls.Add(this.ClockMinute);
            this.GroupBox1.Controls.Add(this.label2);
            this.GroupBox1.Controls.Add(this.ClockHour);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.ClockDay);
            this.GroupBox1.Controls.Add(this.label4);
            this.GroupBox1.Controls.Add(this.ClockMonth);
            this.GroupBox1.Controls.Add(this.label5);
            this.GroupBox1.Controls.Add(this.label7);
            this.GroupBox1.Controls.Add(this.label6);
            this.GroupBox1.Controls.Add(this.ClockWeek);
            this.GroupBox1.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GroupBox1.Location = new System.Drawing.Point(12, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(298, 122);
            this.GroupBox1.TabIndex = 14;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "时间选择";
            // 
            // ClockYear
            // 
            this.ClockYear.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClockYear.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClockYear.Location = new System.Drawing.Point(6, 43);
            this.ClockYear.Name = "ClockYear";
            this.ClockYear.Size = new System.Drawing.Size(37, 25);
            this.ClockYear.TabIndex = 0;
            // 
            // ClockSecond
            // 
            this.ClockSecond.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClockSecond.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClockSecond.FormattingEnabled = true;
            this.ClockSecond.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.ClockSecond.Location = new System.Drawing.Point(251, 43);
            this.ClockSecond.Name = "ClockSecond";
            this.ClockSecond.Size = new System.Drawing.Size(41, 24);
            this.ClockSecond.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "年";
            // 
            // ClockMinute
            // 
            this.ClockMinute.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClockMinute.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClockMinute.FormattingEnabled = true;
            this.ClockMinute.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.ClockMinute.Location = new System.Drawing.Point(201, 43);
            this.ClockMinute.Name = "ClockMinute";
            this.ClockMinute.Size = new System.Drawing.Size(41, 24);
            this.ClockMinute.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(49, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "月";
            // 
            // ClockHour
            // 
            this.ClockHour.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClockHour.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClockHour.FormattingEnabled = true;
            this.ClockHour.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.ClockHour.Location = new System.Drawing.Point(151, 43);
            this.ClockHour.Name = "ClockHour";
            this.ClockHour.Size = new System.Drawing.Size(41, 24);
            this.ClockHour.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(99, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "日";
            // 
            // ClockDay
            // 
            this.ClockDay.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClockDay.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClockDay.FormattingEnabled = true;
            this.ClockDay.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.ClockDay.Location = new System.Drawing.Point(102, 43);
            this.ClockDay.Name = "ClockDay";
            this.ClockDay.Size = new System.Drawing.Size(41, 24);
            this.ClockDay.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(148, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "时";
            // 
            // ClockMonth
            // 
            this.ClockMonth.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClockMonth.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClockMonth.FormattingEnabled = true;
            this.ClockMonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.ClockMonth.Location = new System.Drawing.Point(52, 43);
            this.ClockMonth.Name = "ClockMonth";
            this.ClockMonth.Size = new System.Drawing.Size(41, 24);
            this.ClockMonth.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(198, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "分";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(3, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "星期";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(248, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "秒";
            // 
            // ClockWeek
            // 
            this.ClockWeek.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClockWeek.CheckOnClick = true;
            this.ClockWeek.ColumnWidth = 40;
            this.ClockWeek.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClockWeek.FormattingEnabled = true;
            this.ClockWeek.Items.AddRange(new object[] {
            "一",
            "二",
            "三",
            "四",
            "五",
            "六",
            "天"});
            this.ClockWeek.Location = new System.Drawing.Point(6, 92);
            this.ClockWeek.MultiColumn = true;
            this.ClockWeek.Name = "ClockWeek";
            this.ClockWeek.Size = new System.Drawing.Size(286, 24);
            this.ClockWeek.TabIndex = 6;
            // 
            // AlarmClock
            // 
            this.AlarmClock.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.AlarmClock.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AlarmClock.FormattingEnabled = true;
            this.AlarmClock.ItemHeight = 16;
            this.AlarmClock.Location = new System.Drawing.Point(327, 45);
            this.AlarmClock.Name = "AlarmClock";
            this.AlarmClock.Size = new System.Drawing.Size(366, 340);
            this.AlarmClock.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(324, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 16);
            this.label11.TabIndex = 13;
            this.label11.Text = "闹钟列表";
            // 
            // DCPClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(704, 396);
            this.Controls.Add(this.ClockPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DCPClock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DCPClock";
            this.Load += new System.EventHandler(this.DCPClock_Load);
            this.ClockPanel.ResumeLayout(false);
            this.ClockPanel.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ClockPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ClockYear;
        private System.Windows.Forms.CheckedListBox ClockWeek;
        private System.Windows.Forms.ComboBox ClockMonth;
        private System.Windows.Forms.ComboBox ClockDay;
        private System.Windows.Forms.ComboBox ClockSecond;
        private System.Windows.Forms.ComboBox ClockMinute;
        private System.Windows.Forms.ComboBox ClockHour;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox ClockTitle;
        private System.Windows.Forms.Button ClockAdd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox ClockNoticeMode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox VoiceSelect;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox ClockTip;
        private System.Windows.Forms.Button ClockClose;
        private System.Windows.Forms.Button Help;
        private System.Windows.Forms.Button ClockEdit;
        private System.Windows.Forms.Button SelectClear;
        private System.Windows.Forms.Button ClockDelete;
        private System.Windows.Forms.LinkLabel Github;
        private System.Windows.Forms.LinkLabel Bilibili;
        private System.Windows.Forms.LinkLabel Mail;
        private System.Windows.Forms.ListBox AlarmClock;
        private System.Windows.Forms.Label label11;
    }
}