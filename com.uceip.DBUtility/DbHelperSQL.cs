using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

namespace ZWL.DBUtility
{
    /// <summary>
    /// 数据访问抽象基础类
    /// Copyright (C) 2004-2008 By zwl 
    /// </summary>
    public abstract class DbHelperSQL
    { 
        public DbHelperSQL()
        {

        }
        //定义连接字符串。
        protected static string ConnectionString = ConfigurationManager.AppSettings["SQLConnectionString"];
       
        protected static SqlConnection Connection;
        //定义数据库的打开和关闭方法
        protected static void Open()
        {
            if (Connection == null)
            {
                Connection = new SqlConnection(ConnectionString);
            }
            if (Connection.State.Equals(ConnectionState.Closed))
            {
                Connection.Open();
            }
        }
        protected static void Close()
        {
            if (Connection != null)
            {
                Connection.Close();
            }
        }
        //绑定到GridView
        public static void BindGridView(string SqlString, GridView MyGvData)
        {
            MyGvData.DataSource = GetDataSet(SqlString);
            MyGvData.DataBind();
        }
        //绑定到DropDownList，设定Text和value显示
        public static void BindDropDownList2(string SqlString, DropDownList MyDDL, string TextStr, string ValueStr)
        {
            SqlDataReader MyReader = GetDataReader(SqlString);
            while (MyReader.Read())
            {
                ListItem MyItem = new ListItem();
                MyItem.Text = MyReader[TextStr].ToString();
                MyItem.Value = MyReader[ValueStr].ToString();
                MyDDL.Items.Add(MyItem);
            }
            MyReader.Close();
        }
        //绑定到DropDownList，设定Text和value显示
        public static void BindDropDownList(string SqlString, DropDownList MyDDL, string TextStr, string ValueStr)
        {
            SqlDataReader MyReader = GetDataReader(SqlString);
            MyDDL.Items.Clear();
            while (MyReader.Read())
            {
                ListItem MyItem = new ListItem();
                MyItem.Text = MyReader[TextStr].ToString();
                MyItem.Value = MyReader[ValueStr].ToString();
                MyDDL.Items.Add(MyItem);
            }
            MyReader.Close();
        }
        //绑定到DropDownList，设定Text和value显示
        public static void BindItemList(string SqlString, ListBox MyDDL, string TextStr, string ValueStr)
        {
            SqlDataReader MyReader = GetDataReader(SqlString);
            MyDDL.Items.Clear();
            while (MyReader.Read())
            {
                ListItem MyItem = new ListItem();
                MyItem.Text = MyReader[TextStr].ToString();
                MyItem.Value = MyReader[ValueStr].ToString();
                MyDDL.Items.Add(MyItem);
            }
            MyReader.Close();
        }
        //绑定到DropDownList，设定Text和value显示
        public static void BindDropDownListAddEmpty(string SqlString, DropDownList MyDDL, string TextStr, string ValueStr)
        {
            SqlDataReader MyReader = GetDataReader(SqlString);
            MyDDL.Items.Clear();
            ListItem MyItem1 = new ListItem();
            MyItem1.Text = "";
            MyItem1.Value = "0";
            MyDDL.Items.Add(MyItem1);
            while (MyReader.Read())
            {
                ListItem MyItem = new ListItem();
                MyItem.Text = MyReader[TextStr].ToString();
                MyItem.Value = MyReader[ValueStr].ToString();
                MyDDL.Items.Add(MyItem);
            }
            MyReader.Close();
        }
        //返回一个用 | 分隔的字符串
        public static string GetStringList(string SqlString)
        {
            string ReturnStr = string.Empty;
            SqlDataReader MyReader = GetDataReader(SqlString);
            while (MyReader.Read())
            {
                if (ReturnStr.Length > 0)
                {
                    ReturnStr = ReturnStr + "|" + MyReader[0].ToString();
                }
                else
                {
                    ReturnStr = MyReader[0].ToString();
                }
            }
            MyReader.Close();
            return ReturnStr;
        }
        //返回当前最大的列值
        public static int GetMaxID(string FieldName, string TableName)
        {
            int MyReturn = 0;
            SqlDataReader MyReader = GetDataReader("select max(" + FieldName + ") from " + TableName);
            if (MyReader.Read())
            {
                MyReturn =int.Parse(MyReader[0].ToString());
            }
            MyReader.Close();
            return MyReturn;
        }
        //判断用Sql查询的数据是否存在,true表示存在，False表示不存在
        public static bool Exists(string strSql)
        {
            object obj = DbHelperSQL.GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            object obj = DbHelperSQL.GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //返回SqlDataReader数据集,使用完后记得关闭SqlDataReader
        public static SqlDataReader GetDataReader(string SqlString)
        {
            Open();
            SqlCommand cmd = new SqlCommand(SqlString, Connection);
            return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }
        // 公有方法，获取数据，返回一个DataSet。    
        public static DataSet GetDataSet(string SqlString)
        {
            DataSet dataset = new DataSet();
            try
            {
                Open();
                SqlDataAdapter adapter = new SqlDataAdapter(SqlString, Connection);
                adapter.Fill(dataset);
                
            }
            catch
            {

            }
            finally
            {
                Close();
            }
            return dataset;
        }
        // 公有方法，获取数据，返回一个DataTable。    
        public static DataTable GetDataTable(string SqlString)
        {
            DataSet dataset = GetDataSet(SqlString);
            return dataset.Tables[0];
        }
        // 公有方法，获取数据，返回首行首列。    
        public static string GetSHSL(string SqlString)
        {
            DataSet dataset = GetDataSet(SqlString);
            if (dataset.Tables[0].Rows.Count > 0)
            {
                return Convert.ToString(dataset.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                return "";
            }
        }
        // 公有方法，获取数据，返回首行首列的INT值。    
        public static string GetSHSLInt(string SqlString)
        {
            DataSet dataset = GetDataSet(SqlString);
            if (dataset.Tables[0].Rows.Count > 0)
            {
                return Convert.ToString(dataset.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                return "0";
            }
        }
        // 公有方法，获取数据，返回一个DataRow。
        public static DataRow GetDataRow(string SqlString)
        {
            DataSet dataset = GetDataSet(SqlString);
            if (dataset.Tables[0].Rows.Count > 0)
            {
                return dataset.Tables[0].Rows[0];
            }
            else
            {
                return null;
            }
        }        
        // 公有方法，执行Sql语句。对Update、Insert、Delete为影响到的行数，其他情况为-1
        public static int ExecuteSQL(String SqlString, Hashtable MyHashTb)
        {
            int count = -1;
            Open();
            try
            {
                SqlCommand cmd = new SqlCommand(SqlString, Connection);
                foreach (DictionaryEntry item in MyHashTb)
                {
                    string[] CanShu = item.Key.ToString().Split('|');
                    if (CanShu[1].ToString().Trim() == "string")
                    {
                        cmd.Parameters.Add(CanShu[0], SqlDbType.VarChar);
                    }
                    else if (CanShu[1].ToString().Trim() == "int")
                    {
                        cmd.Parameters.Add(CanShu[0], SqlDbType.Int);
                    }
                    else if (CanShu[1].ToString().Trim() == "text")
                    {
                        cmd.Parameters.Add(CanShu[0], SqlDbType.Text);
                    }
                    else if (CanShu[1].ToString().Trim() == "datetime")
                    {
                        cmd.Parameters.Add(CanShu[0], SqlDbType.DateTime);
                    }
                    else
                    {
                        cmd.Parameters.Add(CanShu[0], SqlDbType.VarChar);
                    }
                    cmd.Parameters[CanShu[0]].Value = item.Value.ToString();
                }
                count = cmd.ExecuteNonQuery();
            }
            catch
            {
                count = -1;
            }
            finally
            {
                Close();
            }
            return count;
        }
        // 公有方法，执行Sql语句。对Update、Insert、Delete为影响到的行数，其他情况为-1
        public static int ExecuteSQL(String SqlString)
        {
            int count = -1;
            Open();
            try
            {
                SqlCommand cmd = new SqlCommand(SqlString, Connection);
                count = cmd.ExecuteNonQuery();
            }
            catch
            {
                count = -1;
            }
            finally
            {
                Close();
            }
            return count;
        }
        // 公有方法，执行一组Sql语句。返回是否成功,采用事务管理，发现异常时回滚数据
        public static bool ExecuteSQL(string[] SqlStrings)
        {
            bool success = true;
            Open();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction trans = Connection.BeginTransaction();
            cmd.Connection = Connection;
            cmd.Transaction = trans;
            try
            {
                foreach (string str in SqlStrings)
                {
                    if((str != null)&&(str != ""))
                    {
                        cmd.CommandText = str;
                        cmd.ExecuteNonQuery();
                    }
                }
                trans.Commit();
            }
            catch
            {
                success = false;
                trans.Rollback();
            }
            finally
            {
                Close();
            }
            return success;
        }        
        // 执行一条计算查询结果语句，返回查询结果（object）。        
        public static object GetSingle(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }
        public static object GetSingle(string SQLString, int Times)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.CommandTimeout = Times;
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }
        public static object GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }
        // 执行SQL语句，返回影响的记录数
        public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }

        public static DataSet RunProc_ds(string procName)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            DataSet ds = new DataSet();
            try
            {
                da.SelectCommand.Connection = connection;
                da.SelectCommand.CommandText = procName;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(ds);
            }
            catch
            {

            }
            finally
            {
                da.Dispose();
                Close();

            }
            return ds;
        }

        //执行查询语句，返回DataSet
        public static DataSet Query(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {


                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }
    }
}