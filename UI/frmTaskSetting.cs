using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WatchDog.UI
{
    public partial class frmTaskSetting : Form
    {
        private AppEntity app;
        private PTaskParm pTask;
        private bool isAdd = false;
        private List<EnvVariable> envVariables = null;
        private string[] sysPaths = null;
        private string[] libPaths = null;
        public frmTaskSetting()
        {
            InitializeComponent();
        }
        private void frmTaskSetting_Load(object sender, EventArgs e)
        {
            this.app = Tag as AppEntity;
            this.isAdd = app == null;
            if (!isAdd)
            {
                Init();
            }
        }
        void Init()
        {
            DateTime now = DateTime.Now;
            pTask = app.PTaskParm;
            tbName.Text = app.AppName;
            tbName.ReadOnly = true;
            tbPath.Text = app.AppPath;
            tbDescription.Text = app.Description;
            dtTime.Value = new DateTime(now.Year, now.Month, now.Day, pTask.Hour, pTask.Minute, pTask.Second);
            switch (pTask.PTaskCycle)
            {
                case PTaskCycle.Day:
                    rb_Day.Checked = true;
                    break;
                case PTaskCycle.Week:
                    rb_Week.Checked = true;
                    break;
                case PTaskCycle.Month:
                    rb_Month.Checked = true;
                    break;

            }
            comDate.Text = pTask.TaskDay.ToString();
            envVariables = app.EnvVariables;
            sysPaths = app.SysPaths;
            if (sysPaths?.Length > 0)
            {
                tbSysPath.Text = string.Join(";", sysPaths);
            }
            libPaths = app.LibPaths;
            if (libPaths?.Length > 0)
            {
                tbLibPath.Text = string.Join(";", libPaths);
            }
            RefreshEnv(envVariables);
        }
        private void RefreshEnv(List<EnvVariable> envs)
        {

            StringBuilder stringBuilder = new StringBuilder();
            if (envs?.Count() > 0)
            {
                foreach (var v in envs)
                {
                    stringBuilder.Append($"[{nameof(v.Key).ToLower()}:'{v.Key}',{nameof(v.Value).ToLower()}:'{v.Value}']");
                    stringBuilder.Append(Environment.NewLine);
                }
                tbEnv.Text = stringBuilder.ToString();
            }
            else
                tbEnv.Text = string.Empty;
        }
        private void btnEnv_Click(object sender, EventArgs e)
        {
            try
            {
                frmEnvVariable frmEnvVariable = new frmEnvVariable();
                frmEnvVariable.Tag = envVariables;
                frmEnvVariable.ShowDialog(this);
                if (frmEnvVariable.DialogResult == DialogResult.OK)
                {
                    envVariables = frmEnvVariable.Tag as List<EnvVariable>;
                    RefreshEnv(envVariables);
                }
            }
            catch (Exception ex)
            {
                Global.Tips($"编辑环境变量异常:{ex.Message}");
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            var canSave = true;
            var appName = tbName.Text.Trim();
            var appPath = tbPath.Text.Trim();
            var description = tbDescription.Text.Trim();
            if (string.IsNullOrEmpty(appName))
            {
                canSave = false;
                Global.Tips("任务名称不能为空");
            }

            if (string.IsNullOrEmpty(appPath))
            {
                Global.Tips("任务目录不能为空");
                canSave = false;
            }
            if (!Global.IsFileExist(appPath, appName))
            {
                Global.Tips($"文件目录={appPath} 下未找到名称={appName} 的任务文件");
                canSave = false;
            }
            if (string.IsNullOrEmpty(description))
            {
                Global.Tips("任务描述不能为空");
                canSave = false;
            }
            PTaskCycle pTaskCycle = PTaskCycle.None;
            var comRunDate = comDate.Text;
            if (rb_Day.Checked)
            {
                pTaskCycle = PTaskCycle.Day;
                comRunDate = "0";
            }
            else if (rb_Week.Checked)
            {
                pTaskCycle = PTaskCycle.Week;
            }
            else if (rb_Month.Checked)
            {
                pTaskCycle = PTaskCycle.Month;
            }
            if (pTaskCycle == PTaskCycle.None)
            {
                Global.Tips("请选择执行周期");
                canSave = false;
            }
            if (string.IsNullOrEmpty(comRunDate))
            {
                Global.Tips("请选择执行日期");
                canSave = false;
            }
            if (string.IsNullOrEmpty(dtTime.Value.ToString()))
            {
                Global.Tips("请选择执行时间");
                canSave = false;
            }
            if (!canSave)
                return;
            var sSysPath = tbSysPath.Text.Trim();
            if (!string.IsNullOrEmpty(sSysPath))
            {
                sysPaths = sSysPath.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            }
            else
                sysPaths = null;
            var sLibPath = tbLibPath.Text.Trim();
            if (!string.IsNullOrEmpty(sLibPath))
            {
                libPaths = sLibPath.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            }
            else
                libPaths = null;
            PTaskParm pTask = new PTaskParm(pTaskCycle, int.Parse(comRunDate), dtTime.Value.Hour, dtTime.Value.Minute, dtTime.Value.Second);
            if (isAdd)
            {
                app = new AppEntity(appName, appPath, false, description)
                {
                    IsPTask = true,
                    PTaskParm = pTask,
                    EnvVariables = envVariables,
                    SysPaths = sysPaths,
                    LibPaths = libPaths
                };
                if (Global.SaveApp(app))
                {
                    Global.WatchApps.Add(app);
                    this.Tag = app;
                }
            }
            else
            {
                app.AppPath = appPath;
                app.Description = description;
                app.PTaskParm = pTask;
                app.EnvVariables = envVariables;
                app.SysPaths = sysPaths;
                app.LibPaths = libPaths;
                Global.SaveApp(app);
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void rb_Cycle_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if (rb?.Checked == true)
            {
                comDate.Items.Clear();
                comDate.Text = string.Empty;
                comDate.Enabled = false;
                switch (rb.Name)
                {
                    case "rb_Day":
                        comDate.Text = "0";
                        break;
                    case "rb_Week":
                        comDate.Enabled = true;
                        comDate.Items.AddRange(Global.Weeks);
                        if (pTask != null)
                        {
                            comDate.Text = pTask.TaskDay.ToString();
                        }
                        break;
                    case "rb_Month":
                        comDate.Enabled = true;
                        comDate.Items.AddRange(Global.Days);
                        if (pTask != null)
                        {
                            comDate.Text = pTask.TaskDay.ToString();
                        }
                        break;
                }
            }
        }

        private void comDate_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnSelectApp_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog(this) == DialogResult.OK)
            {
                var fileFullName = fileDialog.FileName;
                var fileName = Path.GetFileName(fileFullName);
                var filePath = Path.GetDirectoryName(fileFullName);

                tbName.Text = fileName;
                tbPath.Text = filePath;
                tbDescription.Text = fileName;
            }
        }
    }
}
