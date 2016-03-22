using System.Data;
using System.Collections;
using System.Collections.Generic;
using IBatisNet.DataAccess;
using IBatisNet.DataAccess.SessionStore;
using com.uceip.DBUtility.iBatis.Interfaces;
using System;
using IBatisNet.Common.Exceptions;

namespace com.uceip.DBUtility.iBatis.BaseImpl
{
    public class BaseService<T> : ServiceInterface<T>
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
            T t = default(T);
            try
            {
                _daoManager.OpenConnection();
                t = dao.GetObject(keyId);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                _daoManager.CloseConnection();
            }
            return t;
        }

        //获得实体类
        public virtual T GetObject(Hashtable map)
        {
            T t = default(T);
            try
            {
                _daoManager.OpenConnection();
                t = dao.GetObject(map);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                _daoManager.CloseConnection();
            }
            return t;
        }

        //获得结果集
        public virtual IList GetListByQuery()
        {
            IList ilist = null;
            try
            {
                _daoManager.OpenConnection();
                Hashtable map = new Hashtable();
                ilist = dao.GetListByQuery(map);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                _daoManager.CloseConnection();
            }
            return ilist;
        }

        //获得结果集
        public virtual IList GetListByQuery(Hashtable map)
        {
            IList ilist = null;
            try
            {
                _daoManager.OpenConnection();
                ilist = dao.GetListByQuery(map);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                _daoManager.CloseConnection();
            }
            return ilist;
        }

        //获得结果集
        public virtual IList GetListByQuery(Hashtable map, int skipResults, int maxResults)
        {
            IList ilist = null;
            try
            {
                _daoManager.OpenConnection();
                ilist = dao.GetListByQuery(map, skipResults, maxResults);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                _daoManager.CloseConnection();
            }
            return ilist;
        }

        //获得结果集
        public virtual IList GetListByQuery(Hashtable map, string statementName)
        {
            IList ilist = null;
            try
            {
                _daoManager.OpenConnection();
                ilist = dao.GetListByQuery(map, statementName);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                _daoManager.CloseConnection();
            }
            return ilist;
        }

        public virtual IList GetListByQuery(string statementName, Hashtable map, int skipResults, int maxResults)
        {
            IList ilist = null;
            try
            {
                _daoManager.OpenConnection();
                ilist = dao.GetListByQuery(statementName, map, skipResults, maxResults);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                _daoManager.CloseConnection();
            }
            return ilist;
        }

        //插入数据
        public virtual int Insert(T t)
        {
            int keyId = -1;
            _daoManager.BeginTransaction();
            try
            {
                keyId = dao.Insert(t);
                _daoManager.CommitTransaction();
            }
            catch (Exception e)
            {
                _daoManager.RollBackTransaction();
                System.Diagnostics.Debug.Write(e.Message);
            }
            return keyId;
        }
        //修改数据
        public virtual int Update(T t)
        {
            int result = -1;
            _daoManager.BeginTransaction();
            try
            {
                result = dao.Update(t);
                _daoManager.CommitTransaction();
            }
            catch (Exception e)
            {
                _daoManager.RollBackTransaction();
                System.Diagnostics.Debug.Write(e.Message);
            }
            return result;
        }

        public virtual int Update(string statementName, T t)
        {
            int result = -1;
            _daoManager.BeginTransaction();
            try
            {
                result = dao.Update(statementName, t);
                _daoManager.CommitTransaction();
            }
            catch (Exception e)
            {
                _daoManager.RollBackTransaction();
                System.Diagnostics.Debug.Write(e.Message);
            }
            return result;
        }

        //根据id集合删除数据
        public virtual int Remove(string idlist)
        {
            int result = -1;
            _daoManager.BeginTransaction();
            try
            {
                result = dao.Remove(idlist);
                _daoManager.CommitTransaction();
            }
            catch (Exception e)
            {
                _daoManager.RollBackTransaction();
                System.Diagnostics.Debug.Write(e.Message);
            }
            return result;
        }

        public virtual int Remove(string statementName, string idlist)
        {
            int result = -1;
            _daoManager.BeginTransaction();
            try
            {
                result = dao.Remove(statementName, idlist);
                _daoManager.CommitTransaction();
            }
            catch (Exception e)
            {
                _daoManager.RollBackTransaction();
                System.Diagnostics.Debug.Write(e.Message);
            }
            return result;
        }

        public virtual int Remove(string statementName, Hashtable map)
        {
            int result = -1;
            _daoManager.BeginTransaction();
            try
            {
                result = dao.Remove(statementName, map);
                _daoManager.CommitTransaction();
            }
            catch (Exception e)
            {
                _daoManager.RollBackTransaction();
                System.Diagnostics.Debug.Write(e.Message);
            }
            return result;
        }
        ///
        ///======================================================================
        ///以下方法返回数据集指定行数
        ///added by .Net项目组/2011-07-06
        ///
        //获得结果集
        public virtual IList GetListByQuery(int returnRows)
        {
            IList ilist = null;
            try
            {
                _daoManager.OpenConnection();
                Hashtable map = new Hashtable();
                map.Add("limitRows", returnRows);
                ilist = dao.GetListByQueryLimit(map);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                _daoManager.CloseConnection();
            }
            return ilist;
        }

        //获得结果集
        public virtual IList GetListByQuery(Hashtable map, int returnRows)
        {
            IList ilist = null;
            try
            {
                _daoManager.OpenConnection();
                map.Add("limitRows", returnRows);
                ilist = dao.GetListByQueryLimit(map);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                _daoManager.CloseConnection();
            }
            return ilist;
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
            try
            {
                _daoManager.OpenConnection();
                result = dao.GetRuntimeSql(statementName, paramObject);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                _daoManager.CloseConnection();
            }
            return result;
        }
        /// <summary>
        /// GetObject Entity
        /// </summary>
        /// <typeparam name="T">the type for return</typeparam>
        /// <param name="statementName">SqlMap statementname</param>
        /// <param name="parameterObject">object parameter for query</param>
        /// <returns>Entity</returns>
        public Entity GetObject<Entity>(string statementName, object parameterObject)
        {
            Entity obj = default(Entity);
            try
            {
                _daoManager.OpenConnection();
                obj = dao.GetObject<Entity>(statementName, parameterObject);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                _daoManager.CloseConnection();
            }
            return obj;
        }



        /// <summary>
        /// 返回指定类型的实体(SqlMap命名：get+EntityName+T)
        /// </summary>
        /// <typeparam name="Entity">返回类型</typeparam>
        /// <param name="parameterObject">查询参数</param>
        /// <returns></returns>
        public virtual Entity GetObject<Entity>(object parameterObject)
        {
            Entity obj = default(Entity);
            try
            {
                _daoManager.OpenConnection();
                obj = dao.GetObject<Entity>(parameterObject);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                _daoManager.CloseConnection();
            }
            return obj;
        }

        public virtual IList<Entity> GetListByQuery<Entity>()
        {
            return this.GetListByQuery<Entity>(new Hashtable());
        }

        /// <summary>
        /// 返回指定类型的实体集合(SqlMap命名：query+EntityName+ListT)
        /// </summary>
        /// <typeparam name="Entity">返回集合类型</typeparam>
        /// <param name="map">查询参数</param>
        /// <returns></returns>
        public virtual IList<Entity> GetListByQuery<Entity>(Hashtable map)
        {
            IList<Entity> ilist = null;
            try
            {
                _daoManager.OpenConnection();
                ilist = dao.GetListByQuery<Entity>(map);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (_daoManager.IsDaoSessionStarted())
                {
                    _daoManager.CloseConnection();
                }
            }
            return ilist;
        }

        public virtual IList<Entity> GetListByQuery<Entity>(Hashtable map, int skipResults, int maxResults)
        {
            IList<Entity> ilist = null;
            try
            {
                _daoManager.OpenConnection();
                ilist = dao.GetListByQuery<Entity>(map, skipResults, maxResults);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (_daoManager.IsDaoSessionStarted())
                {
                    _daoManager.CloseConnection();
                }
            }
            return ilist;
        }

        public virtual IList<Entity> GetListByQuery<Entity>(string statementName, object parameterObject)
        {
            IList<Entity> ilist = null;
            try
            {
                _daoManager.OpenConnection();
                ilist = dao.GetListByQuery<Entity>(statementName, parameterObject);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (_daoManager.IsDaoSessionStarted())
                {
                    _daoManager.CloseConnection();
                }
            }
            return ilist;
        }

        public virtual IList<Entity> GetListByQuery<Entity>(string statementName, object parameterObject, int skipResults, int maxResults)
        {
            IList<Entity> ilist = null;
            try
            {
                _daoManager.OpenConnection();
                ilist = dao.GetListByQuery<Entity>(statementName, parameterObject, skipResults, maxResults);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (_daoManager.IsDaoSessionStarted())
                {
                    _daoManager.CloseConnection();
                }
            }
            return ilist;
        }

        public virtual DataTable GetDataTable()
        {
            DataTable dt = null;
            try
            {
                _daoManager.OpenConnection();
                dt = dao.GetDataTable();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (_daoManager.IsDaoSessionStarted())
                {
                    _daoManager.CloseConnection();
                }
            }
            return dt;
        }
        public virtual DataTable GetDataTable(Hashtable map)
        {
            DataTable dt = null;
            try
            {
                _daoManager.OpenConnection();
                dt = dao.GetDataTable(map);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (_daoManager.IsDaoSessionStarted())
                {
                    _daoManager.CloseConnection();
                }
            }
            return dt;
        }
        public virtual DataTable GetDataTable(string statementName, Hashtable map)
        {
            DataTable dt = null;
            try
            {
                _daoManager.OpenConnection();
                dt = dao.GetDataTable(statementName, map);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (_daoManager.IsDaoSessionStarted())
                {
                    _daoManager.CloseConnection();
                }
            }
            return dt;
        }
    }
}
