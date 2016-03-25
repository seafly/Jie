using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using IBatisNet.Common.Pagination;


namespace Cabio.BLL
{
    public interface ServiceInterface<T>
    {
        //获得实体类
        T GetObject(object keyId);
        //获得实体类
        T GetObject(Hashtable map);
        /// <summary>
        /// 返回指定类型的实体
        /// </summary>
        /// <typeparam name="Entity">返回实体类型</typeparam>
        /// <param name="parameterObject">查询参数</param>
        /// <returns>返回指定类型的实体</returns>
        Entity GetObject<Entity>(object parameterObject);
        Entity GetObject<Entity>(string statementName, object parameterObject);
        //获得结果集
        IList GetListByQuery();
        //获得结果集
        IList GetListByQuery(Hashtable map);
        //获得结果集
        IList GetListByQuery(Hashtable map, string statementName);
        IList GetListByQuery(Hashtable map, int skipResults, int maxResults);
        IList GetListByQuery(string statementName, Hashtable map, int skipResults, int maxResults);
        IList<Entity> GetListByQuery<Entity>();
        IList<Entity> GetListByQuery<Entity>(Hashtable map);
        IList<Entity> GetListByQuery<Entity>(string statementName, object parameterObject);
        IList<Entity> GetListByQuery<Entity>(Hashtable map, int skipResults, int maxResults);
        IList<Entity> GetListByQuery<Entity>(string statementName, object parameterObject, int skipResults, int maxResults);
        DataTable GetDataTable();
        DataTable GetDataTable(Hashtable map);
        DataTable GetDataTable(string statementName, Hashtable map);
        //插入数据
        int Insert(T t);
        //修改数据
        int Update(T t);

        int Update(string statementName, T t);
        //根据id集合删除数据
        int Remove(string idlist);

        int Remove(string statementName, string idlist);

        int Remove(string statementName, Hashtable map);
        /// 得到运行时ibatis.net动态生成的statementName
        string GetRuntimeSql(string statementName, object paramObject);
    }
}
