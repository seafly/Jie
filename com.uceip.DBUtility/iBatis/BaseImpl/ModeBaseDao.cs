using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.uceip.DBUtility.iBatis.Interfaces;
using IBatisNet.DataAccess;
using IBatisNet.DataMapper;
using IBatisNet.Common.Utilities;
using IBatisNet.DataMapper.Configuration;
using IBatisNet.DataMapper.SessionStore;
using IBatisNet.Common.Exceptions;
using System.Collections;
using System.Data;
using IBatisNet.DataMapper.MappedStatements;
using IBatisNet.DataMapper.Scope;
using System.Reflection;
using System.Configuration;
using com.uceip.Common.DEncrypt;

namespace com.uceip.DBUtility.iBatis.BaseImpl
{
    public class ModeBaseDao<T> : DaoInterface<T>
    {

        public string domainEntity = "";
        public static ISqlMapper sqlMap = null;
        private string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\Config\\ModeSqlMap.config";
        public ISqlMapper GetLocalSqlMap()
        {
            if (sqlMap == null)
            {
                ConfigureHandler handler = new ConfigureHandler(Configure);
                DomSqlMapBuilder builder = new DomSqlMapBuilder();
                sqlMap = builder.ConfigureAndWatch(fileName, handler);
                sqlMap.SessionStore = new HybridWebThreadSessionStore(sqlMap.Id);
            }
            return sqlMap;
        }

        protected static void Configure(object obj)
        {
            sqlMap = null;
        }


        #region 生成StatementID-begin

        /**
           * 获取数据访问对象对应的业务实体的类名<br>
           * 用于查找在SqlMaps-XML文件中的定义的sql语句Id
           * @return 对应的业务实体的类名
           */
        public virtual string getDomainEntity()
        {
            return domainEntity;
        }

        /**
           * 获取数据表主键名
           * @return 
           */
        protected string getKeyIdName()
        {
            return "ID";
        }

        /**
         * sql语句Id : 根据keyId构建实例
         */
        public string getBuildObjectSqlId()
        {
            return "get" + getDomainEntity() + "ById";
        }

        public string getBuildObjectSqlMapId()
        {
            return "get" + getDomainEntity() + "ByMap";
        }

        /**
         * 根据Map查询条件获取对象
         */
        public string getBuildObjectSqlMap()
        {
            return "get" + getDomainEntity() + "ByMap";
        }

        /**
         * sql语句Id : 根据查询获取集合
         */
        public string getQueryListSqlId()
        {
            return "query" + getDomainEntity() + "List";
        }

        /**
         * sql语句Id : 根据条件查询记录数
         */
        public string getQueryCountSqlId()
        {
            return "query" + getDomainEntity() + "Count";
        }

        /**
         * sql语句Id : 创建
         */
        public string getInsertSqlId()
        {
            return "insert" + getDomainEntity();
        }

        /**
         * sql语句Id : 更新
         */
        public string getUpdateSqlId()
        {
            return "update" + getDomainEntity();
        }

        /**
         * sql语句Id : 删除
         */
        public string getDeleteSqlId()
        {
            return "delete" + getDomainEntity();
        }

        /**
         * sql语句Id : 获取指定行数记录集
         */
        public string getQueryListLimitSqlId()
        {
            return "query" + getDomainEntity() + "LimitList";
        }

        #endregion  生成StatementID-end

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual int Insert(T t)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            int keyId = -1;
            try
            {
                sqlMap.BeginTransaction();
                keyId = (int)sqlMap.Insert(getInsertSqlId(), t);
                sqlMap.CommitTransaction();
            }
            catch (Exception e)
            {
                sqlMap.RollBackTransaction();
                throw new IBatisNetException("保存数据错误  Cause: " + e.Message, e);
            }
            return keyId;
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual int Update(T t)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            int keyId = 0;
            try
            {
                sqlMap.BeginTransaction();
                keyId = sqlMap.Update(getUpdateSqlId(), t);
                sqlMap.CommitTransaction();
            }
            catch (Exception e)
            {
                sqlMap.RollBackTransaction();
                throw new IBatisNetException("更新数据错误  Cause: " + e.Message, e);
            }
            return keyId;
        }

        /// <summary>
        /// 根据id集合删除数据
        /// </summary>
        /// <param name="idlist"></param>
        /// <returns></returns>
        public virtual int Remove(string idlist)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            int keyId = 0;
            try
            {
                sqlMap.BeginTransaction();
                ////美兰支付宝项目修改所用（配合iterate使用）
                //Hashtable map = new Hashtable();
                //map.Add("IDList", idlist.Split(','));
                //keyId = sqlMap.Delete(getDeleteSqlId(), map);
                keyId = sqlMap.Delete(getDeleteSqlId(), idlist);
                sqlMap.CommitTransaction();
            }
            catch (Exception e)
            {
                sqlMap.RollBackTransaction();
                throw new IBatisNetException("数据删除错误  Cause: " + e.Message, e);
            }
            return keyId;
        }

        #region 查询单条记录-begin
        //获得实体类, 传map查询条件

        /// <summary>
        /// 获取实体类
        /// </summary>
        /// <param name="map">传入参数</param>
        /// <returns></returns>
        public virtual T GetObject(Hashtable map)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            T t = default(T);
            try
            {
                sqlMap.OpenConnection();
                t = sqlMap.QueryForObject<T>(getBuildObjectSqlMap(), map);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + getBuildObjectSqlMapId() + "' for object.  Cause: " + e.Message, e);
            }
            finally
            {
                sqlMap.CloseConnection();
            }
            return t;
        }

        /// <summary>
        /// 获取实体类
        /// </summary>
        /// <param name="map">传入参数</param>
        /// <returns></returns>
        public virtual T GetObject(object keyId)
        {
            return GetObject(keyId, getBuildObjectSqlId());
        }

        /// <summary>
        /// 获取实体类
        /// </summary>
        /// <param name="map">传入参数</param>
        /// <returns></returns>
        public virtual T GetObject(string keyString)
        {
            return GetObject(keyString, getBuildObjectSqlId());
        }

        /// <summary>
        /// 获取实体类
        /// </summary>
        /// <param name="keyId">传入参数</param>
        /// <param name="statementName">SqlMapID</param>
        /// <returns></returns>
        public virtual T GetObject(object keyId, string statementName)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            T t = default(T);
            try
            {
                sqlMap.OpenConnection();
                t = sqlMap.QueryForObject<T>(statementName, keyId);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + statementName + "' for object.  Cause: " + e.Message, e);
            }
            finally
            {
                sqlMap.CloseConnection();
            }
            return t;
        }

        /// <summary>
        /// 获取实体类
        /// </summary>
        /// <param name="keyString">传入参数</param>
        /// <param name="statementName">SqlMapID</param>
        /// <returns></returns>
        public virtual T GetObject(string keyString, string statementName)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            T t = default(T);
            try
            {
                sqlMap.OpenConnection();
                t = sqlMap.QueryForObject<T>(statementName, keyString);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + statementName + "' for object.  Cause: " + e.Message, e);
            }
            finally
            {
                sqlMap.CloseConnection();
            }
            return t;
        }

        /// <summary>
        /// 返回指定类型实体
        /// </summary>
        /// <typeparam name="Entity"></typeparam>
        /// <param name="parameterObject">传入参数</param>
        /// <returns></returns>
        public virtual Entity GetObject<Entity>(object parameterObject)
        {
            string statementName = "get" + typeof(Entity).Name + "T";
            return GetObject<Entity>(statementName, parameterObject);
        }

        /// <summary>
        /// 返回指定类型实体
        /// </summary>
        /// <typeparam name="Entity"></typeparam>
        /// <param name="statementName">SqlMapID</param>
        /// <param name="pamaryKey">传入实体类</param>
        /// <returns></returns>
        public virtual Entity GetObject<Entity>(string statementName, object parameterObject)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            Entity obj = default(Entity);
            try
            {
                sqlMap.OpenConnection();
                obj = sqlMap.QueryForObject<Entity>(statementName, parameterObject);
            }
            catch (Exception ex)
            {
                throw new IBatisNetException("Error executing query '" + statementName + "':" + ex.Message, ex);
            }
            finally
            {
                sqlMap.CloseConnection();
            }
            return obj;
        }
        #endregion 查询单条记录-end

        #region 查询多条数据-begin
        /// <summary>
        /// 获得结果集
        /// </summary>
        /// <param name="map"></param>
        /// <returns></returns>
        public virtual IList GetListByQuery(Hashtable map)
        {
            return GetListByQuery(map, getQueryListSqlId());
        }

        /// <summary>
        /// 返回指定数量的结果集
        /// </summary>
        /// <param name="map">传入参数</param>
        /// <param name="skipResults">起始数据索引</param>
        /// <param name="maxResults">返回数据最大数量</param>
        /// <returns></returns>
        public virtual IList GetListByQuery(Hashtable map, int skipResults, int maxResults)
        {
            return GetListByQuery(getQueryListSqlId(), map, skipResults, maxResults);
        }

        /// <summary>
        /// 获得结果集
        /// </summary>
        /// <param name="map">传入参数</param>
        /// <param name="statementName">SqlMapID</param>
        /// <returns></returns>
        public virtual IList GetListByQuery(Hashtable map, string statementName)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            IList list = default(IList);
            try
            {
                sqlMap.OpenConnection();
                list = sqlMap.QueryForList(statementName, map);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + statementName + "' for list.  Cause: " + e.Message, e);
            }
            finally
            {
                sqlMap.CloseConnection();
            }
            return list;
        }

        /// <summary>
        /// 返回指定数量的结果集
        /// </summary>
        /// <param name="statementName">SqlMapID</param>
        /// <param name="map">传入参数</param>
        /// <param name="skipResults">起始数据索引</param>
        /// <param name="maxResults">返回数据最大数量</param>
        /// <returns></returns>
        public virtual IList GetListByQuery(string statementName, Hashtable map, int skipResults, int maxResults)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            IList list = default(IList);
            try
            {
                sqlMap.OpenConnection();
                list = sqlMap.QueryForList(statementName, map, skipResults, maxResults);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + statementName + "' for list.  Cause: " + e.Message, e);
            }
            finally
            {
                sqlMap.CloseConnection();
            }
            return list;
        }

        /// <summary>
        /// 获得结果集
        /// </summary>
        /// <param name="map"></param>
        /// <returns></returns>
        public virtual IList GetListByQueryLimit(Hashtable map)
        {
            return GetListByQueryLimit(map, getQueryListLimitSqlId());
        }

        /// <summary>
        /// 获得结果集
        /// </summary>
        /// <param name="map"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual IList GetListByQueryLimit(Hashtable map, string sql)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            IList list = default(IList);
            try
            {
                sqlMap.OpenConnection();
                list = sqlMap.QueryForList(sql, map);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + sql + "' for list.  Cause: " + e.Message, e);
            }
            finally
            {
                sqlMap.CloseConnection();
            }
            return list;
        }

        /// <summary>
        /// 返回指定类型的实体集合
        /// </summary>
        public virtual IList<Entity> GetListByQuery<Entity>(Hashtable map)
        {
            string statementName = "query" + typeof(Entity).Name + "ListT";
            return GetListByQuery<Entity>(statementName, map);
        }

        /// <summary>
        /// 根据statementName返回结果统计（以skipResults为起始点，查询出最多maxResults条数据）
        /// </summary>
        /// <typeparam name="Entity"></typeparam>
        /// <param name="map"></param>
        /// <param name="skipResults">查询起始点索引</param>
        /// <param name="maxResults">返回结果集最大数量</param>
        /// <returns></returns>
        public virtual IList<Entity> GetListByQuery<Entity>(Hashtable map, int skipResults, int maxResults)
        {
            string statementName = "query" + typeof(Entity).Name + "ListT";
            return GetListByQuery<Entity>(statementName, map, skipResults, maxResults);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Entity"></typeparam>
        /// <param name="statementName"></param>
        /// <param name="parameterObject"></param>
        /// <returns></returns>
        public virtual IList<Entity> GetListByQuery<Entity>(string statementName, object parameterObject)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            IList<Entity> ilist = null;
            try
            {
                sqlMap.OpenConnection();
                ilist = sqlMap.QueryForList<Entity>(statementName, parameterObject);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + statementName + "' for GenericType IList<" + typeof(Entity).Name + ">.  Cause: " + e.Message, e);
            }
            finally
            {
                sqlMap.CloseConnection();
            }
            return ilist;
        }

        /// <summary>
        /// 根据statementName返回结果统计（以skipResults为起始点，查询出最多maxResults条数据）
        /// </summary>
        /// <typeparam name="Entity"></typeparam>
        /// <param name="statementName"></param>
        /// <param name="parameterObject"></param>
        /// <param name="skipResults">查询起始点索引</param>
        /// <param name="maxResults">返回结果集最大数量</param>
        /// <returns></returns>
        public virtual IList<Entity> GetListByQuery<Entity>(string statementName, object parameterObject, int skipResults, int maxResults)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            IList<Entity> ilist = null;
            try
            {
                sqlMap.OpenConnection();
                ilist = sqlMap.QueryForList<Entity>(statementName, parameterObject, skipResults, maxResults);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + statementName + "' for GenericType IList<" + typeof(Entity).Name + ">.  Cause: " + e.Message, e);
            }
            finally
            {
                sqlMap.CloseConnection();
            }
            return ilist;
        }
        #endregion 查询多条数据-end

        /// <summary>
        /// 得到运行时ibatis.net动态生成的SQL
        /// </summary>
        /// <param name="sqlMapper"></param>
        /// <param name="statementName"></param>
        /// <param name="paramObject"></param>
        /// <returns></returns>
        public virtual string GetRuntimeSql(string statementName, object paramObject)
        {
            string result = string.Empty;
            ISqlMapper sqlMap = GetLocalSqlMap();
            try
            {
                sqlMap.OpenConnection();
                IMappedStatement statement = sqlMap.GetMappedStatement(statementName);
                if (!sqlMap.IsSessionStarted)
                {
                    sqlMap.OpenConnection();
                }
                RequestScope scope = statement.Statement.Sql.GetRequestScope(statement, paramObject, sqlMap.LocalSession);
                result = scope.PreparedStatement.PreparedSql;
            }
            catch (Exception ex)
            {
                result = "获取SQL语句出现异常:" + ex.Message;
            }
            finally
            {
                sqlMap.CloseConnection();
            }
            return result;
        }
    }
}
