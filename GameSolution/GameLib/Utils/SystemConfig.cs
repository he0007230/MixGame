#region 模块信息
//模块描述：系统参数配置
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using LogHelper;
using System.IO;


namespace GameLib.Utils
{
    public partial class SystemConfig
    {
        #region 常量
        public const string XML = ".xml";
        public const string CONFIG_SUB_FOLDER = "data/";
        public static String CONFIG_FILE_EXTENSION
        {
            get
            {
                return SystemSwitch.ReleaseMode ? XML : String.Empty;
            }
        }
        #endregion
        #region 属性

        private static String m_resourceFolder;
        private static LocalSetting m_instance;
        private static int m_selectedServerIndex;

        public static int SelectedServerIndex
        {
            get { return SystemConfig.m_selectedServerIndex; }
            set { SystemConfig.m_selectedServerIndex = value; }
        }

        /// <summary>
        /// Android资源路径
        /// </summary>
        public static String AndroidPath
        {
            get
            {
                return String.Concat(Application.persistentDataPath,"/MyGameRes/");
            }
        }

        /// <summary>
        /// PC资源路径
        /// </summary>
        public static String PCPath
        {
            get
            {
                var path = Application.dataPath + "/../MyGameRes/";
                LoggerHelper.Debug("PCPath:"+path);
                return path;
            }
        }

        /// <summary>
        /// IOS资源路径
        /// </summary>
        public static String IOSPath
        {
            get 
            {
                return String.Concat(Application.persistentDataPath,"/MyGameRes/");
            }
        }

        public static String ResourceFolder
        {
            get
            {
                if (m_resourceFolder == null)
                {
                    if (SystemSwitch.ReleaseMode)
                    {
                        m_resourceFolder = OutterPath;
                    }
                    else
                    {
                        m_resourceFolder = String.Empty;
                    }
                }
                return m_resourceFolder;
            }
        }

        public static String OutterPath
        {
            get 
            {
                LoggerHelper.Debug("OutterPath->Application.platform:" + Application.platform);
                if (Application.platform == RuntimePlatform.Android)
                    return AndroidPath;
                else if (Application.platform == RuntimePlatform.IPhonePlayer)
                    return IOSPath;
                else if (Application.platform == RuntimePlatform.WindowsPlayer)
                    return PCPath;
                else if (Application.platform == RuntimePlatform.WindowsEditor)
                    return IOSPath;
                else
                    return "";

            }
        }
        public static bool IsUseOutterConfig
        {
            get
            {
                LoggerHelper.Debug("IsUseOutterConfig->Application.platform:" + Application.platform);
                if (Application.platform == RuntimePlatform.Android)
                {
                    if (Directory.Exists(String.Concat(AndroidPath, CONFIG_SUB_FOLDER)))
                    {
                        return true;
                    }
                }
                else if (Application.platform == RuntimePlatform.IPhonePlayer)
                {
                    if (Directory.Exists(String.Concat(IOSPath, CONFIG_SUB_FOLDER)))
                    {
                        return true;
                    }
                }
                else if (Application.platform == RuntimePlatform.WindowsPlayer)
                {
                    if (Directory.Exists(String.Concat(PCPath, CONFIG_SUB_FOLDER)))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public static LocalSetting Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new LocalSetting();
                }
                return m_instance;
            }
            set 
            {
                m_instance = value;
            }
        }

        #endregion
    }
    public class LocalSetting
    {
        public int id { get; set; }
        public LocalSetting(){}
    }
}
