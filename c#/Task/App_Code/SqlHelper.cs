﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

/// <summary>
/// Summary description for SqlHelper
/// </summary>
public class SqlHelper
{
    public static string connectionString = ConfigurationManager.ConnectionStrings["TaskConn"].ConnectionString;
	public SqlHelper()
	{
      
	}
    
    public static int ExecuteSql(string SQLString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(SQLString, connection))
            {
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    connection.Close();
                    throw e;
                }
            }
        }
    }

    /// <summary>  
    /// 执行一条计算查询结果语句，返回查询结果（object）。  
    /// </summary>  
    /// <param name="SQLString">计算查询结果语句</param>  
    /// <returns>查询结果（object）</returns>  
    public static object GetSingle(string SQLString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
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

    /// <summary>  
    /// 执行查询语句，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )  
    /// </summary>  
    /// <param name="strSQL">查询语句</param>  
    /// <returns>SqlDataReader</returns>  
    public static SqlDataReader ExecuteReader(string strSQL)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(strSQL, connection);
        try
        {
            connection.Open();
            SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return myReader;
        }
        catch (System.Data.SqlClient.SqlException e)
        {
            throw e;
        }
    }
    /// <summary>  
    /// 执行查询语句，返回DataSet  
    /// </summary>  
    /// <param name="SQLString">查询语句</param>  
    /// <returns>DataSet</returns>  
    public static DataSet Query(string SQLString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                command.Fill(ds, "ds");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return ds;
        }
    }

    #region 执行带参数的SQL语句
    /// <summary>  
    /// 执行SQL语句，返回影响的记录数  
    /// </summary>  
    /// <param name="SQLString">SQL语句</param>  
    /// <returns>影响的记录数</returns>  
    public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
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
        /// <summary>  
        /// 执行一条计算查询结果语句，返回查询结果（object）。  
        /// </summary>  
        /// <param name="SQLString">计算查询结果语句</param>  
        /// <returns>查询结果（object）</returns>  
        public static object GetSingle(string SQLString, params SqlParameter[] cmdParms)  
        {  
            using (SqlConnection connection = new SqlConnection(connectionString))  
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
        /// <summary>  
        /// 执行查询语句，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )  
        /// </summary>  
        /// <param name="strSQL">查询语句</param>  
        /// <returns>SqlDataReader</returns>  
        public static SqlDataReader ExecuteReader(string SQLString, params SqlParameter[] cmdParms)  
        {  
            SqlConnection connection = new SqlConnection(connectionString);  
            SqlCommand cmd = new SqlCommand();  
            try  
            {  
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);  
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);  
                cmd.Parameters.Clear();  
                return myReader;  
            }  
            catch (System.Data.SqlClient.SqlException e)  
            {  
                throw e;  
            }  
        }  
        /// <summary>  
        /// 执行查询语句，返回DataSet  
        /// </summary>  
        /// <param name="SQLString">查询语句</param>  
        /// <returns>DataSet</returns>  
        public static DataSet Query(string SQLString, params SqlParameter[] cmdParms)  
        {  
            using (SqlConnection connection = new SqlConnection(connectionString))  
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
        #endregion  

      #region 存储过程操作  
        /// <summary>  
        /// 执行存储过程，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )  
        /// </summary>  
        /// <param name="storedProcName">存储过程名</param>  
        /// <param name="parameters">存储过程参数</param>  
        /// <returns>SqlDataReader</returns>  
        public static SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)  
        {  
            SqlConnection connection = new SqlConnection(connectionString);  
            SqlDataReader returnReader;  
            connection.Open();  
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);  
            command.CommandType = CommandType.StoredProcedure;  
            returnReader = command.ExecuteReader(CommandBehavior.CloseConnection);  
            return returnReader;  
        }  
        /// <summary>  
        /// 执行存储过程  
        /// </summary>  
        /// <param name="storedProcName">存储过程名</param>  
        /// <param name="parameters">存储过程参数</param>  
        /// <param name="tableName">DataSet结果中的表名</param>  
        /// <returns>DataSet</returns>  
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)  
        {  
            using (SqlConnection connection = new SqlConnection(connectionString))  
            {  
                DataSet dataSet = new DataSet();  
                connection.Open();  
                SqlDataAdapter sqlDA = new SqlDataAdapter();  
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);  
                sqlDA.Fill(dataSet, tableName);  
                connection.Close();  
                return dataSet;  
            }  
        }  
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName, int Times)  
        {  
            using (SqlConnection connection = new SqlConnection(connectionString))  
            {  
                DataSet dataSet = new DataSet();  
                connection.Open();  
                SqlDataAdapter sqlDA = new SqlDataAdapter();  
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);  
                sqlDA.SelectCommand.CommandTimeout = Times;  
                sqlDA.Fill(dataSet, tableName);  
                connection.Close();  
                return dataSet;  
            }  
        }  
        /// <summary>  
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)  
        /// </summary>  
        /// <param name="connection">数据库连接</param>  
        /// <param name="storedProcName">存储过程名</param>  
        /// <param name="parameters">存储过程参数</param>  
        /// <returns>SqlCommand</returns>  
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)  
        {  
            SqlCommand command = new SqlCommand(storedProcName, connection);  
            command.CommandType = CommandType.StoredProcedure;  
            foreach (SqlParameter parameter in parameters)  
            {  
                if (parameter != null)  
                {  
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.  
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&  
                        (parameter.Value == null))  
                    {  
                        parameter.Value = DBNull.Value;  
                    }  
                    command.Parameters.Add(parameter);  
                }  
            }  
            return command;  
        }  
        /// <summary>  
        /// 执行存储过程，返回影响的行数        
        /// </summary>  
        /// <param name="storedProcName">存储过程名</param>  
        /// <param name="parameters">存储过程参数</param>  
        /// <param name="rowsAffected">影响的行数</param>  
        /// <returns></returns>  
        public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)  
        {  
            using (SqlConnection connection = new SqlConnection(connectionString))  
            {  
                int result;  
                connection.Open();  
                SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);  
                rowsAffected = command.ExecuteNonQuery();  
                result = (int)command.Parameters["ReturnValue"].Value;  
                //Connection.Close();  
                return result;  
            }  
        }  
        /// <summary>  
        /// 创建 SqlCommand 对象实例(用来返回一个整数值)     
        /// </summary>  
        /// <param name="storedProcName">存储过程名</param>  
        /// <param name="parameters">存储过程参数</param>  
        /// <returns>SqlCommand 对象实例</returns>  
        private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)  
        {  
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);  
            command.Parameters.Add(new SqlParameter("ReturnValue",  
                SqlDbType.Int, 4, ParameterDirection.ReturnValue,  
                false, 0, 0, string.Empty, DataRowVersion.Default, null));  
            return command;  
        }  
        #endregion  
  
}