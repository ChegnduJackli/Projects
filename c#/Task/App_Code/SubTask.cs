using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SubTask
/// </summary>
public class SubTask
{
	public SubTask()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool AddTask(int taskID, string userID)
    {
        try
        {
            string sql = @"Insert into SubTask(taskID,UserID) values(@taskID,@userID)";
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@taskID", taskID);
            par[1] = new SqlParameter("@userID", userID);
            int result = SqlHelper.ExecuteSql(sql, par);
            return result > 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public bool UpdateTask(int taskID, string userID)
    {
        try
        {
            string sql = @"update SubTask set UserID=@userID where TaskID=@taskID";
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@userID", userID);
            par[1] = new SqlParameter("@taskID", taskID);
            int result = SqlHelper.ExecuteSql(sql, par);
            return result > 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public bool DeleteTask(int taskID)
    {
        try
        {
            string sql = @"Delete from SubTask where TaskID=@taskID";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@taskID", taskID);
            int result = SqlHelper.ExecuteSql(sql, par);
            return result > 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}