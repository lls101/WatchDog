namespace WatchDog.UI
{
    partial class frmAppSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppSetting));
            this.sysBar = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbMemMax = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCPUMax = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lable1 = new System.Windows.Forms.Label();
            this.btnSelectApp = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbLibPath = new System.Windows.Forms.TextBox();
            this.btn61850 = new System.Windows.Forms.Button();
            this.btnEnv = new System.Windows.Forms.Button();
            this.tbSysPath = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rbAutoNo = new System.Windows.Forms.RadioButton();
            this.rbAutoYes = new System.Windows.Forms.RadioButton();
            this.tbEnv = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbPath = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbJava = new System.Windows.Forms.RadioButton();
            this.rb61850 = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.sysBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.btnSave});
            this.sysBar.Location = new System.Drawing.Point(0, 0);
            this.sysBar.Margin = new System.Windows.Forms.Padding(20);
            this.sysBar.Name = "sysBar";
            this.sysBar.Padding = new System.Windows.Forms.Padding(3);
            this.sysBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.sysBar.Size = new System.Drawing.Size(477, 43);
            this.sysBar.TabIndex = 12;
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 37);
            // 
            // btnCancle
            // 
            this.btnCancle.Image = global::WatchDog.Properties.Resources.exit;
            this.btnCancle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 34);
            this.btnCancle.Text = "退出";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 37);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::WatchDog.Properties.Resources.save;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 34);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tbMemMax);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbCPUMax);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lable1);
            this.panel1.Controls.Add(this.btnSelectApp);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbLibPath);
            this.panel1.Controls.Add(this.btn61850);
            this.panel1.Controls.Add(this.btnEnv);
            this.panel1.Controls.Add(this.tbSysPath);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.tbEnv);
            this.panel1.Controls.Add(this.tbDescription);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.tbPath);
            this.panel1.Controls.Add(this.tbName);
            this.panel1.Controls.Add(this.lbPath);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 581);
            this.panel1.TabIndex = 13;
            // 
            // tbMemMax
            // 
            this.tbMemMax.Location = new System.Drawing.Point(297, 171);
            this.tbMemMax.MaxLength = 100;
            this.tbMemMax.Name = "tbMemMax";
            this.tbMemMax.Size = new System.Drawing.Size(52, 26);
            this.tbMemMax.TabIndex = 18;
            this.tbMemMax.Text = "80";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "内存(max)";
            // 
            // tbCPUMax
            // 
            this.tbCPUMax.Location = new System.Drawing.Point(145, 171);
            this.tbCPUMax.MaxLength = 100;
            this.tbCPUMax.Name = "tbCPUMax";
            this.tbCPUMax.Size = new System.Drawing.Size(52, 26);
            this.tbCPUMax.TabIndex = 16;
            this.tbCPUMax.Text = "50";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(355, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "%";
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Location = new System.Drawing.Point(54, 175);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(71, 16);
            this.lable1.TabIndex = 17;
            this.lable1.Text = "CPU(max)";
            // 
            // btnSelectApp
            // 
            this.btnSelectApp.AutoSize = true;
            this.btnSelectApp.Location = new System.Drawing.Point(20, 26);
            this.btnSelectApp.Name = "btnSelectApp";
            this.btnSelectApp.Size = new System.Drawing.Size(105, 26);
            this.btnSelectApp.TabIndex = 14;
            this.btnSelectApp.Text = "*服务名称..";
            this.btnSelectApp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectApp.UseVisualStyleBackColor = true;
            this.btnSelectApp.Click += new System.EventHandler(this.btnSelectApp_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("黑体", 10F);
            this.label9.ForeColor = System.Drawing.Color.Fuchsia;
            this.label9.Location = new System.Drawing.Point(46, 214);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(413, 14);
            this.label9.TabIndex = 13;
            this.label9.Text = "超过设置上限时手动运行方式停止服务，自动运行方式重启服务。";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("黑体", 10F);
            this.label6.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label6.Location = new System.Drawing.Point(166, 556);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 14);
            this.label6.TabIndex = 13;
            this.label6.Text = "多条路径之间请用\';\'分割";
            // 
            // tbLibPath
            // 
            this.tbLibPath.Location = new System.Drawing.Point(153, 504);
            this.tbLibPath.MaxLength = 100;
            this.tbLibPath.Multiline = true;
            this.tbLibPath.Name = "tbLibPath";
            this.tbLibPath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLibPath.Size = new System.Drawing.Size(204, 46);
            this.tbLibPath.TabIndex = 6;
            // 
            // btn61850
            // 
            this.btn61850.Location = new System.Drawing.Point(379, 391);
            this.btn61850.Name = "btn61850";
            this.btn61850.Size = new System.Drawing.Size(56, 26);
            this.btn61850.TabIndex = 12;
            this.btn61850.Text = "61850配置";
            this.btn61850.UseVisualStyleBackColor = true;
            this.btn61850.Visible = false;
            this.btn61850.Click += new System.EventHandler(this.btn61850_Click);
            // 
            // btnEnv
            // 
            this.btnEnv.Location = new System.Drawing.Point(70, 383);
            this.btnEnv.Name = "btnEnv";
            this.btnEnv.Size = new System.Drawing.Size(63, 43);
            this.btnEnv.TabIndex = 4;
            this.btnEnv.Text = "环境\r\n变量";
            this.btnEnv.UseVisualStyleBackColor = true;
            this.btnEnv.Click += new System.EventHandler(this.btnEnv_Click);
            // 
            // tbSysPath
            // 
            this.tbSysPath.Location = new System.Drawing.Point(153, 440);
            this.tbSysPath.MaxLength = 100;
            this.tbSysPath.Multiline = true;
            this.tbSysPath.Name = "tbSysPath";
            this.tbSysPath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbSysPath.Size = new System.Drawing.Size(204, 46);
            this.tbSysPath.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rbAutoNo);
            this.panel4.Controls.Add(this.rbAutoYes);
            this.panel4.Location = new System.Drawing.Point(145, 247);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(225, 41);
            this.panel4.TabIndex = 11;
            // 
            // rbAutoNo
            // 
            this.rbAutoNo.AutoSize = true;
            this.rbAutoNo.Checked = true;
            this.rbAutoNo.Location = new System.Drawing.Point(102, 10);
            this.rbAutoNo.Name = "rbAutoNo";
            this.rbAutoNo.Size = new System.Drawing.Size(57, 20);
            this.rbAutoNo.TabIndex = 12;
            this.rbAutoNo.TabStop = true;
            this.rbAutoNo.Text = "手动";
            this.rbAutoNo.UseVisualStyleBackColor = true;
            // 
            // rbAutoYes
            // 
            this.rbAutoYes.AutoSize = true;
            this.rbAutoYes.Location = new System.Drawing.Point(18, 11);
            this.rbAutoYes.Name = "rbAutoYes";
            this.rbAutoYes.Size = new System.Drawing.Size(57, 20);
            this.rbAutoYes.TabIndex = 13;
            this.rbAutoYes.Text = "自动";
            this.rbAutoYes.UseVisualStyleBackColor = true;
            // 
            // tbEnv
            // 
            this.tbEnv.Location = new System.Drawing.Point(153, 382);
            this.tbEnv.MaxLength = 100;
            this.tbEnv.Multiline = true;
            this.tbEnv.Name = "tbEnv";
            this.tbEnv.ReadOnly = true;
            this.tbEnv.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbEnv.Size = new System.Drawing.Size(204, 46);
            this.tbEnv.TabIndex = 10;
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(145, 113);
            this.tbDescription.MaxLength = 100;
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(204, 46);
            this.tbDescription.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(46, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "*服务描述";
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(145, 73);
            this.tbPath.MaxLength = 100;
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(204, 26);
            this.tbPath.TabIndex = 2;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(145, 26);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(204, 26);
            this.tbName.TabIndex = 1;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // lbPath
            // 
            this.lbPath.AutoSize = true;
            this.lbPath.Location = new System.Drawing.Point(46, 77);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(79, 16);
            this.lbPath.TabIndex = 4;
            this.lbPath.Text = "*服务目录";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 521);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "LD_LIBRARY_PATH";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "PATH";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "运行方式";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbJava);
            this.panel2.Controls.Add(this.rb61850);
            this.panel2.Location = new System.Drawing.Point(145, 304);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(225, 41);
            this.panel2.TabIndex = 11;
            // 
            // rbJava
            // 
            this.rbJava.AutoSize = true;
            this.rbJava.Location = new System.Drawing.Point(124, 11);
            this.rbJava.Name = "rbJava";
            this.rbJava.Size = new System.Drawing.Size(89, 20);
            this.rbJava.TabIndex = 12;
            this.rbJava.Text = "Java服务";
            this.rbJava.UseVisualStyleBackColor = true;
            // 
            // rb61850
            // 
            this.rb61850.AutoSize = true;
            this.rb61850.Location = new System.Drawing.Point(18, 11);
            this.rb61850.Name = "rb61850";
            this.rb61850.Size = new System.Drawing.Size(97, 20);
            this.rb61850.TabIndex = 13;
            this.rb61850.Text = "61850服务";
            this.rb61850.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(46, 315);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 16);
            this.label10.TabIndex = 5;
            this.label10.Text = "特殊项设置";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("黑体", 10F);
            this.label11.ForeColor = System.Drawing.Color.Fuchsia;
            this.label11.Location = new System.Drawing.Point(46, 353);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(406, 14);
            this.label11.TabIndex = 13;
            this.label11.Text = "设置为Java服务时,一旦超限会将所有java程序退出,请谨慎设置!";
            // 
            // frmAppSetting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(477, 624);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sysBar);
            this.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAppSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "常驻服务维护界面";
            this.Load += new System.EventHandler(this.frmAppSetting_Load);
            this.sysBar.ResumeLayout(false);
            this.sysBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip sysBar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton btnCancle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbPath;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rbAutoNo;
        private System.Windows.Forms.RadioButton rbAutoYes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEnv;
        private System.Windows.Forms.TextBox tbLibPath;
        private System.Windows.Forms.TextBox tbSysPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbEnv;
        private System.Windows.Forms.Button btn61850;
        private System.Windows.Forms.Button btnSelectApp;
        private System.Windows.Forms.TextBox tbMemMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCPUMax;
        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbJava;
        private System.Windows.Forms.RadioButton rb61850;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}