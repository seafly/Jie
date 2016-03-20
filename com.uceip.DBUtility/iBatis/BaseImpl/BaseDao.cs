using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Data;
using com.uceip.DBUtility.iBatis.Interfaces;
using IBatisNet.Common.Exceptions;
using IBatisNet.Common.Utilities;
using IBatisNet.DataAccess;
using IBatisNet.DataAccess.DaoSessionHandlers;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using IBatisNet.DataMapper.MappedStatements;
using IBatisNet.DataMapper.Scope;
using IBatisNet.DataMapper.SessionStore;
using System.Reflection;
using com.uceip.Common.DEncrypt;
using System.Configuration;

namespace com.uceip.DBUtility.iBatis.BaseImpl
{
    public class BaseDao<T> : DaoInterface<T>
    {
        public IDaoManager daoManager = null;

        public string domainEntity = "";
        public static ISqlMapper sqlMap2 = null;
        private string fileName2 = AppDomain.CurrentDomain.BaseDirectory + "\\Config\\ModeSqlMap2.config";

        protected ISqlMapper GetLocalSqlMap()
        {
            SqlMapDaoSession sqlMapDaoSession = daoManager.LocalDaoSession as SqlMapDaoSession;

            return sqlMapDaoSession.SqlMap;
        }

        /// <summary>
        /// 请不要使用此方法，下个版本将移除
        /// 解决多线程问题请使用ModeBaseDao类
        /// </summary>
        /// <returns></returns>
        public ISqlMapper GetSqlMap2()
        {
            if (sqlMap2 == null)
            {
                ConfigureHandler handler = new ConfigureHandler(Configure2);
                DomSqlMapBuilder builder = new DomSqlMapBuilder();
                sqlMap2 = builder.ConfigureAndWatch(fileName2, handler);
                sqlMap2.SessionStore = new HybridWebThreadSessionStore(sqlMap2.Id);
            }
            return sqlMap2;
        }


        protected static void Configure2(object obj)
        {
            sqlMap2 = null;
        }



        /**
           * 获取数据访问对象对应的业务实体的类名<br>
           * 用于查找在SqlMaps-XML文件中的定义的sql语句Id
           * @return 对应的业务实体的类名
           */
        protected virtual string getDomainEntity()
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

        /// <summary>
        /// 获取当前功能模块实体类
        /// </summary>
        /// <param name="keyId">传入参数</param>
        /// <returns>当前功能模块实体类</returns>
        public virtual T GetObject(object keyId)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();

            try
            {
                return sqlMap.QueryForObject<T>(getBuildObjectSqlId(), keyId);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + getBuildObjectSqlId() + "' for object.  Cause: " + e.Message, e);
            }
        }

        /// <summary>
        ///  获取当前功能模块实体类
        /// </summary>
        /// <param name="keyId">传入参数</param>
        /// <param name="sql">statementName</param>
        /// <returns>当前功能模块实体类</returns>
        public virtual T GetObject(object keyId, string sql)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();

            try
            {
                return sqlMap.QueryForObject<T>(sql, keyId);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + sql + "' for object.  Cause: " + e.Message, e);
            }
        }

        //获得实体类
        public virtual T GetObject(string keyString)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();

            try
            {
                return sqlMap.QueryForObject<T>(getBuildObjectSqlId(), keyString);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + getBuildObjectSqlId() + "' for object.  Cause: " + e.Message, e);
            }
        }

        //获得实体类
        public virtual T GetObject(string keyString, string sql)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();

            try
            {
                return sqlMap.QueryForObject<T>(sql, keyString);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + sql + "' for object.  Cause: " + e.Message, e);
            }
        }

        //获得实体类, 传map查询条件
        public virtual T GetObject(Hashtable map)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();

            try
            {
                return sqlMap.QueryForObject<T>(getBuildObjectSqlMap(), map);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + getBuildObjectSqlMapId() + "' for object.  Cause: " + e.Message, e);
            }
        }

        //获得结果集
        public virtual IList GetListByQuery(Hashtable map)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            try
            {
                return sqlMap.QueryForList(getQueryListSqlId(), map);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + getQueryListSqlId() + "' for list.  Cause: " + e.Message, e);
            }
        }

        public virtual IList GetListByQuery(Hashtable map, int skipResults, int maxResults)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            try
            {
                return sqlMap.QueryForList(getQueryListSqlId(), map, skipResults, maxResults);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + getQueryListSqlId() + "' for list.  Cause: " + e.Message, e);
            }
        }

        //获得结果集
        public virtual IList GetListByQuery(Hashtable map, string statementName)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            try
            {
                return sqlMap.QueryForList(statementName, map);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + statementName + "' for list.  Cause: " + e.Message, e);
            }
        }

        public virtual IList GetListByQuery(string statementName, Hashtable map, int skipResults, int maxResults)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            try
            {
                return sqlMap.QueryForList(statementName, map, skipResults, maxResults);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + statementName + "' for list.  Cause: " + e.Message, e);
            }
        }

        //新增数据
        public virtual int Insert(T t)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            int keyId = -1;
            try
            {
                keyId = (int)sqlMap.Insert(getInsertSqlId(), t);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("保存数据错误  Cause: " + e.Message, e);
            }
            return keyId;
        }

        //更新数据
        public virtual int Update(T t)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();

            try
            {
                int result = sqlMap.Update(getUpdateSqlId(), t);
                return result;

            }
            catch (Exception e)
            {
                throw new IBatisNetException("更新数据错误  Cause: " + e.Message, e);
            }
        }

        public virtual int Update(string statementName, T t)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();

            try
            {
                int result = sqlMap.Update(statementName, t);
                return result;

            }
            catch (Exception e)
            {
                throw new IBatisNetException("更新数据错误  Cause: " + e.Message, e);
            }
        }

        //根据id集合删除数据
        public virtual int Remove(string idlist)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();

            try
            {
                ////美兰支付宝项目修改所用（配合iterate使用）
                //Hashtable map = new Hashtable();
                //map.Add("IDList", idlist.Split(','));
                //return sqlMap.Delete(getDeleteSqlId(), map);
                int result = sqlMap.Delete(getDeleteSqlId(), idlist);
                return result;
            }
            catch (Exception e)
            {
                throw new IBatisNetException("数据删除错误  Cause: " + e.Message, e);
            }
        }

        public virtual int Remove(string statementName, string idlist)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();

            try
            {
                int result = sqlMap.Delete(statementName, idlist);
                return result;
            }
            catch (Exception e)
            {
                throw new IBatisNetException("数据删除错误  Cause: " + e.Message, e);
            }
        }

        ///
        ///======================================================================
        ///以下方法返回数据集指定行数
        ///added by .Net项目组/2011-07-06
        ///
        //获得结果集
        public virtual IList GetListByQueryLimit(Hashtable map)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            try
            {
                return sqlMap.QueryForList(getQueryListLimitSqlId(), map);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + getQueryListLimitSqlId() + "' for list.  Cause: " + e.Message, e);
            }
        }

        //获得结果集
        public virtual IList GetListByQueryLimit(Hashtable map, string statementName)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            try
            {
                return sqlMap.QueryForList(statementName, map);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + statementName + "' for list.  Cause: " + e.Message, e);
            }
        }

        ///
        ///======================================================================
        ///

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
            return result;
        }


        /// <summary>
        /// QueryForObject 泛型支持
        /// </summary>
        /// <typeparam name="Entity"></typeparam>
        /// <param name="statementName"></param>
        /// <param name="pamaryKey"></param>
        /// <returns></returns>
        public virtual Entity GetObject<Entity>(string statementName, object parameterObject)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            try
            {
                return sqlMap.QueryForObject<Entity>(statementName, parameterObject);
            }
            catch (Exception ex)
            {
                throw new IBatisNetException("Error executing query '" + statementName + "':" + ex.Message, ex);
            }
        }
        /// <summary>
        /// 返回指定类型实体
        /// </summary>
        public virtual Entity GetObject<Entity>(object parameterObject)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            string statementName = "get" + typeof(Entity).Name + "T";
            try
            {
                return sqlMap.QueryForObject<Entity>(statementName, parameterObject);
            }
            catch (Exception ex)
            {
                throw new IBatisNetException("Error executing query '" + statementName + "' for GenericType:" + ex.Message, ex);
            }
        }
        /// <summary>
        /// 返回指定类型的实体集合
        /// </summary>
        public virtual IList<Entity> GetListByQuery<Entity>(Hashtable map)
        {
            string statementName = "query" + typeof(Entity).Name + "List";
            return GetListByQuery<Entity>(statementName, map);
        }

        public virtual IList<Entity> GetListByQuery<Entity>(Hashtable map, int skipResults, int maxResults)
        {
            string statementName = "query" + typeof(Entity).Name + "List";
            return GetListByQuery<Entity>(statementName, map, skipResults, maxResults);
        }

        public virtual IList<Entity> GetListByQuery<Entity>(string statementName, object parameterObject)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            try
            {
                return sqlMap.QueryForList<Entity>(statementName, parameterObject);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + statementName + "' for GenericType IList<" + typeof(Entity).Name + ">.  Cause: " + e.Message, e);
            }
        }

        public virtual IList<Entity> GetListByQuery<Entity>(string statementName, object parameterObject, int skipResults, int maxResults)
        {
            ISqlMapper sqlMap = GetLocalSqlMap();
            try
            {
                return sqlMap.QueryForList<Entity>(statementName, parameterObject, skipResults, maxResults);
            }
            catch (Exception e)
            {
                throw new IBatisNetException("Error executing query '" + statementName + "' for GenericType IList<" + typeof(Entity).Name + ">.  Cause: " + e.Message, e);
            }
        }
    }
}
