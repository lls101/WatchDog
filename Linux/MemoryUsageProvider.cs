using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace WatchDog.Linux
{
    public class WindowsMemoryUsageProvider : MemoryUsageProvider
    {
        private static readonly PerformanceCounter MemCommittedBytesPerfCounter =
            new PerformanceCounter(categoryName: "Memory", counterName: "Committed Bytes", readOnly: true);

        private static readonly PerformanceCounter MemUsagePerfCounter =
            new PerformanceCounter(categoryName: "Memory", counterName: "% Committed Bytes In Use", readOnly: true);

        public override ulong GetCommittedBytes()
        {
            return (ulong)MemCommittedBytesPerfCounter.NextValue();
        }

        public override float GetUsage()
        {
            return (float)MemUsagePerfCounter.NextValue();
        }
    }

    public class LinuxMemoryUsageProvider : MemoryUsageProvider
    {
        public LinuxMemoryUsageProvider()
        {
        }

        public override ulong GetCommittedBytes()
        {
            Dictionary<string, ulong> memInfo = LinuxProcFS.ReadMemInfo();

            ulong memTotal = memInfo[MemInfoConstants.MemTotal];
            ulong memFree = memInfo[MemInfoConstants.MemFree];
            ulong memAvail = memInfo[MemInfoConstants.MemAvailable];
            ulong swapTotal = memInfo[MemInfoConstants.SwapTotal];
            ulong swapFree = memInfo[MemInfoConstants.SwapFree];

            return (memTotal - memAvail) * 1024;
        }

        public override float GetUsage()
        {
            Dictionary<string, ulong> memInfo = LinuxProcFS.ReadMemInfo();

            ulong memTotal = memInfo[MemInfoConstants.MemTotal];
            ulong memAvail = memInfo[MemInfoConstants.MemAvailable];

            return (float)((float)(memTotal - memAvail) / (float)memTotal) * 100f;
        }
    }

    public static class MemInfoConstants
    {
        /*
        ** Source code: https://git.kernel.org/pub/scm/linux/kernel/git/torvalds/linux.git/tree/fs/proc/meminfo.c
        */
        public const string MemTotal = nameof(MemTotal);

        public const string MemFree = nameof(MemFree);

        public const string SwapTotal = nameof(SwapTotal);

        public const string SwapFree = nameof(SwapFree);

        public const string VmallocTotal = nameof(VmallocTotal);

        public const string VmallocUsed = nameof(VmallocUsed);

        public const string MemAvailable = nameof(MemAvailable);
    }


    public abstract class MemoryUsageProvider
    {
        private static MemoryUsageProvider instance;
        private static object lockObj = new object();

        public static MemoryUsageProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                        {
                            instance = new WindowsMemoryUsageProvider();
                        }
                        else
                        {
                            instance = new LinuxMemoryUsageProvider();
                        }
                    }
                }

                return instance;
            }
        }

        public abstract ulong GetCommittedBytes();

        public abstract float GetUsage();
    }

    /// <summary>
    /// This class contains method to read data from files under /proc directory on Linux.
    /// </summary>
    public static class LinuxProcFS
    {
        internal const string RootPath = "/proc/";

        /// <summary>
        /// Reads data from the /proc/meminfo file.
        /// </summary>
        public static Dictionary<string, ulong> ReadMemInfo()
        {
            // Currently /proc/meminfo contains 51 rows on Ubuntu 18.
            Dictionary<string, ulong> result = new Dictionary<string, ulong>(capacity: 64);

            // Source code: https://git.kernel.org/pub/scm/linux/kernel/git/torvalds/linux.git/tree/fs/proc/meminfo.c
            using (StreamReader sr = new StreamReader("/proc/meminfo", encoding: Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int colonIndex = line.IndexOf(':');

                    string key = line.Substring(0, colonIndex);

                    ulong value = LinuxProcFS.ReadUInt64(line, colonIndex + 1);
                    result.Add(key, value);
                }
            }

            return result;
        }

        private static ulong ReadUInt64(string line, int startIndex)
        {
            ulong result = 0;

            while (line[startIndex] == ' ')
            {
                ++startIndex;
            }

            int len = line.Length;

            while (startIndex < len)
            {
                char c = line[startIndex];

                int d = c - '0';

                if (d >= 0 && d <= 9)
                {
                    result = checked((result * 10ul) + (ulong)d);
                    ++startIndex;
                }
                else
                {
                    break;
                }
            }

            return result;
        }
    }
}
