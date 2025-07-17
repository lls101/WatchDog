namespace WatchDog.UI
{
    partial class frmTaskSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaskSetting));
            this.sysBar = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.tbLibPath = new System.Windows.Forms.TextBox();
            this.btnEnv = new System.Windows.Forms.Button();
            this.tbSysPath = new System.Windows.Forms.TextBox();
            this.tbEnv = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtTime = new System.Windows.Forms.DateTimePicker();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rb_Day = new System.Windows.Forms.RadioButton();
            this.rb_Week = new System.Windows.Forms.RadioButton();
            this.rb_Month = new System.Windows.Forms.RadioButton();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.comDate = new System.Windows.Forms.ComboBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSelectApp = new System.Windows.Forms.Button();
            this.sysBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // sysBar
            // 
            this.sysBar.AutoSize = false;
            this.sysBar.BackColor = System.Drawing.Color.Transparent;
            this.sysBar.Font = new System.Drawing.Font("黑体", 12F);
            this.sysBar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.sysBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator10,
            this.btnCancle,
            this.toolStripSeparator8,
            this.btnSave,
            this.toolStripSeparator1});
            this.sysBar.Location = new System.Drawing.Point(0, 0);
            this.sysBar.Margin = new System.Windows.Forms.Padding(20);
            this.sysBar.Name = "sysBar";
            this.sysBar.Padding = new System.Windows.Forms.Padding(3);
            this.sysBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.sysBar.Size = new System.Drawing.Size(390, 40);
            this.sysBar.TabIndex = 11;
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 34);
            // 
            // btnCancle
            // 
            this.btnCancle.Image = global::WatchDog.Properties.Resources.exit;
            this.btnCancle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 31);
            this.btnCancle.Text = "退出";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 34);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::WatchDog.Properties.Resources.save;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 31);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnSelectApp);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbLibPath);
            this.panel1.Controls.Add(this.btnEnv);
            this.panel1.Controls.Add(this.tbSysPath);
            this.panel1.Controls.Add(this.tbEnv);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.dtTime);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.tbPath);
            this.panel1.Controls.Add(this.comDate);
            this.panel1.Controls.Add(this.tbDescription);
            this.panel1.Controls.Add(this.tbName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 556);
            this.panel1.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("黑体", 10F);
            this.label6.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label6.Location = new System.Drawing.Point(154, 355);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 14);
            this.label6.TabIndex = 24;
            this.label6.Text = "多条路径之间请用\';\'分割";
            // 
            // tbLibPath
            // 
            this.tbLibPath.Location = new System.Drawing.Point(151, 300);
            this.tbLibPath.MaxLength = 100;
            this.tbLibPath.Multiline = true;
            this.tbLibPath.Name = "tbLibPath";
            this.tbLibPath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLibPath.Size = new System.Drawing.Size(186, 46);
            this.tbLibPath.TabIndex = 6;
            // 
            // btnEnv
            // 
            this.btnEnv.Location = new System.Drawing.Point(36, 181);
            this.btnEnv.Name = "btnEnv";
            this.btnEnv.Size = new System.Drawing.Size(63, 43);
            this.btnEnv.TabIndex = 4;
            this.btnEnv.Text = "环境\r\n变量";
            this.btnEnv.UseVisualStyleBackColor = true;
            this.btnEnv.Click += new System.EventHandler(this.btnEnv_Click);
            // 
            // tbSysPath
            // 
            this.tbSysPath.Location = new System.Drawing.Point(153, 236);
            this.tbSysPath.MaxLength = 100;
            this.tbSysPath.Multiline = true;
            this.tbSysPath.Name = "tbSysPath";
            this.tbSysPath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbSysPath.Size = new System.Drawing.Size(186, 46);
            this.tbSysPath.TabIndex = 5;
            // 
            // tbEnv
            // 
            this.tbEnv.Location = new System.Drawing.Point(155, 178);
            this.tbEnv.MaxLength = 100;
            this.tbEnv.Multiline = true;
            this.tbEnv.Name = "tbEnv";
            this.tbEnv.ReadOnly = true;
            this.tbEnv.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbEnv.Size = new System.Drawing.Size(184, 46);
            this.tbEnv.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 320);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "LD_LIBRARY_PATH";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(59, 257);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "PATH";
            // 
            // dtTime
            // 
            this.dtTime.CustomFormat = "HH:mm:ss";
            this.dtTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtTime.Location = new System.Drawing.Point(161, 479);
            this.dtTime.MaxDate = new System.DateTime(2500, 12, 31, 0, 0, 0, 0);
            this.dtTime.MinDate = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            this.dtTime.Name = "dtTime";
            this.dtTime.ShowUpDown = true;
            this.dtTime.Size = new System.Drawing.Size(133, 26);
            this.dtTime.TabIndex = 9;
            this.dtTime.Value = new System.DateTime(2024, 12, 24, 0, 0, 0, 0);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rb_Day);
            this.panel4.Controls.Add(this.rb_Week);
            this.panel4.Controls.Add(this.rb_Month);
            this.panel4.Location = new System.Drawing.Point(161, 385);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(188, 47);
            this.panel4.TabIndex = 7;
            // 
            // rb_Day
            // 
            this.rb_Day.AutoSize = true;
            this.rb_Day.Location = new System.Drawing.Point(16, 12);
            this.rb_Day.Name = "rb_Day";
            this.rb_Day.Size = new System.Drawing.Size(41, 20);
            this.rb_Day.TabIndex = 2;
            this.rb_Day.TabStop = true;
            this.rb_Day.Text = "天";
            this.rb_Day.UseVisualStyleBackColor = true;
            this.rb_Day.CheckedChanged += new System.EventHandler(this.rb_Cycle_CheckedChanged);
            // 
            // rb_Week
            // 
            this.rb_Week.AutoSize = true;
            this.rb_Week.Location = new System.Drawing.Point(75, 12);
            this.rb_Week.Name = "rb_Week";
            this.rb_Week.Size = new System.Drawing.Size(41, 20);
            this.rb_Week.TabIndex = 2;
            this.rb_Week.TabStop = true;
            this.rb_Week.Text = "周";
            this.rb_Week.UseVisualStyleBackColor = true;
            this.rb_Week.CheckedChanged += new System.EventHandler(this.rb_Cycle_CheckedChanged);
            // 
            // rb_Month
            // 
            this.rb_Month.AutoSize = true;
            this.rb_Month.Location = new System.Drawing.Point(132, 12);
            this.rb_Month.Name = "rb_Month";
            this.rb_Month.Size = new System.Drawing.Size(41, 20);
            this.rb_Month.TabIndex = 2;
            this.rb_Month.TabStop = true;
            this.rb_Month.Text = "月";
            this.rb_Month.UseVisualStyleBackColor = true;
            this.rb_Month.CheckedChanged += new System.EventHandler(this.rb_Cycle_CheckedChanged);
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(151, 57);
            this.tbPath.MaxLength = 100;
            this.tbPath.Multiline = true;
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(186, 43);
            this.tbPath.TabIndex = 2;
            // 
            // comDate
            // 
            this.comDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comDate.FormattingEnabled = true;
            this.comDate.Location = new System.Drawing.Point(161, 443);
            this.comDate.Name = "comDate";
            this.comDate.Size = new System.Drawing.Size(133, 24);
            this.comDate.TabIndex = 8;
            this.comDate.SelectedIndexChanged += new System.EventHandler(this.comDate_SelectedIndexChanged);
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(155, 119);
            this.tbDescription.MaxLength = 100;
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(186, 46);
            this.tbDescription.TabIndex = 3;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(153, 25);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(186, 26);
            this.tbName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 486);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "*执行时间";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 446);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "*执行日期";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 400);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "*执行周期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "*任务目录";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(56, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "*任务描述";
            // 
            // btnSelectApp
            // 
            this.btnSelectApp.AutoSize = true;
            this.btnSelectApp.Location = new System.Drawing.Point(30, 23);
            this.btnSelectApp.Name = "btnSelectApp";
            this.btnSelectApp.Size = new System.Drawing.Size(105, 26);
            this.btnSelectApp.TabIndex = 25;
            this.btnSelectApp.Text = "*任务名称..";
            this.btnSelectApp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectApp.UseVisualStyleBackColor = true;
            this.btnSelectApp.Click += new System.EventHandler(this.btnSelectApp_Click);
            // 
            // frmTaskSetting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(390, 596);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sysBar);
            this.Font = new System.Drawing.Font("黑体", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTaskSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "计划任务维护界面";
            this.Load += new System.EventHandler(this.frmTaskSetting_Load);
            this.sysBar.ResumeLayout(false);
            this.sysBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip sysBar;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton btnCancle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rb_Month;
        private System.Windows.Forms.RadioButton rb_Week;
        private System.Windows.Forms.RadioButton rb_Day;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker dtTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbLibPath;
        private System.Windows.Forms.Button btnEnv;
        private System.Windows.Forms.TextBox tbSysPath;
        private System.Windows.Forms.TextBox tbEnv;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSelectApp;
    }
}