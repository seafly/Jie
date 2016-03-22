using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataAccess;
using IBatisNet.DataMapper;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using com.uceip.DBUtility.iBatis.DataService.Log;
using com.uceip.DBUtility.iBatis.BaseImpl;
using com.uceip.DBUtility.iBatis.Interfaces;
using com.uceip.Common.MyHelper;

namespace com.uceip.DBUtility.iBatis.DataService.Log
{
    public class DataServiceLogHelper
    {
        /// <summary>
        /// 存储添加数据日志
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <param name="Dao"></param>
        /// <param name="sqlmap"></param>
        /// <returns></returns>
        public int Insert<T>(T Model, ISqlMapper sqlmap)
        {
            int result = 0;
            try
            {
                //检验此类是否开启添加数据时插入数据
                DataServiceLogConfig Config = DataServiceLogConfigDataHelper.GetConfigByClassName(Model.GetType().FullName, sqlmap);
                if (Config == null || Config.IsInsert == 0) return -1;

                //定义日志内容
                Dictionary<string, string> LogDic = new Dictionary<string, string>();
                //获取Model各属性值
                PropertyInfo[] propertyList = Model.GetType().GetProperties();
                foreach (PropertyInfo property in propertyList)
                {
                    object obj = property.GetValue(Model, null);
                    if (obj != null)
                    {
                        LogDic.Add(property.Name, obj.ToString());
                    }
                }
                if (LogDic.Count > 0)
                {
                    //获取Model的ID
                    object dataid = Model.GetType().GetProperty("ID").GetValue(Model, null);
                    //存储日志
                    DataServiceLog Log = new DataServiceLog();
                    Log.ID = new SysTableIdDao().generatorId("DataServiceLog", sqlmap);
                    Log.OperateContent = ToJson(LogDic);
                    Log.ClassName = Model.GetType().FullName;
                    Log.DataID = dataid == null ? 0 : Convert.ToInt32(dataid);
                    Log.OperateType = 1;
                    Log.UserID = System.Web.HttpContext.Current.Session[SessionConstant.UserID] == null ? 0 : Convert.ToInt32(System.Web.HttpContext.Current.Session[SessionConstant.UserID]);
                    Log.OperateDate = DateTime.Now;
                    sqlmap.Insert("insertDataServiceLog", Log);
                    result = 1;
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }

            return result;
        }

        /// <summary>
        /// 存储修改数据日志
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="NewModel"></param>
        /// <param name="Dao"></param>
        /// <param name="sqlmap"></param>
        /// <returns></returns>
        public int Update<T>(T NewModel, DaoInterface<T> Dao, ISqlMapper sqlmap)
        {
            int result = 0;
            try
            {
                //检验此类是否开启更新数据时插入数据
                DataServiceLogConfig Config = DataServiceLogConfigDataHelper.GetConfigByClassName(NewModel.GetType().FullName, sqlmap);
                if (Config == null || Config.IsUpdate == 0) return -1;

                //定义日志内容
                Dictionary<string, string> LogDic = new Dictionary<string, string>();
                //获取Model的ID
                object id = NewModel.GetType().GetProperty("ID").GetValue(NewModel, null);
                if (id != null)
                {
                    //获取老的Model
                    T OldModel = Dao.GetObject(id);
                    if (OldModel != null)
                    {
                        //获取新的Model的属性列表
                        PropertyInfo[] propertyList = NewModel.GetType().GetProperties();
                        //获取老Model的Type
                        Type OldType = OldModel.GetType();
                        //新的Model和老的Model值做对比
                        foreach (PropertyInfo property in propertyList)
                        {
                            //新的属性
                            object newpro = property.GetValue(NewModel, null);
                            //老的属性
                            object oldpro = OldType.GetProperty(property.Name).GetValue(OldModel, null);
                            if (!newpro.Equals(oldpro))
                            {
                                LogDic.Add(property.Name, string.Format("\"{0}\"修改为:\"{1}\"", oldpro, newpro));
                            }
                        }
                        //保存日志
                        if (LogDic.Count > 0)
                        {
                            //存储日志
                            DataServiceLog Log = new DataServiceLog();
                            Log.ID = new SysTableIdDao().generatorId("DataServiceLog", sqlmap);
                            Log.OperateContent = ToJson(LogDic);
                            Log.ClassName = NewModel.GetType().FullName;
                            Log.DataID = Convert.ToInt32(id);
                            Log.OperateType = 2;
                            Log.UserID = System.Web.HttpContext.Current.Session[SessionConstant.UserID] == null ? 0 : Convert.ToInt32(System.Web.HttpContext.Current.Session[SessionConstant.UserID]);
                            Log.OperateDate = DateTime.Now;
                            sqlmap.Insert("insertDataServiceLog", Log);
                            result = 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }

            return result;
        }

        /// <summary>
        /// 存储修改数据日志
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <param name="idlist"></param>
        /// <param name="sqlmap"></param>
        /// <returns></returns>
        public int Delete<T>(string classname, string idlist, ISqlMapper sqlmap)
        {
            int result = 0;
            try
            {
                //检验此类是否开启删除数据时插入数据
                DataServiceLogConfig Config = DataServiceLogConfigDataHelper.GetConfigByClassName(classname, sqlmap);
                if (Config == null || Config.IsDelete == 0) return -1;

                //定义日志内容
                Dictionary<string, string> LogDic = new Dictionary<string, string>();
                LogDic.Add("修改内容", "删除了此条信息");
                //保存日志
                if (LogDic.Count > 0)
                {
                    string[] ids = idlist.Split(',');
                    foreach (string idstr in ids)
                    {
                        //存储日志
                        DataServiceLog Log = new DataServiceLog();
                        Log.ID = new SysTableIdDao().generatorId("DataServiceLog", sqlmap);
                        Log.OperateContent = ToJson(LogDic);
                        Log.ClassName = classname;
                        Log.DataID = Convert.ToInt32(idstr);
                        Log.OperateType = 3;
                        Log.UserID = System.Web.HttpContext.Current.Session[SessionConstant.UserID] == null ? 0 : Convert.ToInt32(System.Web.HttpContext.Current.Session[SessionConstant.UserID]);
                        Log.OperateDate = DateTime.Now;
                        sqlmap.Insert("insertDataServiceLog", Log);
                    }
                    result = 1;
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }

            return result;
        }

        /// <summary>
        /// 将字典转换成json
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        private string ToJson(Dictionary<string, string> dic)
        {
            JsonConverter[] converters = new JsonConverter[] { new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" } };
            return Newtonsoft.Json.JsonConvert.SerializeObject(dic, converters);
        }
    }
}
