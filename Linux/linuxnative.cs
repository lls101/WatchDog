using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;


namespace WatchDog.Linux
{

    public class HardwareInfoBase
    {
        private static bool ValidCmd(string cmd)
        {

            return true;
            //if ((cmd == "service") ||
            //    (cmd == "kill") ||
            //    (cmd.Contains("sl61850")) ||
            //    (cmd.Contains("myconf")) ||
            //    (cmd.Contains("shenji")) ||
            //    (cmd == "/bin/bash") ||
            //    (cmd.Contains("czp")) ||
            //     (cmd.Contains("Hmi")) ||
            //      (cmd.Contains("WFDB"))
            //    )
            //{
            //    return true;
            //}
            //Global.WriteLog($"cmd={cmd} 非法");
            //return false;
        }
        public static bool RunLinuxCmd(string arg, bool redir, bool no_window)
        {
            var cmd = "/bin/bash";
            var args = $"-c '{arg}'";
            var pid = StartProcess(cmd, args, no_window, redir);
            return pid != null;
        }
        public static Process RunLinuxCmd(string arg)
        {
            var cmd = "/bin/bash";
            var args = $"-c '{arg}'";
            Process process = StartProcess(cmd, args, true, false);
            return process;
        }

        internal static Process StartProcess(string cmd, string args, bool no_window = true, bool redir = true, string filePath = "")
        {
            if (!ValidCmd(cmd)) return null;

            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = redir;
            process.StartInfo.RedirectStandardInput = redir;
            process.StartInfo.RedirectStandardError = redir;
            process.StartInfo.FileName = cmd;
            if (!string.IsNullOrEmpty(filePath))
            {
                process.StartInfo.WorkingDirectory = filePath;
            }
            process.StartInfo.Arguments = args;
            process.StartInfo.CreateNoWindow = no_window;
            try
            {
                if (!process.Start())
                {
                    Global.WriteLog($"cmd={cmd} args={args} 执行失败");
                }
            }
            catch (Exception ex)
            {
                process = null;
                Global.WriteLog($"cmd={cmd} args={args}执行错误,错误:{ex.Message}");
            }

            return process;
        }

        public static string ReadProcessOutput(string cmd, string args)
        {
            try
            {
                string result = string.Empty;

                using (Process process = StartProcess(cmd, args))
                {
                    if (process != null)
                    {
                        using (StreamReader streamReader = process.StandardOutput)
                        {
                            result = streamReader.ReadToEnd().Trim();
                        }

                        var err = process.StandardError.ReadToEnd();
                        if (!string.IsNullOrEmpty(err))
                        {
                            Global.WriteLog($"cmd={cmd} ReadOutput失败,失败详情:{err}");
                        }
                        process.WaitForExit(3000);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
