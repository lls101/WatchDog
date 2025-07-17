using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchDog.Commons;
using WatchDog.UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static WatchDog.Global;

namespace WatchDog
{
    public partial class MainForm : Form
    {
        #region Fields
        private Point movePoint;
        private bool isMoving = false;
        private DgvType dgvType = DgvType.None;
        private AppEntity currentEntity = null;
        private int appStatusCount = 0;
        private int taskStartCount = 0;
        private int hardInforCount = 0;
        private int appWatchCount = 0;
        PerformanceCounter pfCpu;
        DriveInfo[] allDrives;
        private System.Threading.Timer timer_PlanTask;
        //private Action RunPlan;
        #endregion
        #region Constructor&Load
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            //Init();
            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                Init();
                Global.WriteLog($"看门狗启动");
            }
            else
            {
                frmErr err = new frmErr();
                err.ShowDialog();
                Close();
            }
        }
        #endregion
        #region Events
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentEntity == null)
                {
                    Global.Tips("请选中要启动的程序");
                    return;
                }

                if (currentEntity.Run())
                {
                    //手动启动时将 IsActiveStop 置初始位置
                    currentEntity.IsActiveStop = false;
                    if (dgvType == DgvType.App)
                    {
                        InsertOrUpdateDgvApp(currentEntity, false);
                    }
                    else if (dgvType == DgvType.Task)
                    {
                        InsertOrUpdateDgvTask(currentEntity, false);
                    }
                    BtnEnable(false);
                }
                else
                {
                    BtnEnable(true);
                }
            }
            catch (Exception ex)
            {
                Global.Tips($"启动App错误:{ex.Message}");
            }

        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentEntity?.Stop() == true)
                {
                    //设置IsActiveStop = true 防止自启动程序 无法停止
                    currentEntity.IsActiveStop = true;
                    if (dgvType == DgvType.App)
                    {
                        InsertOrUpdateDgvApp(currentEntity, false);
                    }
                    else if (dgvType == DgvType.Task)
                    {
                        InsertOrUpdateDgvTask(currentEntity, false);
                    }
                    BtnEnable(true);
                }
                else
                {
                    BtnEnable(false);
                }
            }
            catch (Exception ex)
            {

                Global.Tips($"停止App错误:{ex.Message}");
            }

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentEntity == null)
                {
                    Global.Tips("请先选择编辑的服务");
                    return;
                }
                if (dgvType == DgvType.App)
                {
                    frmAppSetting appSetting = new frmAppSetting();
                    appSetting.Tag = currentEntity;
                    appSetting.ShowDialog(this);
                    if (appSetting.DialogResult == DialogResult.OK)
                    {
                        InsertOrUpdateDgvApp(currentEntity, false);
                    }
                }
                else
                {
                    frmTaskSetting taskSetting = new frmTaskSetting();
                    taskSetting.Tag = currentEntity;
                    taskSetting.ShowDialog(this);
                    if (taskSetting.DialogResult == DialogResult.OK)
                    {
                        InsertOrUpdateDgvTask(currentEntity, false);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.Tips($"编辑App错误:{ex.Message}");
            }

        }
        private void add_App_Click(object sender, EventArgs e)
        {
            try
            {
                frmAppSetting appSetting = new frmAppSetting();
                appSetting.ShowDialog(this);
                if (appSetting.DialogResult == DialogResult.OK)
                {
                    var app = appSetting.Tag as AppEntity;
                    if (app != null)
                    {
                        InsertOrUpdateDgvApp(app, true);
                    }
                }
            }
            catch (Exception ex)
            {

                Global.Tips($"错误信息{ex.Message}");
            }

        }
        private void add_Task_Click(object sender, EventArgs e)
        {
            try
            {
                frmTaskSetting taskSetting = new frmTaskSetting();
                taskSetting.ShowDialog(this);
                if (taskSetting.DialogResult == DialogResult.OK)
                {
                    var app = taskSetting.Tag as AppEntity;
                    if (app != null)
                    {
                        InsertOrUpdateDgvTask(app, true);
                    }
                }
            }
            catch (Exception ex)
            {

                Global.Tips($"新增计划任务错误:{ex.Message}");
            }


        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentEntity == null)
                {
                    Global.Tips("请先选择刷新的服务");
                    return;
                }
                //停止当前App
                StopApp(currentEntity);
                if (ReLoadApp(currentEntity.AppName) && currentEntity.IsAutoRunning)
                {
                    RunApp(currentEntity);
                }
                Global.WriteLog($"刷新{currentEntity.AppName}");
            }
            catch (Exception ex)
            {
                Global.Tips($"刷新错误:{ex.Message}");
            }

        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentEntity == null)
                {
                    Global.Tips("请先选择删除的服务");
                    return;
                }
                var result = Global.QuestionWithCancle("删除后是否立即终止此服务?");
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                else if (result == DialogResult.Yes)
                {
                    //终止当前正在运行的服务
                    StopApp(currentEntity);
                    WatchApps.Remove(currentEntity);
                }
                DelDgvRow(currentEntity);
                btnStart.Enabled = false;
                btnStop.Enabled = false;
            }
            catch (Exception ex)
            {
                Global.Tips($"删除错误:{ex.Message}");
            }

        }
        private void btnSetting_Click(object sender, EventArgs e)
        {
            //后续增加的告警 预警设置界面 
        }
        private void btnMin_Click(object sender, EventArgs e)
        {
            Hide(); //或者是this.Visible = false;
            notifyIcon.Visible = true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {

            //var result = Global.Query("是否退出当前程序?");
            if (Global.Query("是否退出当前程序?") == DialogResult.OK)
            {
                notifyIcon.Visible = false;
                //终止当前正在运行的服务 及timer
                timer_AppStatus.Stop();
                timer_HardInfor.Stop();
                //var customApps = WatchApps.Where(a => !a.IsPTask);
                if (WatchApps.Any())
                    StopApp(WatchApps.ToArray());
                Close();
            }
        }
        private void toolSysBar_MouseDown(object sender, MouseEventArgs e)
        {
            movePoint = new Point(e.X, e.Y);
            isMoving = true;
        }
        private void toolSysBar_MouseUp(object sender, MouseEventArgs e)
        {
            isMoving = false;
        }
        private void toolSysBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isMoving)
            {
                this.Location = new Point(this.Location.X + e.X - movePoint.X, this.Location.Y + e.Y - movePoint.Y);
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer_AppStatus.Stop();
            timer_HardInfor.Stop();
        }
        #region  常驻图标
        private void show_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
        }
        private void hide_Click(object sender, EventArgs e)
        {
            Hide();
        }
        /// <summary>
        /// Mono下Icon的最大尺寸是128*128  
        /// 千万不能超过这个尺寸 千万不能超过这个尺寸 千万不能超过这个尺寸 
        /// 否则会有意想不到的惊喜哦!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon_Click(object sender, EventArgs e)
        {
            if (Visible)
                Hide();
            else
            {
                Show();
                WindowState = FormWindowState.Normal;
                Activate();
            }
        }
        #endregion
        #endregion
        #region Methods
        private void Init()
        {
            try
            {
                //显示替换Icon图标
                var fileName = Path.Combine(Global.WatchDogPath, "content", "watchdog.png");
                var bmp = new Bitmap(fileName);
                this.notifyIcon.Icon = Icon.FromHandle(bmp.GetHicon());
                this.notifyIcon.Visible = true;
                var defaultFont = System.Drawing.SystemFonts.DefaultFont.Name;
                //设置双缓存 减少界面闪烁
                dgvApp.SetDoubleBuffering();
                dgvTask.SetDoubleBuffering();
                pfCpu = new PerformanceCounter("Processor", "% Processor Time", "_Total", ".");
                allDrives = DriveInfo.GetDrives();
                LoadApps();
                //启动自启动的程序
                IEnumerable<AppEntity> autoRunApps = WatchApps.Where(a => !a.IsPTask && a.IsAutoRunning);
                RunApp(autoRunApps.ToArray());
                //刷新显示界面
                InitDgv();
                timer_AppStatus.Start();
                ////将可能的阻塞UI 任务放到后台执行 -- 这个有问题  会导致程序卡死
                timer_PlanTask = new System.Threading.Timer(state => RunPlanTask(), null, 0, 5000);
                timer_HardInfor.Start();
            }
            catch (Exception ex)
            {
                Global.Tips($"初始化错误:{ex.Message}");
            }

        }
        private void StopApp(params AppEntity[] apps)
        {
            try
            {
                foreach (var app in apps)
                {
                    if (app?.IsRunning == true)
                        app.Stop();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private void RunApp(params AppEntity[] apps)
        {
            try
            {
                foreach (var app in apps)
                {
                    app?.Run();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private void BtnEnable(bool startEnable)
        {
            btnStart.Enabled = startEnable;
            btnStop.Enabled = !startEnable;
        }
        #endregion
        #region Timer
        private void timer_HardInfor_Tick(object sender, EventArgs e)
        {
            try
            {
                lbTime.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss (dddd)");
                hardInforCount = hardInforCount % 2;
                if (hardInforCount == 0)
                    HardWatchProc();
                hardInforCount++;
            }
            catch (Exception ex)
            {
                Global.WriteLog($"获取硬件信息错误:{ex.Message}");
            }
        }
        private void timer_AppStatus_Tick(object sender, EventArgs e)
        {
            try
            {
                appStatusCount = appStatusCount % 3;
                if (appStatusCount == 0)
                {
                    //更新常驻任务状态及CPU、内存使用情况
                    UpdateAppStatus();
                }
                appStatusCount++;

                appWatchCount = appWatchCount % 2;
                if (appWatchCount == 0)
                {
                    WatchProcess();
                }
                appWatchCount++;

            }
            catch (Exception ex)
            {
                Global.WriteLog($"获取App启动状态错误:{ex.Message}");
            }
        }
        /// <summary>
        /// 刷新常驻任务状态
        /// </summary>
        private void UpdateAppStatus()
        {
            try
            {
                var customApps = WatchApps.Where(a => !a.IsPTask);
                if (customApps?.Any() == true)
                {
                    foreach (var app in customApps)
                    {
                        var isRun = app.IsRun();
                        //必须要将app.IsRun()放在第一个,否则会导致非自启动服务无法实时刷新运行状态
                        if (!isRun && app.IsAutoRunning && !app.IsActiveStop)
                        {
                            //Console.WriteLine($"AppRuning={isRun} IsAutoRunning={app.IsAutoRunning} IsActiveStop={app.IsActiveStop} ");
                            app.Run();
                        }
                        if (app.StatusChanged)
                        {
                            var row = FindRowByAppName(dgvApp, "colAppName", app.AppName);
                            if (row != null)
                            {
                                row.Cells["colRunningStatus"].Value = app.RunningStatus;
                                row.Cells["colDescription"].Value = app.Description;
                                app.StatusChanged = false;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"获取App运行状态错误:{ex}");
            }
        }
        /// <summary>
        /// 监控常驻任务CPU、内存使用情况
        /// 超过最大
        /// </summary>
        private void WatchProcess()
        {

            try
            {
                var customApps = WatchApps.Where(a => !a.IsPTask);
                if (customApps?.Any() == true)
                {
                    foreach (var app in customApps)
                    {
                        if (app.CheckHardInfor && app.IsRun())
                        {
                            if (int.TryParse(app?.ProcessId, out int pid) && pid > 0)
                            {
                                var cpu = AppProcessInfo.GetProcessCpuUsage(pid);
                                var mem = AppProcessInfo.GetProcessMemoryUsagePercent(pid);
                                if (cpu > app.CPUMax || mem > app.MemMax)
                                {
                                    Global.WriteLog($"PorcessId={pid} CPU={cpu * 100:F2}%");
                                    Global.WriteLog($"PorcessId={pid} MEM={mem * 100:F2}%");
                                }

                                app?.WatchHardInfor(cpu, mem);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"获取CPU Err={ex.Message}");
            }


        }
        /// <summary>
        /// 启动计划任务
        /// </summary>
        /// <exception cref="Exception"></exception>
        private void RunPlanTask()
        {
            try
            {
                DateTime now = DateTime.Now;
                var hour = now.Hour;
                var minute = now.Minute;
                var second = now.Second;
                //判断区间20s
                var nowSeconds = new int[] { second - 20 < 0 ? 0 : second - 10, second + 20 };
                var taskApps = WatchApps.Where(a => a.IsPTask);
                if (taskApps?.Any() == true)
                {
                    foreach (var app in taskApps)
                    {
                        var taskParm = app.PTaskParm;
                        if (taskParm != null)
                        {
                            if (taskParm.Hour == hour && taskParm.Minute == minute && taskParm.Second <= nowSeconds[1] && taskParm.Second >= nowSeconds[0])
                            {
                                var pCycle = taskParm.PTaskCycle;
                                var isRun = false;
                                switch (pCycle)
                                {
                                    case PTaskCycle.Day:
                                        isRun = true;
                                        break;
                                    case PTaskCycle.Week:

                                        var nowDayofWeek = now.DayOfWeek;
                                        var dayofWeek = Global.ConvertDayOfWeek(taskParm.TaskDay);
                                        if (dayofWeek == nowDayofWeek)
                                        {
                                            isRun = true;
                                        }
                                        break;
                                    case PTaskCycle.Month:
                                        if (taskParm.TaskDay == now.Day)
                                            isRun = true;
                                        break;
                                    default:
                                        isRun = false;
                                        break;
                                }
                                if (isRun)
                                {
                                    Global.WriteLog($"启动计划任务{app.AppFullName}");
                                    app.Run();
                                }
                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"启动计划任务错误:{ex}");
            }
        }

        #endregion

    }

}
