#region 模块信息
//模块描述：配置数据抽象类
#endregion
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using LogHelper;

namespace GameData
{
    public abstract class GameData
    {
        public int id { get; protected set; }

        protected static Dictionary<int, T> GetDataMap<T>()
        {
            Dictionary<int, T> dataMap;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var type = typeof(T);
            var fileNameField = type.GetField("fileName");
            if (fileNameField != null)
            {
                var fileName = fileNameField.GetValue(null) as String;
                var result = GameDataControler.Instance.FormatData(fileName, typeof(Dictionary<int, T>), type);
                dataMap = result as Dictionary<int, T>;
            }
            else
            {
                dataMap = new Dictionary<int, T>();
            }
            sw.Stop();
            LoggerHelper.Info(String.Concat(type,"time:",sw.ElapsedMilliseconds));
            return dataMap;
        }
    }
    public abstract class GameData<T> : GameData where T : GameData<T>
    {
        private static Dictionary<int, T> m_dataMap;

        public static Dictionary<int, T> dataMap
        {
            get
            {
                if (m_dataMap == null)
                    m_dataMap = GetDataMap<T>();
                return m_dataMap;
            }
            set { m_dataMap = value; }
        }
    }

    public abstract class DataLoader
    {
        protected static readonly bool m_isPreloadData = true;
        protected readonly String m_resourcePath;
        protected readonly String m_fileExtention;
        protected readonly bool m_isUseOutterConfig;
        protected Action<int, int> m_progress;
        protected Action m_finished;

        protected DataLoader()
        {
            m_isUseOutterConfig = SystemC
        }
    }
}
