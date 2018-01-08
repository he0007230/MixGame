#region 模块信息
// 模块描述：XML解析器。
#endregion

using System;
using System.IO;
using System.Security;
using System.Collections.Generic;
using Mono.Xml;
using LogHelper;


namespace GameLib.Util
{
    /// <summary>
    /// XML解析器。
    /// </summary>
    public class XMLParser
    {

        /// <summary>
        /// 从指定的 URL 加载 map 数据。
        /// </summary>
        /// <param name="fileName">文件的 URL，该文件包含要加载的 XML 文档</param>
        /// <param name="map">map 数据</param>
        /// <returns>是否加载成功</returns>
        public static Boolean LoadIntMap(String fileName, out Dictionary<Int32, Dictionary<String, String>> map)
        {
            try
            {
                SecurityElement xml;
                xml = Load(fileName);
                if (xml == null)
                {
                    LoggerHelper.Error("File not exist: " + fileName);
                    map = null;
                    return false;
                }
                else
                {
                    map = LoadIntMap(xml, fileName);
                    return true;
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Error("Load Int Map Error: " + fileName + "  " + ex.Message);
                map = null;
                return false;
            }
        }

        /// <summary>
        /// 从指定的 XML 文档加载 map 数据。
        /// </summary>
        /// <param name="xml">XML 文档</param>
        /// <returns>map 数据</returns>
        public static Dictionary<Int32, Dictionary<String, String>> LoadIntMap(SecurityElement xml, string source)
        {
            var result = new Dictionary<Int32, Dictionary<String, String>>();

            var index = 0;
            foreach (SecurityElement subMap in xml.Children)
            {
                index++;
                if (subMap.Children == null || subMap.Children.Count == 0)
                {
                    LoggerHelper.Warning("empty row in row NO." + index + " of " + source);
                    continue;
                }
                Int32 key = Int32.Parse((subMap.Children[0] as SecurityElement).Text);
                if (result.ContainsKey(key))
                {
                    LoggerHelper.Warning(String.Format("Key {0} already exist, in {1}.", key, source));
                    continue;
                }

                var children = new Dictionary<String, String>();
                result.Add(key, children);
                for (int i = 1; i < subMap.Children.Count; i++)
                {
                    var node = subMap.Children[i] as SecurityElement;
                    //对属性名称部分后缀进行裁剪
                    string tag;
                    if (node.Tag.Length < 3)
                    {
                        tag = node.Tag;
                    }
                    else
                    {
                        var tagTial = node.Tag.Substring(node.Tag.Length - 2, 2);
                        if (tagTial == "_i" || tagTial == "_s" || tagTial == "_f" || tagTial == "_l" || tagTial == "_k" || tagTial == "_m")
                            tag = node.Tag.Substring(0, node.Tag.Length - 2);
                        else
                            tag = node.Tag;
                    }

                    if (node != null && !children.ContainsKey(tag))
                    {
                        if (String.IsNullOrEmpty(node.Text))
                            children.Add(tag, "");
                        else
                            children.Add(tag, node.Text.Trim());
                    }
                    else
                        LoggerHelper.Warning(String.Format("Key {0} already exist, index {1} of {2}.", node.Tag, i, node.ToString()));
                }
            }
            return result;
        }

        /// <summary>
        /// 从指定的 XML 文档加载 map 数据。
        /// </summary>
        /// <param name="xml">XML 文档</param>
        /// <returns>map 数据</returns>
        public static Dictionary<String, Dictionary<String, String>> LoadMap(SecurityElement xml)
        {
            var result = new Dictionary<String, Dictionary<String, String>>();

            foreach (SecurityElement subMap in xml.Children)
            {
                String key = (subMap.Children[0] as SecurityElement).Text.Trim();
                if (result.ContainsKey(key))
                {
                    LoggerHelper.Warning(String.Format("Key {0} already exist, in {1}.", key, xml.ToString()));
                    continue;
                }

                var children = new Dictionary<string, string>();
                result.Add(key, children);
                for (int i = 1; i < subMap.Children.Count; i++)
                {
                    var node = subMap.Children[i] as SecurityElement;
                    if (node != null && !children.ContainsKey(node.Tag))
                    {
                        if (String.IsNullOrEmpty(node.Text))
                            children.Add(node.Tag, "");
                        else
                            children.Add(node.Tag, node.Text.Trim());
                    }
                    else
                        LoggerHelper.Warning(String.Format("Key {0} already exist, index {1} of {2}.", node.Tag, i, node.ToString()));
                }
            }
            return result;
        }

        /// <summary>
        /// 从指定的 URL 加载 XML 文档。
        /// </summary>
        public static SecurityElement Load(String fileName)
        {
            String xmlText = LoadFile(fileName);
            if (String.IsNullOrEmpty(xmlText))
                return null;
            else
                return LoadXML(xmlText);
        }
        public static String LoadFile(String fileName)
        {
            //LoggerHelper.Debug(fileName);
            if (File.Exists(fileName))
                using (StreamReader sr = File.OpenText(fileName))
                    return sr.ReadToEnd();
            else
                return String.Empty;
        }
        /// <summary>
        /// 从指定的字符串加载 XML 文档。
        /// </summary>
        /// <param name="xml">包含要加载的 XML 文档的字符串。</param>
        /// <returns>编码安全对象的 XML 对象模型。</returns>
        public static SecurityElement LoadXML(String xml)
        {
            try
            {
                SecurityParser securityParser = new SecurityParser();
                securityParser.LoadXml(xml);
                return securityParser.ToXml();
            }
            catch (Exception ex)
            {
                LoggerHelper.Except(ex);
                return null;
            }
        }
    }
}
