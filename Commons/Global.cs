using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using WatchDog.Commons;
using static System.Net.Mime.MediaTypeNames;

namespace WatchDog
{
    public class Global
    {
        #region Fields
        /// <summary>
        /// 本程序安装目录
        /// </summary>
        public static readonly string WatchDogPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        /// <summary>
        /// appSetting保存目录
        /// </summary>
        public static readonly string appEntityPath = Path.Combine(WatchDogPath, "AppEntities");
        /// <summary>
        /// 所有app
        /// </summary>
        public static AppEntityCollection WatchApps = new AppEntityCollection();
        public static readonly string[] Weeks = new string[] { "1", "2", "3", "4", "5", "6", "7", };
        //防止二月特殊情况,计划任务按月只支持1-28
        public static readonly string[] Days = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14",
                                              "15", "16", "17", "18", "19", "20", "21", "22","23","24","25","26","27","28"};
        #endregion
        #region Methods
        /// <summary>
        /// 限定每月只能在1-28号之间执行任务
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int GetDayOfMonth(int num)
        {
            if (num < 1 || num > 28)
            {
                throw new ArgumentException("无效的数字日期。请提供1到28之间的数字。");
            }
            return num;
        }
        public static int GetTimeNumber(int num, int minValue, int maxValue)
        {
            if (num < minValue || num > maxValue)
            {
                throw new ArgumentException($"无效的数字。请提供{minValue}到{maxValue}之间的数字。");
            }
            return num;
        }
        public static int GetDayOfWeek(int num)
        {
            if (num < 1 || num > 7)
            {
                throw new ArgumentException($"无效的数字。请提供1到7之间的数字。");
            }
            return num;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static DayOfWeek ConvertDayOfWeek(int num)
        {
            switch (num)
            {
                case 1: return DayOfWeek.Monday;
                case 2: return DayOfWeek.Tuesday;
                case 3: return DayOfWeek.Wednesday;
                case 4: return DayOfWeek.Thursday;
                case 5: return DayOfWeek.Friday;
                case 6: return DayOfWeek.Saturday;
                case 7: return DayOfWeek.Sunday;
                default:
                    throw new ArgumentException("无效的数字。请提供1到7之间的数字。");
            }

        }
        public static string GetWeekText(int num)
        {
            var value = string.Empty;
            switch (num)
            {
                case 1:
                    value = "每周一";
                    break;
                case 2:
                    value = "每周二";
                    break;
                case 3:
                    value = "每周三";
                    break;
                case 4:
                    value = "每周四";
                    break;
                case 5:
                    value = "每周五";
                    break;
                case 6:
                    value = "每周六";
                    break;
                case 7:
                    value = "每周日";
                    break;
            }
            return value;
        }
        public static bool IsFileExist(string path, string fileName)
        {
            if (!Directory.Exists(path))
                return false;
            string[] files = Directory.GetFiles(path, fileName);
            if (files.Length == 0)
                return false;
            var exists = files?.Length == 1;
            return exists;
        }
        public static T EnumParse<T>(string value) where T : Enum
        {
            try
            {
                var t = (T)Enum.Parse(typeof(T), value);
                return t;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static T EnumParse<T>(object obj) where T : Enum
        {
            try
            {
                var value = obj as string;
                if (value == null)
                {
                    value = obj?.ToString() ?? string.Empty;
                }
                return EnumParse<T>(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void SaveApps(string ext = "json")
        {
            try
            {
                if (WatchApps.Any())
                {
                    foreach (var app in WatchApps)
                    {
                        SaveApp(app, ext);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static bool SaveApp(AppEntity appEntity, string ext = "json")
        {
            try
            {
                var fileFullName = Path.Combine(Global.appEntityPath, $"{appEntity.AppName}.{ext}");
                string jsonStr = JsonConvert.SerializeObject(appEntity);
                using (StreamWriter sw = new StreamWriter(fileFullName, false, Encoding.UTF8))
                {
                    sw.WriteLine(jsonStr);
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static void LoadApps(string ext = "json")
        {
            try
            {
                WatchApps.Clear();
                if (!Directory.Exists(appEntityPath))
                {
                    Directory.CreateDirectory(appEntityPath);
                    return;
                }
                string[] files = Directory.GetFiles(appEntityPath, $"*.{ext}");
                foreach (string file in files)
                {
                    string content = File.ReadAllText(file, Encoding.UTF8);
                    var app = JsonConvert.DeserializeObject<AppEntity>(content);
                    if (app != null)
                        WatchApps.Add(app);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void RemoveApp(string appName, string ext = "json")
        {
            string[] files = Directory.GetFiles(appEntityPath, $"*.{ext}");
            var findFileName = Path.Combine(appEntityPath, $"{appName}.{ext}");
            File.Delete(findFileName);
        }
        public static bool ExistApp(string appName, string ext = "json")
        {
            try
            {
                if (!Directory.Exists(appEntityPath))
                {
                    Directory.CreateDirectory(appEntityPath);
                    return false;
                }
                string[] files = Directory.GetFiles(appEntityPath, $"*.{ext}");
                var findFileName = Path.Combine(appEntityPath, $"{appName}.{ext}");
                var exists = files?.Contains(findFileName) == true;
                return exists;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool ReLoadApp(string appName, string ext = "json")
        {
            if (!Directory.Exists(appEntityPath))
            {
                Directory.CreateDirectory(appEntityPath);
                return false;
            }
            string file = Directory.GetFiles(appEntityPath, $"{appName}.{ext}").FirstOrDefault() ?? string.Empty;
            if (string.IsNullOrEmpty(file))
            {
                string content = File.ReadAllText(file, Encoding.UTF8);
                var app = JsonConvert.DeserializeObject<AppEntity>(content);
                if (app != null)
                {
                    WatchApps.Remove(app);
                    WatchApps.Add(app);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
        #endregion
        #region Tips


        public static DialogResult Tips(string text, bool topMost = false)
        {
            if (topMost)
                return MessageBox.Show(text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            else
                return MessageBox.Show(text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult Tips(IWin32Window owner, string text)
        {
            return MessageBox.Show(owner, text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult Tips(string title, string text)
        {
            return MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult Query(string text)
        {
            return MessageBox.Show(text, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
        public static DialogResult QuestionWithCancle(string text)
        {
            return MessageBox.Show(text, "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }
        public static DialogResult Query(string title, string text)
        {
            return MessageBox.Show(text, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
        public static DialogResult Error(string text)
        {
            return MessageBox.Show(text, "异常信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult Error(string title, string text)
        {
            return MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult Warning(string text)
        {
            return MessageBox.Show(text, "异常信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static DialogResult Warning(string title, string text)
        {
            return MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static int Parse_int(string s)
        {
            int ret = 0;
            if (s == "") return 0;
            try
            {
                ret = int.Parse(s);
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public static float Parse_float(string s)
        {
            float ret = 0;
            if (s == "") return 0;
            try
            {
                ret = float.Parse(s);
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public static string ToHexString(byte[] bytes, int length)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                stringBuilder.AppendFormat("{0:X2} ", bytes[i]);
            }
            return stringBuilder.ToString();
        }

        public static string ToMinHexSring(byte[] bytes, int length, int minLength)
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
                s = Global.ToHexString(bytes, length);
            }
            return s;
        }
        #endregion
        #region Logs
        public static MyLog Log = null;
        public static void WriteLog(string content)
        {
            if (Log == null)
                Log = new MyLog(WatchDogPath);
            Console.WriteLine(DateTime.Now.ToString() + " >： " + content);
            Log.LogDate(content);
        }
        #endregion
    }
}
