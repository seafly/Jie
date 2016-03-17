using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;

namespace com.uceip.DBUtility.iBatis.DataService.Log
{
    public class DataServiceLogConfigDataHelper
    {
        private static object obj = new object();
        private static IList<DataServiceLogConfig> ConfigList { get; set; }

        private static IList<DataServiceLogConfig> GetConfigList(ISqlMapper sqlmap)
        {
            return sqlmap.QueryForList<DataServiceLogConfig>("queryDataServiceLogConfigListT", new Hashtable());
        }

        public static IList<DataServiceLogConfig> GetLogConfigList(ISqlMapper sqlmap)
        {
            if (ConfigList == null)
            {
                lock (obj)
                {
                    if (ConfigList == null)
                    {
                        ConfigList = GetConfigList(sqlmap);
                    }
                }
            }

            return ConfigList;
        }

        public static DataServiceLogConfig GetConfigByClassName(string ClassName, ISqlMapper sqlmap)
        {
            DataServiceLogConfig Config = new DataServiceLogConfig();

            IList<DataServiceLogConfig> List = GetLogConfigList(sqlmap);
            if (List != null && List.Count > 0)
            {
                var ConfigList = from config in List where config.ClassName == ClassName select config;
                foreach (var item in ConfigList)
                {
                    Config = (DataServiceLogConfig)item;
                    break;
                }
            }

            return Config;
        }
    }
}
