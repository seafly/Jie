using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using IBatisNet.Common.Pagination;
using IBatisNet.DataAccess.Interfaces;

namespace com.uceip.DBUtility.iBatis.Interfaces
{
    /**
     * 数据访问层的接口定义
     */
    public interface DaoInterface<T> : IDao
    {
        //获得实体类
        T GetObject(object keyId);
        //获得实体类
        T GetObject(object keyId, string statementName);
        //获得实体类
        T GetObject(string keyId);
        //获得实体类
        T GetObject(Hashtable map);
        //获得实体类
        T GetObject(string keyId, string statementName);
        Entity GetObject<Entity>(object parameterObject);
        Entity GetObject<Entity>(string statementName, object parameterObject);
        //获得结果集
        IList GetListByQuery(Hashtable map);
        //获得结果集
        IList GetListByQuery(Hashtable map, string statementName);
        IList GetListByQuery(Hashtable map, int skipResults, int maxResults);
        IList GetListByQuery(string statementName, Hashtable map, int skipResults, int maxResults);
        IList<Entity> GetListByQuery<Entity>(Hashtable map);
        IList<Entity> GetListByQuery<Entity>(string statementName, object parameterObject);
        IList<Entity> GetListByQuery<Entity>(Hashtable map, int skipResults, int maxResults);
        IList<Entity> GetListByQuery<Entity>(string statementName, object parameterObject, int skipResults, int maxResults);

        //插入数据
        int Insert(T t);
        //修改数据
        int Update(T t);

        int Update(string statementName, T t);
        //根据id集合删除数据
        int Remove(string idlist);

        int Remove(string statementName, string idlist);

        int Remove(string statementName, Hashtable map);

        /// <summary>
        /// 获取指定行数的结果集
        /// </summary>
        /// <param name="map"></param>
        /// <returns></returns>
        IList GetListByQueryLimit(Hashtable map);

        /// 得到运行时ibatis.net动态生成的SQL
        string GetRuntimeSql(string statementName, object paramObject);
    }
}
