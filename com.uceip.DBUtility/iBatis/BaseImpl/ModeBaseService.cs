using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.uceip.DBUtility.iBatis.Interfaces;
using IBatisNet.DataAccess;
using System.Collections;
using System.Data;

namespace com.uceip.DBUtility.iBatis.BaseImpl
{
    public class ModeBaseService<T> : ServiceInterface<T>
    {
        /**
        * 获取业务实体对象对应的数据访问对象实例
        * @return 业务实体对象对应的数据访问对象实例
        */
        public DaoInterface<T> dao = null;

        public IDaoManager _daoManager = null;

        //获得实体类
        public virtual T GetObject(object keyId)
        {
            return dao.GetObject(keyId);
        }

        //获得实体类
        public virtual T GetObject(Hashtable map)
        {
            return dao.GetObject(map);
        }

        //获得结果集
        public virtual IList GetListByQuery()
        {
            Hashtable map = new Hashtable();
            return dao.GetListByQuery(map);
        }

        //获得结果集
        public virtual IList GetListByQuery(Hashtable map)
        {
            return dao.GetListByQuery(map);
        }

        //获得结果集
        public virtual IList GetListByQuery(Hashtable map, int skipResults, int maxResults)
        {
            return dao.GetListByQuery(map, skipResults, maxResults);
        }

        //获得结果集
        public virtual IList GetListByQuery(Hashtable map, string statementName)
        {
            return dao.GetListByQuery(map, statementName);
        }

        public virtual IList GetListByQuery(string statementName, Hashtable map, int skipResults, int maxResults)
        {
            return dao.GetListByQuery(statementName, map, skipResults, maxResults);
        }

        //插入数据
        public virtual int Insert(T t)
        {
            return dao.Insert(t); ;
        }

        //修改数据
        public virtual int Update(T t)
        {
            return dao.Update(t);
        }

        //根据id集合删除数据
        public virtual int Remove(string idlist)
        {
            return dao.Remove(idlist);
        }

        ///
        ///======================================================================
        ///以下方法返回数据集指定行数
        ///added by .Net项目组/2011-07-06
        ///
        //获得结果集
        public virtual IList GetListByQuery(int returnRows)
        {
            Hashtable map = new Hashtable();
            map.Add("limitRows", returnRows);
            return dao.GetListByQueryLimit(map);
        }

        //获得结果集
        public virtual IList GetListByQuery(Hashtable map, int returnRows)
        {
            map.Add("limitRows", returnRows);
            return dao.GetListByQueryLimit(map);
        }

        ///
        ///======================================================================
        ///

        /// <summary>
        /// GetObject Entity
        /// </summary>
        /// <typeparam name="T">the type for return</typeparam>
        /// <param name="statementName">SqlMap statementname</param>
        /// <param name="parameterObject">object parameter for query</param>
        /// <returns>Entity</returns>
        public Entity GetObject<Entity>(string statementName, object parameterObject)
        {
            return dao.GetObject<Entity>(statementName, parameterObject);
        }

        /// <summary>
        /// 返回指定类型的实体(SqlMap命名：get+EntityName+T)
        /// </summary>
        /// <typeparam name="Entity">返回类型</typeparam>
        /// <param name="parameterObject">查询参数</param>
        /// <returns></returns>
        public virtual Entity GetObject<Entity>(object parameterObject)
        {
            return dao.GetObject<Entity>(parameterObject);
        }
        /// <summary>
        /// 返回指定类型的实体集合(SqlMap命名：query+EntityName+ListT)
        /// </summary>
        /// <typeparam name="Entity">返回集合类型</typeparam>
        /// <param name="map">查询参数</param>
        /// <returns></returns>
        public virtual IList<Entity> GetListByQuery<Entity>(Hashtable map)
        {
            return dao.GetListByQuery<Entity>(map);
        }

        public virtual IList<Entity> GetListByQuery<Entity>(Hashtable map, int skipResults, int maxResults)
        {
            return dao.GetListByQuery<Entity>(map, skipResults, maxResults);
        }

        public virtual IList<Entity> GetListByQuery<Entity>(string statementName, object parameterObject)
        {
            return dao.GetListByQuery<Entity>(statementName, parameterObject);
        }

        public virtual IList<Entity> GetListByQuery<Entity>(string statementName, object parameterObject, int skipResults, int maxResults)
        {
            return dao.GetListByQuery<Entity>(statementName, parameterObject, skipResults, maxResults);
        }
        /// <summary>
        /// 得到运行时ibatis.net动态生成的SQL
        /// </summary>
        /// <param name="sqlMapper"></param>
        /// <param name="statementName"></param>
        /// <param name="paramObject"></param>
        /// <returns></returns>
        public virtual string GetRuntimeSql(string statementName, object paramObject)
        {
            return dao.GetRuntimeSql(statementName, paramObject);
        }
    }
}
