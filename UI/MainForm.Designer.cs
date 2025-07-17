namespace WatchDog
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.lbTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbCPU = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbMem = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbDisc = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.toolSysBar = new System.Windows.Forms.ToolStrip();
            this.btnTitle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAdd = new System.Windows.Forms.ToolStripSplitButton();
            this.add_App = new System.Windows.Forms.ToolStripMenuItem();
            this.add_Task = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSetting = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolSize = new System.Windows.Forms.ToolStrip();
            this.btnMin = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.gbApp = new System.Windows.Forms.GroupBox();
            this.dgvApp = new System.Windows.Forms.DataGridView();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRunningStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsRunning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbPTask = new System.Windows.Forms.GroupBox();
            this.dgvTask = new System.Windows.Forms.DataGridView();
            this.colTaskDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTaskCycle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTaskDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTaskRunTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTaskPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTaskIsRunning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.show = new System.Windows.Forms.ToolStripMenuItem();
            this.hide = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.timer_HardInfor = new System.Windows.Forms.Timer(this.components);
            this.timer_AppStatus = new System.Windows.Forms.Timer(this.components);
            this.StatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.toolSysBar.SuspendLayout();
            this.toolSize.SuspendLayout();
            this.gbApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApp)).BeginInit();
            this.gbPTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTask)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusBar
            // 
            this.StatusBar.AutoSize = false;
            this.StatusBar.BackColor = System.Drawing.Color.LightCyan;
            this.StatusBar.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StatusBar.GripMargin = new System.Windows.Forms.Padding(20);
            this.StatusBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.StatusBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbTime,
            this.lbCPU,
            this.lbMem,
            this.lbDisc});
            this.StatusBar.Location = new System.Drawing.Point(0, 568);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(800, 32);
            this.StatusBar.SizingGrip = false;
            this.StatusBar.TabIndex = 7;
            // 
            // lbTime
            // 
            this.lbTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lbTime.Font = new System.Drawing.Font("黑体", 10F);
            this.lbTime.Image = global::WatchDog.Properties.Resources.kalarm;
            this.lbTime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(56, 27);
            this.lbTime.Text = "---";
            this.lbTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCPU
            // 
            this.lbCPU.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lbCPU.Font = new System.Drawing.Font("黑体", 10F);
            this.lbCPU.Name = "lbCPU";
            this.lbCPU.Size = new System.Drawing.Size(39, 27);
            this.lbCPU.Text = "CPU:";
            // 
            // lbMem
            // 
            this.lbMem.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lbMem.Font = new System.Drawing.Font("黑体", 10F);
            this.lbMem.Name = "lbMem";
            this.lbMem.Size = new System.Drawing.Size(39, 27);
            this.lbMem.Text = "MEM:";
            // 
            // lbDisc
            // 
            this.lbDisc.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lbDisc.Font = new System.Drawing.Font("黑体", 10F);
            this.lbDisc.Name = "lbDisc";
            this.lbDisc.Size = new System.Drawing.Size(46, 27);
            this.lbDisc.Text = "DISC:";
            // 
            // splitMain
            // 
            this.splitMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.toolSysBar);
            this.splitMain.Panel1.Controls.Add(this.toolSize);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.gbApp);
            this.splitMain.Panel2.Controls.Add(this.gbPTask);
            this.splitMain.Size = new System.Drawing.Size(800, 568);
            this.splitMain.TabIndex = 8;
            // 
            // toolSysBar
            // 
            this.toolSysBar.AutoSize = false;
            this.toolSysBar.BackColor = System.Drawing.Color.Transparent;
            this.toolSysBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolSysBar.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolSysBar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolSysBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTitle,
            this.toolStripSeparator1,
            this.btnStart,
            this.toolStripSeparator2,
            this.btnStop,
            this.toolStripSeparator4,
            this.btnAdd,
            this.toolStripSeparator7,
            this.btnDel,
            this.toolStripSeparator9,
            this.btnExit,
            this.toolStripSeparator10,
            this.btnSetting,
            this.toolStripSeparator8});
            this.toolSysBar.Location = new System.Drawing.Point(0, 0);
            this.toolSysBar.Margin = new System.Windows.Forms.Padding(20);
            this.toolSysBar.Name = "toolSysBar";
            this.toolSysBar.Padding = new System.Windows.Forms.Padding(3);
            this.toolSysBar.Size = new System.Drawing.Size(684, 46);
            this.toolSysBar.TabIndex = 10;
            this.toolSysBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolSysBar_MouseDown);
            this.toolSysBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolSysBar_MouseMove);
            this.toolSysBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolSysBar_MouseUp);
            // 
            // btnTitle
            // 
            this.btnTitle.Font = new System.Drawing.Font("黑体", 12F);
            this.btnTitle.Image = global::WatchDog.Properties.Resources.appIcon;
            this.btnTitle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTitle.Name = "btnTitle";
            this.btnTitle.Size = new System.Drawing.Size(107, 37);
            this.btnTitle.Text = "服务监控";
            this.btnTitle.ToolTipText = "进程监控";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Font = new System.Drawing.Font("黑体", 13F);
            this.btnStart.Image = global::WatchDog.Properties.Resources.start;
            this.btnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(116, 37);
            this.btnStart.Text = "启动服务";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("黑体", 13F);
            this.btnStop.Image = global::WatchDog.Properties.Resources.stop;
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(116, 37);
            this.btnStop.Text = "停止服务";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 40);
            // 
            // btnAdd
            // 
            this.btnAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.add_App,
            this.add_Task});
            this.btnAdd.Font = new System.Drawing.Font("黑体", 13F);
            this.btnAdd.Image = global::WatchDog.Properties.Resources.add;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 37);
            this.btnAdd.Text = "新增";
            // 
            // add_App
            // 
            this.add_App.Font = new System.Drawing.Font("黑体", 12F);
            this.add_App.Name = "add_App";
            this.add_App.Size = new System.Drawing.Size(139, 22);
            this.add_App.Text = "常驻服务";
            this.add_App.Click += new System.EventHandler(this.add_App_Click);
            // 
            // add_Task
            // 
            this.add_Task.Font = new System.Drawing.Font("黑体", 12F);
            this.add_Task.Name = "add_Task";
            this.add_Task.Size = new System.Drawing.Size(139, 22);
            this.add_Task.Text = "计划任务";
            this.add_Task.Click += new System.EventHandler(this.add_Task_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 40);
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("黑体", 13F);
            this.btnDel.Image = global::WatchDog.Properties.Resources.del;
            this.btnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(80, 37);
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 40);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("黑体", 13F);
            this.btnExit.Image = global::WatchDog.Properties.Resources.exit;
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 37);
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 40);
            this.toolStripSeparator10.Visible = false;
            // 
            // btnSetting
            // 
            this.btnSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSetting.Font = new System.Drawing.Font("黑体", 12F);
            this.btnSetting.Image = global::WatchDog.Properties.Resources.setting;
            this.btnSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(36, 37);
            this.btnSetting.Text = "系统设置";
            this.btnSetting.Visible = false;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 40);
            // 
            // toolSize
            // 
            this.toolSize.BackColor = System.Drawing.Color.Transparent;
            this.toolSize.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolSize.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolSize.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMin,
            this.btnClose});
            this.toolSize.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolSize.Location = new System.Drawing.Point(684, 0);
            this.toolSize.Name = "toolSize";
            this.toolSize.Size = new System.Drawing.Size(112, 46);
            this.toolSize.TabIndex = 9;
            // 
            // btnMin
            // 
            this.btnMin.AutoSize = false;
            this.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMin.Font = new System.Drawing.Font("黑体", 15F);
            this.btnMin.Image = global::WatchDog.Properties.Resources.min;
            this.btnMin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(50, 45);
            this.btnMin.Text = "最小化";
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = false;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClose.Image = global::WatchDog.Properties.Resources.X;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(50, 45);
            this.btnClose.Text = "toolStripButton2";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbApp
            // 
            this.gbApp.Controls.Add(this.dgvApp);
            this.gbApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbApp.Location = new System.Drawing.Point(0, 0);
            this.gbApp.Name = "gbApp";
            this.gbApp.Size = new System.Drawing.Size(796, 300);
            this.gbApp.TabIndex = 1;
            this.gbApp.TabStop = false;
            this.gbApp.Text = "常驻服务";
            // 
            // dgvApp
            // 
            this.dgvApp.AllowUserToAddRows = false;
            this.dgvApp.BackgroundColor = System.Drawing.Color.LightCyan;
            this.dgvApp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDescription,
            this.colRunningStatus,
            this.colAppName,
            this.colAppPath,
            this.colIsRunning});
            this.dgvApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvApp.Location = new System.Drawing.Point(3, 22);
            this.dgvApp.Name = "dgvApp";
            this.dgvApp.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApp.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvApp.RowHeadersVisible = false;
            this.dgvApp.RowTemplate.Height = 23;
            this.dgvApp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApp.Size = new System.Drawing.Size(790, 275);
            this.dgvApp.TabIndex = 0;
            this.dgvApp.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvApp_CellMouseClick);
            // 
            // colDescription
            // 
            this.colDescription.HeaderText = "服务描述";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 200;
            // 
            // colRunningStatus
            // 
            this.colRunningStatus.HeaderText = "运行状态";
            this.colRunningStatus.Name = "colRunningStatus";
            this.colRunningStatus.ReadOnly = true;
            // 
            // colAppName
            // 
            this.colAppName.HeaderText = "服务名称";
            this.colAppName.Name = "colAppName";
            this.colAppName.ReadOnly = true;
            this.colAppName.Width = 120;
            // 
            // colAppPath
            // 
            this.colAppPath.HeaderText = "服务目录";
            this.colAppPath.Name = "colAppPath";
            this.colAppPath.ReadOnly = true;
            this.colAppPath.Width = 240;
            // 
            // colIsRunning
            // 
            this.colIsRunning.HeaderText = "是否运行";
            this.colIsRunning.Name = "colIsRunning";
            this.colIsRunning.ReadOnly = true;
            this.colIsRunning.Visible = false;
            // 
            // gbPTask
            // 
            this.gbPTask.Controls.Add(this.dgvTask);
            this.gbPTask.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbPTask.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbPTask.Location = new System.Drawing.Point(0, 300);
            this.gbPTask.Name = "gbPTask";
            this.gbPTask.Size = new System.Drawing.Size(796, 210);
            this.gbPTask.TabIndex = 0;
            this.gbPTask.TabStop = false;
            this.gbPTask.Text = "计划任务";
            // 
            // dgvTask
            // 
            this.dgvTask.AllowUserToAddRows = false;
            this.dgvTask.BackgroundColor = System.Drawing.Color.LightCyan;
            this.dgvTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTask.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTaskDescription,
            this.colTaskName,
            this.colTaskCycle,
            this.colTaskDate,
            this.colTaskRunTime,
            this.colTaskPath,
            this.colTaskIsRunning});
            this.dgvTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTask.Location = new System.Drawing.Point(3, 22);
            this.dgvTask.Name = "dgvTask";
            this.dgvTask.ReadOnly = true;
            this.dgvTask.RowHeadersVisible = false;
            this.dgvTask.RowTemplate.Height = 23;
            this.dgvTask.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTask.Size = new System.Drawing.Size(790, 185);
            this.dgvTask.TabIndex = 1;
            this.dgvTask.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTask_CellMouseClick);
            // 
            // colTaskDescription
            // 
            this.colTaskDescription.HeaderText = "任务描述";
            this.colTaskDescription.Name = "colTaskDescription";
            this.colTaskDescription.ReadOnly = true;
            // 
            // colTaskName
            // 
            this.colTaskName.HeaderText = "任务名称";
            this.colTaskName.Name = "colTaskName";
            this.colTaskName.ReadOnly = true;
            // 
            // colTaskCycle
            // 
            this.colTaskCycle.HeaderText = "任务周期";
            this.colTaskCycle.Name = "colTaskCycle";
            this.colTaskCycle.ReadOnly = true;
            this.colTaskCycle.Width = 120;
            // 
            // colTaskDate
            // 
            this.colTaskDate.HeaderText = "执行日期";
            this.colTaskDate.Name = "colTaskDate";
            this.colTaskDate.ReadOnly = true;
            // 
            // colTaskRunTime
            // 
            this.colTaskRunTime.HeaderText = "执行时间";
            this.colTaskRunTime.Name = "colTaskRunTime";
            this.colTaskRunTime.ReadOnly = true;
            this.colTaskRunTime.Width = 150;
            // 
            // colTaskPath
            // 
            this.colTaskPath.HeaderText = "任务目录";
            this.colTaskPath.Name = "colTaskPath";
            this.colTaskPath.ReadOnly = true;
            this.colTaskPath.Width = 200;
            // 
            // colTaskIsRunning
            // 
            this.colTaskIsRunning.HeaderText = "是否运行";
            this.colTaskIsRunning.Name = "colTaskIsRunning";
            this.colTaskIsRunning.ReadOnly = true;
            this.colTaskIsRunning.Visible = false;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.menuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "服务监控";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.show,
            this.hide,
            this.exit});
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(101, 70);
            // 
            // show
            // 
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(100, 22);
            this.show.Text = "显示";
            this.show.Click += new System.EventHandler(this.show_Click);
            // 
            // hide
            // 
            this.hide.Name = "hide";
            this.hide.Size = new System.Drawing.Size(100, 22);
            this.hide.Text = "隐藏";
            this.hide.Click += new System.EventHandler(this.hide_Click);
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(100, 22);
            this.exit.Text = "退出";
            this.exit.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // timer_HardInfor
            // 
            this.timer_HardInfor.Enabled = true;
            this.timer_HardInfor.Interval = 1000;
            this.timer_HardInfor.Tick += new System.EventHandler(this.timer_HardInfor_Tick);
            // 
            // timer_AppStatus
            // 
            this.timer_AppStatus.Interval = 3000;
            this.timer_AppStatus.Tick += new System.EventHandler(this.timer_AppStatus_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.StatusBar);
            this.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "看门狗";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel1.PerformLayout();
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.toolSysBar.ResumeLayout(false);
            this.toolSysBar.PerformLayout();
            this.toolSize.ResumeLayout(false);
            this.toolSize.PerformLayout();
            this.gbApp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApp)).EndInit();
            this.gbPTask.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTask)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel lbTime;
        private System.Windows.Forms.ToolStripStatusLabel lbCPU;
        private System.Windows.Forms.ToolStripStatusLabel lbMem;
        private System.Windows.Forms.ToolStripStatusLabel lbDisc;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.ToolStrip toolSysBar;
        private System.Windows.Forms.ToolStripButton btnTitle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnStart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripButton btnSetting;
        private System.Windows.Forms.ToolStrip toolSize;
        private System.Windows.Forms.ToolStripButton btnMin;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.GroupBox gbApp;
        private System.Windows.Forms.GroupBox gbPTask;
        private System.Windows.Forms.DataGridView dgvApp;
        private System.Windows.Forms.DataGridView dgvTask;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripSplitButton btnAdd;
        private System.Windows.Forms.ToolStripMenuItem add_App;
        private System.Windows.Forms.ToolStripMenuItem add_Task;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem show;
        private System.Windows.Forms.ToolStripMenuItem hide;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.Timer timer_HardInfor;
        private System.Windows.Forms.Timer timer_AppStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRunningStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsRunning;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTaskDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTaskCycle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTaskDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTaskRunTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTaskPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTaskIsRunning;
    }
}

