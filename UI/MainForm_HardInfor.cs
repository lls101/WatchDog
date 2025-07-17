using System;
using System.Diagnostics;
using System.IO;
using WatchDog.Commons;
using WatchDog.Linux;

namespace WatchDog
{
    public partial class MainForm
    {
        private void HardWatchProc()
        {
            #region 装置监测数据
            BASE_INF.Instance.Add(ST.装置监测数据.CPU负载率, pfCpu.NextValue().ToString("F2"));
            BASE_INF.Instance.Add(ST.装置监测数据.内存使用率, MemoryUsageProvider.Instance.GetUsage().ToString("F2"));
            foreach (var d in allDrives)
            {
                if (!DiskUsage.ShouldCheckDrive(d))
                {
                    continue;
                }
                float f = DiskUsage.GetCurrentDiskSpaceUsedPercent(d.Name);
                BASE_INF.Instance.Add(ST.装置监测数据.磁盘使用率, f.ToString("F2"));
                break;
            }
            #endregion 装置监测数据

            float cpu_rate = 0;
            float mem_rate = 0;
            float disc_rate = 0;

            try
            {
                cpu_rate = float.Parse(BASE_INF.Instance.GetVal(ST.装置监测数据.CPU负载率));
                mem_rate = float.Parse(BASE_INF.Instance.GetVal(ST.装置监测数据.内存使用率));
                disc_rate = float.Parse(BASE_INF.Instance.GetVal(ST.装置监测数据.磁盘使用率));
            }
            catch (Exception ex)
            {
                Global.WriteLog(ex.Message);
            }
            ShowMachineRate();
        }
        private void ShowMachineRate()
        {
            if (StatusBar.IsHandleCreated)
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new Action(ShowMachineRate));
                    return;
                }

                lbCPU.Text = "CPU:" + float.Parse(BASE_INF.Instance.GetVal(ST.装置监测数据.CPU负载率)) + "%";
                lbMem.Text = "MEM:" + float.Parse(BASE_INF.Instance.GetVal(ST.装置监测数据.内存使用率)) + "%";
                lbDisc.Text = "DISC:" + float.Parse(BASE_INF.Instance.GetVal(ST.装置监测数据.磁盘使用率)) + "%";
            }
        }
    }
}
