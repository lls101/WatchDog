using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HZDZ.Core;

namespace WatchDog.Commons
{
    public class MyLog : LogFile
    {
        private LogFile _logFile = null;
        public MyLog(string filepath)
        {
            //格式化日志文件名称格式  如果安装小时命令单个log文件 DateTime.Now.ToString("yyyy-MM-dd-HH") + ".log"
            //本项目日志不会很多 按照yyyy-MM-dd区分吧
            string filename = DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            _logFile = new LogFile(filepath, filename);
        }

        private MyLog(string filepath, string filename)
        {
            _logFile = new LogFile(filepath, filename);
        }

        public void LogDate(byte[] buff, int lens)
        {
            string message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
            LogSample(message, buff, lens);
        }

        public void LogDate(string content)
        {
            string message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
            LogSample(message, content);
        }


        public void LogSample(string message, byte[] buff, int lens)
        {
            //string hexbuf = MyLog.ToMinHexSring(buff, lens, 64);
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");

            string hexbuf = MyLog.ToHexString(buff, lens);
            string logText = string.Format(Environment.NewLine +
                                            date + " " + message + Environment.NewLine +
                                            "{0}" + Environment.NewLine,
                                            hexbuf);
            _logFile.Info(logText);
        }

        private void LogSample(string message, string content)
        {
            string logText = string.Format(Environment.NewLine +
                                            message + Environment.NewLine +
                                            content + Environment.NewLine);
            _logFile.Info(logText);
        }

        public void LogSample(string message, params object[] args)
        {
            string content = string.Format(message, args);

            string logText = string.Format(Environment.NewLine +
                                            content + Environment.NewLine);
            _logFile.Info(logText);
        }

        public void LogInfo(string message)
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase method = stackFrame.GetMethod();

            string logText = string.Format(Environment.NewLine +
                                            "[Module] = '{0}'" + Environment.NewLine +
                                            "[Declare] = '{1}'" + Environment.NewLine +
                                            "[Method] = '{2}'" + Environment.NewLine +
                                            "[Message] = '{3}'" + Environment.NewLine,
                                            method.Module.Name,
                                            method.DeclaringType.FullName,
                                            method.Name,
                                            message);
            _logFile.Info(logText);
        }

        public void LogInfo(string message, params object[] args)
        {
            string content = string.Format(message, args);

            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase method = stackFrame.GetMethod();

            string logText = string.Format(Environment.NewLine +
                                            "[Module] = '{0}'" + Environment.NewLine +
                                            "[Declare] = '{1}'" + Environment.NewLine +
                                            "[Method] = '{2}'" + Environment.NewLine +
                                            "[Message] = '{3}'" + Environment.NewLine,
                                            method.Module.Name,
                                            method.DeclaringType.FullName,
                                            method.Name,
                                            content);
            _logFile.Info(logText);
        }

        #region private
        private static string ToHexString(byte[] bytes)
        {
            return MyLog.ToHexString(bytes, bytes.Length);
        }

        private static string ToHexString(byte value)
        {
            return String.Format("{0:X2}", value);
        }

        private static string ToHexString(byte[] bytes, int length)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                stringBuilder.AppendFormat("{0:X2} ", bytes[i]);
            }
            return stringBuilder.ToString();
        }

        private static string ToMinHexSring(byte[] bytes, int length, int minLength)
        {
            string s;

            if (length >= minLength)
            {
                StringBuilder stringBuilder = new StringBuilder();
                for (int i1 = 0; i1 < (minLength - 2); i1++)
                {
                    stringBuilder.AppendFormat("{0:X2} ", bytes[i1]);
                }
                stringBuilder.Append("... ");
                for (int i2 = length - 2; i2 < length; i2++)
                {
                    stringBuilder.AppendFormat("{0:X2} ", bytes[i2]);
                }
                stringBuilder.AppendFormat("({0}B)", length);
                s = stringBuilder.ToString();
            }
            else
            {
                s = MyLog.ToHexString(bytes, length);
            }
            return s;
        }
        #endregion
    }
}
