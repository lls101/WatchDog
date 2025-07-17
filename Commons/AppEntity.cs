using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WatchDog.Linux;
using static System.Windows.Forms.LinkLabel;
namespace WatchDog
{
    public class AppEntity
    {

        /// <summary>
        /// app名称
        /// </summary>
        public string AppName { get; set; }
        public bool Is61850 { get; set; } = false;
        /// <summary>
        /// 如果app已sh方式启动 则记录下启动的sh的终端ProcessId  
        /// 在关闭服务时同时关闭启动sh的终端进程
        /// </summary>
        [JsonIgnore]
        public string SHCmdId { get; set; }
        /// <summary>
        /// app路径
        /// </summary>
        private string appPath = string.Empty;
        public string AppPath
        {
            get => appPath;
            set => appPath = value;
        }
        private string CreationTime { get; set; }
        [JsonIgnore]
        public string AppFullName => Path.Combine(AppPath, AppName);
        /// <summary>
        /// 是否是sh文件
        /// </summary>
        [JsonIgnore]
        private bool isSH => Path.GetExtension(AppName).ToLower() == ".sh";
        /// <summary>
        /// 是否是手动停止的服务
        /// </summary>
        [JsonIgnore]
        public bool IsActiveStop { get; set; } = false;
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// SysPath
        /// </summary>
        public string[] SysPaths { get; set; }
        /// <summary>
        /// LDLibPath
        /// </summary>
        public string[] LibPaths { get; set; }
        /// <summary>
        /// 环境变量
        /// </summary>
        public List<EnvVariable> EnvVariables { get; set; } = new List<EnvVariable>();
        /// <summary>
        /// 开启看门狗是否自动运行
        /// </summary>
        public bool IsAutoRunning { get; set; }
        [JsonIgnore]
        public bool StatusChanged { get; set; }
        private bool isRunning = false;
        [JsonIgnore]
        public bool IsRunning
        {
            get => isRunning;
            set
            {
                if (isRunning != value)
                {
                    isRunning = value;
                    StatusChanged = true;
                }
                ;
            }
        }
        [JsonIgnore]
        public string RunningStatus => IsRunning ? "运行" : "停止";
        [JsonIgnore]
        public string ProcessId { get; set; } = string.Empty;
        /// <summary>
        /// 是否是java程序 如果是java程序则需要获取java虚拟机的ID
        /// 否则会导致杀不死进程
        /// </summary>
        public bool IsJVM { get; set; }
        /// <summary>
        /// 是否是计划任务
        /// </summary>
        public bool IsPTask { get; set; }
        /// <summary>
        /// 运行时允许最大CPU使用率
        /// </summary>
        public double CPUMax { get; set; }
        /// <summary>
        /// 运行时运行最大内存使用率
        /// </summary>
        public double MemMax { get; set; }
        /// <summary>
        /// 是否需要检测CPU Mem 
        /// </summary>
        [JsonIgnore]
        public bool CheckHardInfor => CPUMax > 0 && MemMax > 0;
        /// <summary>
        /// 报警时间 超过10s 关闭app
        /// </summary>
        [JsonIgnore]
        public DateTime WarningTime { get; set; } = DateTime.Now;
        [JsonIgnore]
        public bool IsWarning { get; set; } = false;
        /// <summary>
        /// 计划任务参数
        /// </summary>
        public PTaskParm PTaskParm { get; set; }
        private AppEntity() { }
        public AppEntity(string appName, string appPath, bool isAutoRunning, string description = "")
        {
            if (!Global.IsFileExist(appPath, appName))
            {
                throw new Exception($"目录={appPath} 下未找到名称={appName} 的文件");
            }
            AppName = appName;
            AppPath = appPath;
            this.IsAutoRunning = isAutoRunning;
            Description = description;
            CreationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>
        /// 重写Equals 只要app名称一致就认为是同一个程序
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is AppEntity other)
            {
                return GetHashCode() == other.GetHashCode();
            }
            return false;
        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + AppName?.GetHashCode() ?? 0;
            return hash;
        }
        public bool Run()
        {
            try
            {
                if (IsRun()) return true;
                if (EnvVariables?.Count() > 0)
                {
                    SetEnvVariable(EnvVariables);
                }
                if (SysPaths?.Length > 0)
                {
                    SetSystemPath(SysPaths);
                }
                if (LibPaths?.Length > 0)
                {
                    SetLibraryPath(LibPaths);
                }
                //sh和普通文件启动方式不一样
                if (isSH)
                {
                    // appPath = $"cd {appPath} && ./{AppName}";
                    // 如果sh文件里面没有cd命令 这里需要组串 先执行cd
                    var runShCmd = $"cd {appPath} && ./{AppName}";
                    Global.WriteLog($"sh文件执行命令{runShCmd}");
                    using (var process = HardwareInfoBase.RunLinuxCmd(runShCmd))
                    {
                        ProcessId = process?.Id.ToString() ?? string.Empty;
                        SHCmdId = ProcessId;
                        IsRunning = !string.IsNullOrEmpty(ProcessId);
                        if (isRunning)
                        {
                            Global.WriteLog($"sh启动成功ProcessId={ProcessId}");
                        }
                        else
                        {
                            Global.WriteLog($"sh启动成功失败");
                        }
                    }

                }
                else
                {
                    using (var processApp = HardwareInfoBase.StartProcess(AppFullName, "", true, false, AppPath))
                    {
                        ProcessId = processApp?.Id.ToString() ?? string.Empty;
                        IsRunning = !string.IsNullOrEmpty(ProcessId);
                    }


                }
                var result = IsRunning ? "成功" : "失败";
                if (!IsPTask)
                {
                    Global.WriteLog($"常驻任务[{AppFullName}]启动{result},PID={ProcessId}");
                }
                else
                {
                    Global.WriteLog($"计划任务[{AppFullName}]执行{result},PID={ProcessId}");
                }

                return IsRunning;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Stop()
        {
            if (!IsRun()) return true;
            try
            {
                var cmd = $"kill -9 {ProcessId}";
                Console.WriteLine(cmd);
                HardwareInfoBase.RunLinuxCmd(cmd, false, true);
                //关闭启动程序的终端ID
                if (!string.IsNullOrEmpty(SHCmdId) && SHCmdId != ProcessId)
                {
                    cmd = $"kill -9 {SHCmdId}";
                    Console.WriteLine($"kill -9 SHCmdId={cmd}");
                    HardwareInfoBase.RunLinuxCmd(cmd, false, true);
                    SHCmdId = string.Empty;
                }
                IsRunning = false;
                if (!IsPTask)
                {
                    Global.WriteLog($"常驻任务[{AppFullName}] {RunningStatus} ProcessId={ProcessId}");
                }
                int.TryParse(ProcessId, out var pid);
                AppProcessInfo.AppCpuUsage.TryRemove(pid, out _);
                ProcessId = string.Empty;

                IsWarning = false;
                WarningTime = DateTime.Now;
            }
            catch (Exception ex)
            {
                Global.WriteLog($"常驻任务[{AppFullName}] 停止异常信息:{ex.Message}");
            }
            return true;
        }
        public bool IsRun()
        {
            try
            {
                var runName = AppName;
                if (isSH)
                {
                    if (Is61850)
                    {
                        runName = "sl61850svr_d";
                    }
                    else if (IsJVM)
                    {
                        runName = "java";
                    }
                }
                var str = HardwareInfoBase.ReadProcessOutput("/bin/bash", $"-c 'ps -ef | grep {runName} | grep -v grep'");
                if (!string.IsNullOrWhiteSpace(str))
                {
                    var arr = str.Split(' ');

                    var items = arr.Where(a => !string.IsNullOrWhiteSpace(a));
                    if (items?.Count() > 0)
                        ProcessId = items.ElementAt(1) ?? string.Empty;
                    else
                        ProcessId = string.Empty;
                }
                else
                    ProcessId = string.Empty;
                IsRunning = !string.IsNullOrWhiteSpace(ProcessId);
                return isRunning;
            }
            catch (Exception ex)
            {
                Global.WriteLog($"appName={AppFullName}获取运行状态异常,详情:{ex.Message}");
                throw ex;
            }
        }
        public void WatchHardInfor(double cpu, double mem)
        {
            //通过核心数计算单核使用率
            if (CheckHardInfor && (cpu > CPUMax || mem > MemMax))
            {
                if (!IsWarning)
                {
                    IsWarning = true;
                    WarningTime = DateTime.Now;
                    Console.WriteLine($"cpu={cpu * 100:F2}% WarningTime={WarningTime.ToString("HH:mm:ss")}");
                }
                else
                {
                    if (DateTime.Now.Subtract(WarningTime).TotalSeconds > 15)
                    {
                        Global.WriteLog($"app={AppName}停止运行 Reason: CPU={cpu * 100:F2}% MEM={mem * 100:F2}% 超过预设CPUMax={CPUMax * 100:F2}%,MemMax={MemMax * 100:F2}% ");
                        Stop();
                    }
                }
            }
            else
            {
                IsWarning = false;
                WarningTime = DateTime.Now;
            }
        }
        private void SetSystemPath(string[] paths)
        {
            try
            {
                string currentLibraryPath = Environment.GetEnvironmentVariable("PATH") ?? string.Empty;
                foreach (string path in paths)
                {
                    if (!currentLibraryPath.Contains(path))
                    {
                        if (currentLibraryPath != string.Empty)
                        {
                            currentLibraryPath += ":";
                        }
                        currentLibraryPath += path;
                    }
                }
                Global.WriteLog($"Set {AppFullName}  PATH: {currentLibraryPath} ");
                Environment.SetEnvironmentVariable("PATH", currentLibraryPath);
            }
            catch (Exception ex)
            {

                throw new Exception($"SetEnvironmentVariable PATH Err:{ex.Message}");
            }

        }
        private void SetEnvVariable(List<EnvVariable> envs)
        {
            try
            {
                foreach (var env in envs)
                {
                    Environment.SetEnvironmentVariable(env.Value, env.Value);
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"SetEnvironmentVariable Err:{ex.Message}");
            }

        }
        private void SetLibraryPath(string[] libPaths)
        {
            try
            {
                string currentLibraryPath = Environment.GetEnvironmentVariable("LD_LIBRARY_PATH") ?? string.Empty;
                foreach (string path in libPaths)
                {
                    if (!currentLibraryPath.Contains(path))
                    {
                        if (currentLibraryPath != string.Empty)
                        {
                            currentLibraryPath += ":";
                        }
                        currentLibraryPath += path;
                    }
                }
                Global.WriteLog($"Set {AppFullName}  LD_LIBRARY_PATH: {currentLibraryPath} ");

                Environment.SetEnvironmentVariable("LD_LIBRARY_PATH", currentLibraryPath);
            }
            catch (Exception ex)
            {
                throw new Exception($"SetEnvironmentVariable LD_LIBRARY_PATH Err:{ex.Message}");
            }

        }
    }
    public class AppEntityCollection : ICollection<AppEntity>
    {
        private List<AppEntity> appEntities = new List<AppEntity>();
        public List<AppEntity> AppEntities => appEntities;
        public int Count => appEntities.Count;

        public bool IsReadOnly => false;

        public void Add(AppEntity item)
        {
            if (item != null && !Contains(item))
                appEntities.Add(item);
        }
        public void Clear()
        {
            appEntities.Clear();
        }
        public bool Contains(AppEntity item)
        {
            return appEntities.Any(a => a.Equals(item));
        }

        public void CopyTo(AppEntity[] array, int arrayIndex)
        {
            return;
        }

        public IEnumerator<AppEntity> GetEnumerator()
        {
            return appEntities.GetEnumerator();
        }

        public bool Remove(AppEntity item)
        {
            if (Contains(item))
            {
                Global.RemoveApp(item.AppName);
                //删除配置文件
                return appEntities.Remove(item);
            }

            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class PTaskParm
    {
        /// <summary>
        /// 执行时间 界面展示用
        /// </summary>
        [JsonIgnore]
        public string RunTimeText => $"{Hour.ToString("00")}:{Minute.ToString("00")}:{Second.ToString("00")}";
        public int TaskDay { get; set; }
        [JsonIgnore]
        public string TaskDayText
        {
            get
            {
                string dayText = string.Empty;
                switch (PTaskCycle)
                {
                    case PTaskCycle.None:
                        dayText = string.Empty;
                        break;
                    case PTaskCycle.Day:
                        dayText = "每天";
                        break;
                    case PTaskCycle.Week:
                        dayText = Global.GetWeekText(TaskDay);
                        break;
                    case PTaskCycle.Month:
                        dayText = $"每月{TaskDay}号";
                        break;
                }
                return dayText;
            }
        }
        [JsonIgnore]
        public DayOfWeek DayOfWeek => Global.ConvertDayOfWeek(TaskDay);
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        /// <summary>
        /// 上次执行时间
        /// </summary>
        [JsonIgnore]
        public DateTime LastRunTime { get; set; } = DateTime.Now;
        public PTaskCycle PTaskCycle { get; set; } = PTaskCycle.Month;
        public string PCycleText
        {
            get
            {
                switch (PTaskCycle)
                {
                    case PTaskCycle.Month:
                        return "月";
                    case PTaskCycle.Week:
                        return "周";
                    case PTaskCycle.Day:
                        return "天";
                    default:
                        return string.Empty;
                }
            }
        }
        private PTaskParm() { }
        public PTaskParm(PTaskCycle pTaskCycle, int taskDay, int hour, int minute, int second)
        {
            if (pTaskCycle == PTaskCycle.Week)
            {
                TaskDay = Global.GetDayOfWeek(taskDay);
            }
            else if (pTaskCycle == PTaskCycle.Month)
            {
                TaskDay = Global.GetDayOfMonth(taskDay);
            }
            Hour = Global.GetTimeNumber(hour, 0, 24);
            Minute = Global.GetTimeNumber(minute, 0, 60);
            Second = Global.GetTimeNumber(second, 0, 60);
            PTaskCycle = pTaskCycle;
        }

    }
    public enum PTaskCycle
    {
        None,
        Day,
        Week,
        Month
    }
    public enum BuildType
    {
        Debug,
        Release
    }
    public enum BuildBit
    {
        Bit32 = 32,
        Bit64 = 64
    }

    public class EnvVariable
    {
        public string Key { get; set; }
        public string Value { get; set; }
        private EnvVariable() { }
        public EnvVariable(string key, string value)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("key is null");
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("value is null");
            Key = key;
            Value = value;
        }
    }
}
