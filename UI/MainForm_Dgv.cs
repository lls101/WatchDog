using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WatchDog.Global;
namespace WatchDog
{
    public partial class MainForm
    {
        private void dgvApp_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvType = DgvType.App;
            var clickRowIndex = e.RowIndex;
            dgvTask.ClearSelection();
            if (clickRowIndex > -1)
            {
                var appName = dgvApp.Rows[clickRowIndex].Cells["colAppName"]?.Value as string;
                if (!string.IsNullOrEmpty(appName))
                {
                    currentEntity = FindAppByName(appName);
                    BtnEnable(!currentEntity.IsRunning);
                }
            }
        }
        private void dgvTask_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvType = DgvType.Task;
            var clickRowIndex = e.RowIndex;
            dgvApp.ClearSelection();
            if (clickRowIndex > -1)
            {
                var appName = dgvTask.Rows[clickRowIndex].Cells["colTaskName"]?.Value as string;
                if (!string.IsNullOrEmpty(appName))
                {
                    currentEntity = FindAppByName(appName);
                    //btnStart.Enabled = !currentEntity.IsRunning;
                    //btnStop.Enabled = currentEntity.IsRunning;
                    BtnEnable(!currentEntity.IsRunning);
                }
            }
        }
        private AppEntity FindAppByName(string appName)
        {
            return WatchApps.FirstOrDefault(a => a.AppName == appName);
        }
        private void InitDgv()
        {
            var customApps = WatchApps.Where(a => !a.IsPTask);
            dgvApp.Rows.Clear();
            foreach (var app in customApps)
            {
                var rowIndex = dgvApp.Rows.Add(new DataGridViewRow());
                var row = dgvApp.Rows[rowIndex];
                row.Cells["colAppName"].Value = app.AppName;
                row.Cells["colDescription"].Value = app.Description;
                //row.Cells["colAppEnvPath"].Value = app.LibPath;
                row.Cells["colIsRunning"].Value = app.IsRunning;
                row.Cells["colRunningStatus"].Value = app.RunningStatus;
                row.Cells["colAppPath"].Value = app.AppPath;
            }
            dgvApp.ClearSelection();
            var taskApps = WatchApps.Where(a => a.IsPTask);
            dgvTask.Rows.Clear();
            foreach (var app in taskApps)
            {
                var pTask = app.PTaskParm;
                var rowIndex = dgvTask.Rows.Add(new DataGridViewRow());
                var row = dgvTask.Rows[rowIndex];
                row.Cells["colTaskName"].Value = app.AppName;
                row.Cells["colTaskDescription"].Value = app.Description;
                //row.Cells["colTaskEnvPath"].Value = app.LibPath;
                row.Cells["colTaskCycle"].Value = pTask.PCycleText;
                row.Cells["colTaskDate"].Value = pTask.TaskDayText;
                row.Cells["colTaskRunTime"].Value = pTask.RunTimeText;
                row.Cells["colTaskPath"].Value = app.AppPath;
            }
            dgvTask.ClearSelection();
        }
        private DataGridViewRow FindRowByAppName(DataGridView dgv, string colName, string appName)
        {
            try
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells[$"{colName}"].Value?.ToString() == appName)
                    {
                        return row;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private void InsertOrUpdateDgvApp(AppEntity app, bool isInsert)
        {
            try
            {
                DataGridViewRow row;
                if (isInsert)
                {
                    var rowIndex = dgvApp.Rows.Add(new DataGridViewRow());
                    row = dgvApp.Rows[rowIndex];
                    row.Cells["colAppName"].Value = app.AppName;
                }
                else
                {
                    row = FindRowByAppName(dgvApp, "colAppName", app.AppName);
                }
                row.Cells["colRunningStatus"].Value = app.RunningStatus;
                row.Cells["colDescription"].Value = app.Description;
                //row.Cells["colAppEnvPath"].Value = app.LibPath;
                row.Cells["colIsRunning"].Value = app.IsRunning;
                row.Cells["colRunningStatus"].Value = app.RunningStatus;
                row.Cells["colAppPath"].Value = app.AppPath;
                dgvApp.Refresh();
                dgvApp.ClearSelection();
            }
            catch (Exception ex)
            {

                throw new Exception($"刷新DgvApp错误:{ex}");
            }

        }
        private void InsertOrUpdateDgvTask(AppEntity app, bool isInsert)
        {
            try
            {
                var pTask = app.PTaskParm;
                DataGridViewRow row;
                if (isInsert)
                {
                    var rowIndex = dgvTask.Rows.Add(new DataGridViewRow());
                    row = dgvTask.Rows[rowIndex];
                    row.Cells["colTaskName"].Value = app.AppName;
                }
                else
                {
                    row = FindRowByAppName(dgvTask, "colTaskName", app.AppName);
                }
                row.Cells["colTaskIsRunning"].Value = app.IsRunning;
                row.Cells["colTaskDescription"].Value = app.Description;
                //row.Cells["colTaskEnvPath"].Value = app.LibPath;
                row.Cells["colTaskCycle"].Value = pTask.PCycleText;
                row.Cells["colTaskDate"].Value = pTask.TaskDayText;
                row.Cells["colTaskRunTime"].Value = pTask.RunTimeText;
                row.Cells["colTaskPath"].Value = app.AppPath;
                dgvTask.Refresh();
                dgvApp.ClearSelection();
            }
            catch (Exception ex)
            {

                throw new Exception($"刷新DgvTask错误:{ex}");
            }

        }
        private void DelDgvRow(AppEntity app)
        {
            try
            {
                Global.RemoveApp(app.AppName);
                if (dgvType == DgvType.App)
                {
                    var row = FindRowByAppName(dgvApp, "colAppName", app.AppName);
                    dgvApp.Rows.Remove(row);
                }
                else if (dgvType == DgvType.Task)
                {
                    var row = FindRowByAppName(dgvTask, "colTaskName", app.AppName);
                    dgvTask.Rows.Remove(row);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        enum DgvType
        {
            None,
            App,
            Task
        }
    }
}
