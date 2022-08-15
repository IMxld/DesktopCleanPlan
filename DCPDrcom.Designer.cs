
namespace DesktopCleanPlan
{
    partial class DCPDrcom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCPDrcom));
            this.DCPDrcomSave = new System.Windows.Forms.Button();
            this.DCPDrcomUser = new System.Windows.Forms.TextBox();
            this.DCPDrcomPasswd = new System.Windows.Forms.TextBox();
            this.DCPDrcomRetry = new System.Windows.Forms.Button();
            this.Notice = new System.Windows.Forms.LinkLabel();
            this.User = new System.Windows.Forms.Label();
            this.Pass = new System.Windows.Forms.Label();
            this.Github = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DCPDrcomSave
            // 
            this.DCPDrcomSave.Location = new System.Drawing.Point(318, 253);
            this.DCPDrcomSave.Name = "DCPDrcomSave";
            this.DCPDrcomSave.Size = new System.Drawing.Size(91, 32);
            this.DCPDrcomSave.TabIndex = 0;
            this.DCPDrcomSave.Text = "保存并关闭";
            this.DCPDrcomSave.UseVisualStyleBackColor = true;
            this.DCPDrcomSave.Click += new System.EventHandler(this.DCPDrcomSave_Click);
            // 
            // DCPDrcomUser
            // 
            this.DCPDrcomUser.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DCPDrcomUser.Location = new System.Drawing.Point(258, 179);
            this.DCPDrcomUser.Name = "DCPDrcomUser";
            this.DCPDrcomUser.Size = new System.Drawing.Size(151, 31);
            this.DCPDrcomUser.TabIndex = 2;
            // 
            // DCPDrcomPasswd
            // 
            this.DCPDrcomPasswd.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DCPDrcomPasswd.Location = new System.Drawing.Point(258, 216);
            this.DCPDrcomPasswd.Name = "DCPDrcomPasswd";
            this.DCPDrcomPasswd.PasswordChar = '*';
            this.DCPDrcomPasswd.Size = new System.Drawing.Size(151, 31);
            this.DCPDrcomPasswd.TabIndex = 3;
            // 
            // DCPDrcomRetry
            // 
            this.DCPDrcomRetry.Location = new System.Drawing.Point(258, 253);
            this.DCPDrcomRetry.Name = "DCPDrcomRetry";
            this.DCPDrcomRetry.Size = new System.Drawing.Size(54, 32);
            this.DCPDrcomRetry.TabIndex = 4;
            this.DCPDrcomRetry.Text = "重连";
            this.DCPDrcomRetry.UseVisualStyleBackColor = true;
            this.DCPDrcomRetry.Click += new System.EventHandler(this.DCPDrcomRetry_Click);
            // 
            // Notice
            // 
            this.Notice.AutoSize = true;
            this.Notice.Location = new System.Drawing.Point(356, 155);
            this.Notice.Name = "Notice";
            this.Notice.Size = new System.Drawing.Size(53, 12);
            this.Notice.TabIndex = 5;
            this.Notice.TabStop = true;
            this.Notice.Text = "免责声明";
            this.Notice.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Notice_LinkClicked);
            // 
            // User
            // 
            this.User.AutoSize = true;
            this.User.BackColor = System.Drawing.Color.Transparent;
            this.User.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.User.Location = new System.Drawing.Point(212, 194);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(40, 16);
            this.User.TabIndex = 6;
            this.User.Text = "账户";
            // 
            // Pass
            // 
            this.Pass.AutoSize = true;
            this.Pass.BackColor = System.Drawing.Color.Transparent;
            this.Pass.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Pass.Location = new System.Drawing.Point(212, 231);
            this.Pass.Name = "Pass";
            this.Pass.Size = new System.Drawing.Size(40, 16);
            this.Pass.TabIndex = 7;
            this.Pass.Text = "密码";
            // 
            // Github
            // 
            this.Github.AutoSize = true;
            this.Github.Location = new System.Drawing.Point(368, 132);
            this.Github.Name = "Github";
            this.Github.Size = new System.Drawing.Size(41, 12);
            this.Github.TabIndex = 8;
            this.Github.TabStop = true;
            this.Github.Text = "GIthub";
            this.Github.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Github_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(2, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "*账户和密码栏全留空即为不使用该功能";
            // 
            // DCPDrcom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(421, 297);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Github);
            this.Controls.Add(this.Pass);
            this.Controls.Add(this.User);
            this.Controls.Add(this.Notice);
            this.Controls.Add(this.DCPDrcomRetry);
            this.Controls.Add(this.DCPDrcomPasswd);
            this.Controls.Add(this.DCPDrcomUser);
            this.Controls.Add(this.DCPDrcomSave);
            this.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DCPDrcom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DCPDrcom";
            this.Load += new System.EventHandler(this.DCPDrcom_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DCPDrcom_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DCPDrcomSave;
        private System.Windows.Forms.TextBox DCPDrcomUser;
        private System.Windows.Forms.TextBox DCPDrcomPasswd;
        private System.Windows.Forms.Button DCPDrcomRetry;
        private System.Windows.Forms.LinkLabel Notice;
        private System.Windows.Forms.Label User;
        private System.Windows.Forms.Label Pass;
        private System.Windows.Forms.LinkLabel Github;
        private System.Windows.Forms.Label label1;
    }
}