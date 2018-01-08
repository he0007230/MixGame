using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace MyConstants
{
    public class SystemConfig
    {
        #region 常量
        public const string XML = ".xml";
        public const string CONFIG_SUB_FOLDER = "data/";
        public static String CONFIG_FILE_EXTENSION
        {
            get
            {
                return XML;
            }
        }
        #endregion
        #region 属性

        private static String m_resourceFolder;

        /// <summary>
        /// Android资源路径
        /// </summary>
        public static String AndroidPath
        {
            get
            {
                return "/storage/emulated/0/myRes/";
            }
        }

        /// <summary>
        /// PC资源路径
        /// </summary>
        public static String PCPath
        {
            get
            {
                return "D:/myRes/";
            }
        }

        /// <summary>
        /// IOS资源路径
        /// </summary>
        public static String IOSPath
        {
            get
            {
                return String.Concat(Application.persistentDataPath, "/myRes/");
            }
        }

        public static String ResourceFolder
        {
            get
            {
                if (m_resourceFolder == null)
                {

                    if (Application.platform == RuntimePlatform.Android)
                    {
                        if (!Directory.Exists(String.Concat(AndroidPath, CONFIG_SUB_FOLDER)))
                        {
                            Directory.CreateDirectory(String.Concat(AndroidPath, CONFIG_SUB_FOLDER));
                        }
                        m_resourceFolder = String.Concat(AndroidPath, CONFIG_SUB_FOLDER);
                    }
                    else if (Application.platform == RuntimePlatform.IPhonePlayer)
                    {
                        if (!Directory.Exists(String.Concat(IOSPath, CONFIG_SUB_FOLDER)))
                        {
                            Directory.CreateDirectory(String.Concat(IOSPath, CONFIG_SUB_FOLDER));
                        }
                        m_resourceFolder = String.Concat(IOSPath, CONFIG_SUB_FOLDER);
                    }
                    else if (Application.platform == RuntimePlatform.WindowsPlayer)
                    {
                        if (!Directory.Exists(String.Concat(PCPath, CONFIG_SUB_FOLDER)))
                        {
                            Directory.CreateDirectory(String.Concat(PCPath, CONFIG_SUB_FOLDER));
                        }
                        m_resourceFolder = String.Concat(PCPath, CONFIG_SUB_FOLDER);
                    }
                    else if (Application.platform == RuntimePlatform.WindowsEditor)
                    {
                        if (!Directory.Exists(String.Concat(PCPath, CONFIG_SUB_FOLDER)))
                        {
                            Directory.CreateDirectory(String.Concat(PCPath, CONFIG_SUB_FOLDER));
                        }
                        m_resourceFolder = String.Concat(PCPath, CONFIG_SUB_FOLDER);
                    }
                }
                return m_resourceFolder;
            }
        }
        #endregion
    }
}
