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
    public partial class frmAppSetting : Form
    {
        private AppEntity app;
        private bool isAdd = false;
        private List<EnvVariable> envVariables = null;
        private string[] sysPaths = null;
        private string[] libPaths = null;
        public frmAppSetting()
        {
            InitializeComponent();
        }
        private void frmAppSetting_Load(object sender, EventArgs e)
        {
            this.app = Tag as AppEntity;
            this.isAdd = app == null;
            if (!isAdd)
            {
                Init();
            }
        }
        private void Init()
        {
            tbName.Text = app.AppName;
            tbName.ReadOnly = true;
            tbPath.Text = app.AppPath;
            tbDescription.Text = app.Description;
            rbAutoYes.Checked = app.IsAutoRunning;
            rbAutoNo.Checked = !app.IsAutoRunning;
            envVariables = app.EnvVariables;
            RefreshEnv(envVariables);
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
        }
        private void RefreshEnv(List<EnvVariable> envs)
        {

            StringBuilder stringBuilder = new StringBuilder();
            if (envs.Any())
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
            frmEnvVariable frmEnvVariable = new frmEnvVariable();
            frmEnvVariable.Tag = envVariables;
            frmEnvVariable.ShowDialog(this);
            if (frmEnvVariable.DialogResult == DialogResult.OK)
            {
                envVariables = frmEnvVariable.Tag as List<EnvVariable>;
                RefreshEnv(envVariables);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            var canSave = true;
            var appName = tbName.Text.Trim();
            var appPath = tbPath.Text.Trim();
            var description = tbDescription.Text.Trim();
            var isAutoRunning = rbAutoYes.Checked;
            var cpuStr = tbCPUMax.Text.Trim();
            var memStr = tbMemMax.Text.Trim();
            double cpuMax = 0.00d;
            double memMax = 0.00d;
            if (string.IsNullOrEmpty(appName))
            {
                canSave = false;
                Global.Tips("服务名称不能为空");
            }
            if (string.IsNullOrEmpty(description))
            {
                Global.Tips("服务描述不能为空");
                canSave = false;
            }
            if (string.IsNullOrEmpty(appPath))
            {
                Global.Tips("服务目录不能为空");
                canSave = false;
            }
            if (!string.IsNullOrEmpty(cpuStr))
            {
                if (!double.TryParse(cpuStr, out cpuMax))
                {
                    Global.Tips("最大CPU占用率必须为数字");
                    canSave = false;
                }

            }
            if (!string.IsNullOrEmpty(memStr))
            {
                if (!double.TryParse(memStr, out memMax))
                {
                    Global.Tips("最大内存占用率必须为数字");
                    canSave = false;
                }
            }
            if (!Global.IsFileExist(appPath, appName))
            {
                Global.Tips($"文件目录={appPath} 下未找到名称={appName} 的文件");
                canSave = false;
            }
            if (!rbAutoNo.Checked && !rbAutoYes.Checked)
            {
                Global.Tips("请选择运行方式");
                canSave = false;
            }
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
            if (!canSave)
                return;
            if (isAdd)
            {
                app = new AppEntity(appName, appPath, isAutoRunning, description)
                {
                    EnvVariables = envVariables,
                    SysPaths = sysPaths,
                    LibPaths = libPaths,
                    Is61850 = rb61850.Checked,
                    IsJVM = rbJava.Checked,
                    CPUMax = cpuMax / 100.00d,
                    MemMax = memMax / 100.00d
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
                app.IsAutoRunning = isAutoRunning;
                app.Description = description;
                app.EnvVariables = envVariables;
                app.SysPaths = sysPaths;
                app.LibPaths = libPaths;
                Global.SaveApp(app);
            }
            DialogResult = DialogResult.OK;
            //Global.Tips($"保存成功，如需其他配置请到{app.AppPath}目录下手动编辑{app.AppName}.json文件");
            Close();

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void tbName_TextChanged(object sender, EventArgs e)
        {

            var appName = tbName.Text.Trim().ToLower();
            if (appName == "sl61850svr_d")
            {
                btn61850.Visible = true;
                btnEnv.Enabled = false;
                tbSysPath.ReadOnly = true;
                tbLibPath.ReadOnly = true;
            }
            else
            {
                btn61850.Visible = false;
                btnEnv.Enabled = true;
                tbSysPath.ReadOnly = false;
                tbLibPath.ReadOnly = false;
            }
        }
        /// <summary>
        /// 61850单独自动配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn61850_Click(object sender, EventArgs e)
        {
            var sl61850Bin = tbPath.Text.Trim();//包含Bin的目录
            var sl61850Name = "sl61850svr_d";
            if (!string.IsNullOrEmpty(sl61850Bin))
            {
                if (!Global.IsFileExist(sl61850Bin, sl61850Name))
                {
                    Global.Tips($"目录【{sl61850Bin}】下未找到【{sl61850Name}】文件");
                    return;
                }
                #region 61850 固定配置 参数
                //Environment.SetEnvironmentVariable("SL61850DIR", @"/home/wf/SL61850");
                //Environment.SetEnvironmentVariable("SL61850BUILDBIT", @"64");
                //Environment.SetEnvironmentVariable("SL61850BUILDTYPE", @"debug");

                //SetSystemPath("/home/wf/sL61850");
                //SetSystemPath("/home/wf/SL61850/bin"):
                //SetLibraryPath("/home/wf/SL61850/bin");
                //SetLibraryPath("/home/wf/sL61850/lib");
                #endregion
                tbDescription.Text = "61850服务";
                //这个是包含bin的文件 
                sl61850Bin = Path.Combine(sl61850Bin);
                //获取bin目录的上级目录 即为SL61850的Dir目录
                DirectoryInfo pathInfo = new DirectoryInfo(sl61850Bin);
                var sl61850Dir = pathInfo.Parent.FullName;
                //环境变量
                envVariables = new List<EnvVariable>()
                        {
                            new EnvVariable("SL61850DIR", sl61850Dir),
                            new EnvVariable("SL61850BUILDBIT", "64"),
                            new EnvVariable("SL61850BUILDTYPE", "debug")
                        };
                RefreshEnv(envVariables);
                //系统变量
                sysPaths = new string[] { sl61850Dir, sl61850Bin };
                tbSysPath.Text = string.Join(";", sysPaths);
                //Lib库变量
                libPaths = new string[] { sl61850Bin, Path.Combine(sl61850Dir, "lib") };
                tbLibPath.Text = string.Join(";", libPaths);
            }
            else
            {
                Global.Tips("请先设置sl61850svr_d路径");
            }
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
            //openFileDialog.Filter = "系统图图元文件|*.gra|All Files|*.*";
        }
    }
}
