#region 模块信息
//模块描述：配置数据抽象类
#endregion
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using LogHelper;
using GameLib.Utils;
using System.Reflection;
using GameLib.Util;
using UnityEngine;
using MyConstants;

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
                UnityEngine.Debug.Log(String.Concat(
                    SystemConfig.ResourceFolder, fileName, ".xml"));
                var result = GameDataControler.Instance.FormatData(String.Concat(
                    SystemConfig.ResourceFolder, fileName, ".xml"), typeof(Dictionary<int, T>), type);
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

    public class GameDataControler : DataLoader
    {
        private List<Type> m_defaultData = new List<Type>() {};

        private static GameDataControler m_instance;

        public static GameDataControler Instance
        {
            get { return m_instance; }
        }

        static GameDataControler()
        {
            m_instance = new GameDataControler();
        }

        public static void Init(Action<int, int> progress = null, Action finished = null)
        {
            //XML
            m_instance.LoadData(m_instance.m_defaultData, m_instance.FormatData, null);
            if (m_isPreloadData)
            {
                Action action = () => { m_instance.InitAsynData(m_instance.FormatData, progress, finished); };
                action.BeginInvoke(null, null);
            }
            else
            {
                finished();
            }
        }

        /// <summary>
        /// 进行读取数据准备工作和调用处理方法
        /// </summary>
        /// <param name="formatData">格式化数据方法</param>
        /// <param name="progress">处理进度回调</param>
        /// <param name="finished">处理完成回调</param>
        private void InitAsynData(Func<string, Type, Type, object> formatData, Action<int, int> progress, Action finished)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                List<Type> gameDataType = new List<Type>();
                Assembly ass = typeof(GameDataControler).Assembly;
                var types = ass.GetTypes();
                foreach (var item in types)
                {
                    if (item.Namespace == "GameData")
                    {
                        var type = item.BaseType;
                        while (type != null)
                        {
                            if (type == typeof(GameData) || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(GameData<>)))
                            {
                                if (!m_defaultData.Contains(item))
                                    gameDataType.Add(item);
                                break;
                            }
                            else
                            {
                                type = type.BaseType;
                            }
                        }
                    }
                }
                LoadData(gameDataType, formatData, progress);
                sw.Stop();
                LoggerHelper.Debug("Asyn GameData init time: " + sw.ElapsedMilliseconds);
                GC.Collect();
                if (finished != null)
                {
                    finished();
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Error("InitData Error: "+ex.Message);
            }
        }

        /// <summary>
        /// 加载数据逻辑
        /// </summary>
        /// <param name="gameDataType">加载数据列表</param>
        /// <param name="formatData">处理数据方法</param>
        /// <param name="progress">数据处理进度</param>
        private void LoadData(List<Type> gameDataType, Func<string, Type, Type, object> formatData, Action<int, int> progress)
        {
            var count = gameDataType.Count;
            var i = 1;
            foreach (var item in gameDataType)
            {
                var p = item.GetProperty("dataMap",~BindingFlags.DeclaredOnly);
                var fileNameField = item.GetField("fileName");
                if (p != null && fileNameField != null)
                {
                    var fileName = fileNameField.GetValue(null) as String;
                    var result = formatData(String.Concat(m_resourcePath, fileName, m_fileExtention), p.PropertyType, item);
                    p.GetSetMethod().Invoke(null, new object[] { result });
                }
                if (progress != null)
                    progress(i,count);
                i++;
            }
        }
        public object FormatData(string fileName, Type dicType, Type type)
        {
            UnityEngine.Debug.Log("FormatData  fileName:"+fileName+"  dicType:"+dicType+"  Type:"+type);
            return FormatXMLData(fileName, dicType, type);
        }

        private object FormatXMLData(string fileName, Type dicType, Type type)
        {
            object result = null;
            try
            {
                result = dicType.GetConstructor(Type.EmptyTypes).Invoke(null);
                Dictionary<Int32, Dictionary<String, String>> map;//int32为id string 为属性名 string 为属性值
                if (XMLParser.LoadIntMap(fileName, out map))
                {
                    var props = type.GetProperties();//获取实体属性
                    foreach (var item in map)
                    {
                        var t = type.GetConstructor(Type.EmptyTypes).Invoke(null);//构造实体实例
                        foreach (var prop in props)
                        {
                            if (prop.Name == "id")
                            {
                                prop.SetValue(t, item.Key, null);
                            }
                            else
                            {
                                if (item.Value.ContainsKey(prop.Name))
                                {
                                    var value = Utils.GetValue(item.Value[prop.Name], prop.PropertyType);
                                    prop.SetValue(t, value, null);
                                }
                            }
                        }
                        dicType.GetMethod("Add").Invoke(result, new object[] { item.Key, t });
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Error("FormatDataError:"+fileName+"     "+ex.Message);
            }
            return result;
        }
    }

    public abstract class DataLoader
    {
        protected static readonly bool m_isPreloadData = true;
        protected readonly String m_resourcePath;
        protected readonly String m_fileExtention;
        protected Action<int, int> m_progress;
        protected Action m_finished;

        protected DataLoader()
        {
            m_resourcePath = SystemConfig.ResourceFolder;
            m_fileExtention = SystemConfig.XML;
        }
    }
}
