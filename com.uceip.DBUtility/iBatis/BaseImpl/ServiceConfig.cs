using System;
using System.Xml;
using System.Collections.Generic;
using IBatisNet.Common.Utilities;
using IBatisNet.DataAccess;
using IBatisNet.DataAccess.Configuration;
using IBatisNet.DataAccess.SessionStore;
using System.IO;
using com.uceip.Common.DEncrypt;
using System.Configuration;

namespace com.uceip.DBUtility.iBatis.BaseImpl
{
    public class ServiceConfig
    {
        private static object _synRoot = new Object();
        private static ServiceConfig _instance;
        private static string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\Config\\";
        private  IDaoManager _daoManager = null;
        private static List<string> daoManageKeyList;
        private static string projectlist = "";

        /// <summary>
        /// Remove public constructor. prevent instantiation.
        /// </summary>
        private ServiceConfig() { }

        static ServiceConfig()
        {
            projectlist = GetCustomConfigNode(fileName + "Project.config", "Project", "MapFile");
        }

        /// <summary>
        /// 获取默认数据链接配置
        /// </summary>
        /// <returns></returns>
        public static ServiceConfig GetInstance()
        {
            return GetInstance("SqlMapDao");
        }

        /// <summary>
        /// 获取数据链接配置
        /// </summary>
        /// <param name="daoid">数据链接配置ID</param>
        /// <returns></returns>
        public static ServiceConfig GetInstance(string daoid)
        {
            if (_instance == null)
            {
                lock (_synRoot)
                {
                    if (_instance == null)
                    {
                        string[] str = projectlist.Split(',');
                        //生成配置文件SqlServerMap.config
                        string name = "SqlServerMap";
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(fileName + name + "Pub.config");
                        XmlNode sqlMapConfig = xmlDoc.DocumentElement;//获取节点
                        XmlNodeList sqlMapList = sqlMapConfig.ChildNodes;//获取所有字节点
                        foreach (XmlNode child in sqlMapList)
                        {
                            if (child.Name.Equals("sqlMaps"))
                            {
                                foreach (string st in str)
                                {
                                    if (File.Exists(fileName + st + "Map.config"))
                                    {
                                        XmlDocument xmlDocOA = new XmlDocument();
                                        xmlDocOA.Load(fileName + st + "Map.config");
                                        XmlNode sqlMapConfigOA = xmlDocOA.DocumentElement;//获取节点
                                        XmlNode sqlMapsOA = sqlMapConfigOA.FirstChild;
                                        XmlNodeList courseNodeList = sqlMapsOA.ChildNodes;
                                        if (courseNodeList != null)
                                        {
                                            foreach (XmlNode courseNode in courseNodeList)
                                            {
                                                if (courseNode.Attributes != null)
                                                {
                                                    string value = courseNode.Attributes.GetNamedItem("resource").Value;
                                                    XmlNode newNode = xmlDoc.CreateElement("sqlMap", xmlDoc.DocumentElement.NamespaceURI);
                                                    CreateAttribute(newNode, "resource", value);
                                                    child.AppendChild(newNode);
                                                }
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        }
                        xmlDoc.Save(fileName + name + ".config");

                        ConfigureHandler handler = new ConfigureHandler(ServiceConfig.Reset);

                        DomDaoManagerBuilder builder = new DomDaoManagerBuilder();
                        builder.ConfigureAndWatch("Config/dao.config", handler);

                        _instance = new ServiceConfig();
                        //清空数据库连接键值列表
                        daoManageKeyList = null;
                    }
                }
            }

            if (daoManageKeyList == null || !daoManageKeyList.Contains(daoid))
            {
                lock (_synRoot)
                {
                    if (daoManageKeyList == null || !daoManageKeyList.Contains(daoid))
                    {
                        // TODO:默认为sqlMapDao指定的Context, 要提供对多个Context的支持.
                        _instance._daoManager = IBatisNet.DataAccess.DaoManager.GetInstance(daoid);
                    }
                }
            }

            return _instance;
        }


        /// <summary>
        /// Reset the singleton
        /// </summary>
        /// <remarks>
        /// Must verify ConfigureHandler signature.
        /// </remarks>
        /// <param name="obj">
        /// </param>
        static public void Reset(object obj)
        {
            _instance = null;
        }

        public IDaoManager DaoManager
        {
            get
            {
                return _daoManager;
            }
        }

        public IDaoManager GetDaoManager(string contextName)
        {
            return IBatisNet.DataAccess.DaoManager.GetInstance(contextName);
        }

        public static XmlAttribute CreateAttribute(XmlNode node, string attributeName, string value)
        {
            try
            {
                XmlDocument doc = node.OwnerDocument;
                XmlAttribute attr = null;
                attr = doc.CreateAttribute(attributeName);
                attr.Value = value;
                node.Attributes.SetNamedItem(attr);
                return attr;
            }
            catch (Exception err)
            {
                string desc = err.Message;
                return null;
            }
        }

        //获取自定义配置文件节点值
        public static string GetCustomConfigNode(string path, string rootname, string NodeName)
        {
            XmlDocument doc = new XmlDocument();

            //加载配置文件
            doc.Load(path);

            //验证根节点是否有有子节点
            XmlNode nodes = doc.SelectSingleNode("/" + rootname);
            if (nodes == null || nodes.ChildNodes == null || nodes.ChildNodes.Count < 1)
                return "";

            //获取节点
            XmlNodeList nodelist = doc.GetElementsByTagName(NodeName);
            if (nodelist.Count > 0)
                return nodelist[0].Attributes["value"].Value;
            else
                return "";
        }
    }
}
