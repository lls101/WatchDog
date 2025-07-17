using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchDog.Commons
{
    public class BASE_INF
    {
        private static BASE_INF instance;
        private static object lockObj = new object();

        private Dictionary<string, string> datas = null;

        public static BASE_INF Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        instance = new BASE_INF();
                    }
                }
                return instance;
            }
        }

        public BASE_INF()
        {
            datas = new Dictionary<string, string>();
        }

        public void Add(string key, string value)
        {
            if (datas.ContainsKey(key))
            {
                datas[key] = value;
            }
            else
            {
                datas.Add(key, value);
            }
        }

        public string GetVal(string key)
        {
            if (datas.ContainsKey(key))
            {
                return datas[key];
            }
            else
            {
                return "0";
            }
        }
    }

    public static class ST
    {
        public struct 装置监测数据
        {
            public static string CPU负载率 = "CPU负载率";
            public static string 内存使用率 = "内存使用率";
            public static string 磁盘使用率 = "磁盘使用率";
        }
    }
}
