using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace WatchDog
{
    public static class AppProcessInfo
    {
        public static ConcurrentDictionary<int, CpuUsage> AppCpuUsage = new ConcurrentDictionary<int, CpuUsage>();
        /// <summary>
        /// 获取系统的总物理内存（KB）
        /// </summary>
        private static ulong GetTotalSystemMemory()
        {
            string[] memInfo = File.ReadAllLines("/proc/meminfo");
            foreach (string line in memInfo)
            {
                if (line.StartsWith("MemTotal:"))
                {
                    string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    return ulong.Parse(parts[1]); // 返回 KB
                }
            }
            return 0;
        }

        /// <summary>
        /// 获取进程的物理内存占用（RSS，KB）
        /// </summary>
        private static ulong GetProcessRssMemory(int pid)
        {
            string statusPath = $"/proc/{pid}/status";
            string[] statusLines = File.ReadAllLines(statusPath);

            foreach (string line in statusLines)
            {
                if (line.StartsWith("VmRSS:"))
                {
                    string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    return ulong.Parse(parts[1]); // 返回 KB
                }
            }
            return 0;
        }

        /// <summary>
        /// 计算进程的内存使用率（百分比）
        /// </summary>
        public static double GetProcessMemoryUsagePercent(int pid)
        {
            ulong totalMemory = GetTotalSystemMemory();
            ulong processMemory = GetProcessRssMemory(pid);
            Console.WriteLine($"MemTotal:{totalMemory} KB");
            Console.WriteLine($"{pid}_Mem:{processMemory} KB");
            if (totalMemory == 0) return 0;
            return (double)processMemory / totalMemory;
        }
        private static (ulong totalCpuTime, ulong totalAllTime) GetCpuTimes()
        {
            string[] cpuStats = File.ReadAllLines("/proc/stat")[0]
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            ulong user = ulong.Parse(cpuStats[1]);
            ulong nice = ulong.Parse(cpuStats[2]);
            ulong system = ulong.Parse(cpuStats[3]);
            ulong idle = ulong.Parse(cpuStats[4]);
            ulong iowait = ulong.Parse(cpuStats[5]);
            ulong irq = ulong.Parse(cpuStats[6]);
            ulong softirq = ulong.Parse(cpuStats[7]);

            ulong totalCpuTime = user + nice + system + irq + softirq;
            ulong totalAllTime = totalCpuTime + idle + iowait;

            return (totalCpuTime, totalAllTime);
        }
        public static double GetProcessCpuUsage(int pid)
        {

            try
            {
                string statPath = $"/proc/{pid}/stat";
                string[] statLines = File.ReadAllLines(statPath);
                double usageValue = 0.00d;
                string[] statValues = statLines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // 获取进程 CPU 时间（单位：时钟滴答数，通常 100 ticks/s）
                ulong.TryParse(statValues[13], out ulong utime);
                ulong.TryParse(statValues[14], out ulong stime);
                // ulong.TryParse(statValues[21], out ulong starttime);
                Console.WriteLine($"GetLastCpuCore{pid}->{statValues[38]}");
                // 读取进程的 CPU 时间
                var processTotalTime = utime + stime;

                // 获取系统总运行时间
                string[] cpuStats = File.ReadAllLines("/proc/stat")[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                ulong cpuTotalTime = 0;
                //读取总CPU时间
                //各个下标表示含义
                //ulong user = ulong.Parse(cpuStats[1]);    // 用户态时间
                //ulong nice = ulong.Parse(cpuStats[2]);    // 低优先级用户态时间
                //ulong system = ulong.Parse(cpuStats[3]);  // 内核态时间
                //ulong idle = ulong.Parse(cpuStats[4]);    // 空闲时间
                //ulong iowait = ulong.Parse(cpuStats[5]);  // I/O 等待时间
                //ulong irq = ulong.Parse(cpuStats[6]);     // 硬中断时间
                //ulong softirq = ulong.Parse(cpuStats[7]); // 软中断时间
                //ulong totalCpuTime = user + nice + system + irq + softirq;
                //ulong totalAllTime = totalCpuTime + idle + iowait;
                for (int i = 1; i < cpuStats.Length; i++)
                {
                    ulong.TryParse(cpuStats[i], out var tmpTime);
                    cpuTotalTime += tmpTime;
                }

                var currentUsage = new CpuUsage(processTotalTime, cpuTotalTime);
                //两次CPU取样 取差值
                if (AppCpuUsage.TryGetValue(pid, out var preUsage))
                {
                    var preProcessTotaltime = preUsage.ProcessTotaltime;
                    var preCpuTotaltime = preUsage.CPUTotaltime;
                    //Console.WriteLine($"preProcessTotaltime={preProcessTotaltime}，preCpuTotaltime={preCpuTotaltime}");
                    //Console.WriteLine($"currentProcessTotaltime={cpuTotalTime}，currentTotalTime={cpuTotalTime}");
                    // 计算 CPU 使用率 
                    usageValue = ((processTotalTime - preProcessTotaltime) * 1.00d) /
                                     ((cpuTotalTime - preCpuTotaltime) * 1.00d);
                    AppCpuUsage.TryUpdate(pid, currentUsage, preUsage);
                }
                else
                {
                    AppCpuUsage.TryAdd(pid, currentUsage);
                }
                var cpuCores = Environment.ProcessorCount;
                var oneUsage = usageValue * cpuCores > 1 ? 1 : usageValue * cpuCores;

                Console.WriteLine($"cpuCores={cpuCores} 总的CPU使用率={usageValue * 100:F2}%,单核CPU使用率={(oneUsage * 100):F2}%");

                return oneUsage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static int GetThreadCpuCores(int pid)
        {
            string taskDir = $"/proc/{pid}/task";
            var cpuCore = 0;
            foreach (string tidDir in Directory.GetDirectories(taskDir))
            {
                int tid = int.Parse(Path.GetFileName(tidDir));
                if (tid == pid)
                {
                    string statPath = $"{tidDir}/stat";
                    string[] statData = File.ReadAllText(statPath).Split(' ');
                    int.TryParse(statData[38], out cpuCore);
                }
            }
            return cpuCore;
        }
        private static int GetLastCpuCore(int pid)
        {
            string statPath = $"/proc/{pid}/stat";
            var info = File.ReadAllText(statPath);
            string[] statData = info.Split(' ');
            int.TryParse(statData[38], out int lastCpuCore);  // 第 39 个字段（从 0 开始计数）
            return lastCpuCore;
        }

    }
    public class CpuUsage
    {
        public ulong ProcessTotaltime { get; set; }
        public ulong CPUTotaltime { get; set; }
        private CpuUsage() { }
        public CpuUsage(ulong processTime, ulong cpuTotaltime)
        {
            this.ProcessTotaltime = processTime;
            this.CPUTotaltime = cpuTotaltime;
        }
    }
}
