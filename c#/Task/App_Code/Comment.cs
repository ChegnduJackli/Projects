using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Comment
/// </summary>
public class Comment
{
    public static readonly string TableName = "Comment";
    public static readonly int PageSize = 10;
    public static readonly int OrderType = 0; //0 means asc, 1 meand desc.
    public static readonly string SP_PageIndex = "PageIndex";
	public Comment()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetCommetByid(int id)
    {
        try
        {
            string sql = @"select * from Comment where id=@id";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@id", id);
            DataSet ds = SqlHelper.Query(sql, par);
            return ds.Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetCommentByTaskID(int taskid)
    {
        try
        {
            string sql = @"select ROW_NUMBER() OVER(ORDER BY id DESC) AS rowid,* from Comment where TaskID=@taskid order by id Asc";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@taskid", taskid);
            DataSet ds = SqlHelper.Query(sql, par);
            return ds.Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetCommentByID(int taskID, int pageIndex)
    {
        string SP = SP_PageIndex;
        SqlParameter[] par = new SqlParameter[7];
        par[0] = new SqlParameter("@tblName", Comment.TableName);
        par[1] = new SqlParameter("@PageSize", Comment.PageSize);
        par[2] = new SqlParameter("@PageIndex", pageIndex);
        par[3] = new SqlParameter("@strGetFields", "*");
        par[4] = new SqlParameter("@OrderType", Comment.OrderType);
        par[5] = new SqlParameter("@fldName", "id");
        par[6] = new SqlParameter("@strWhere", " TaskID = "+taskID);
        DataSet ds = SqlHelper.RunProcedure(SP, par, "Comment");
        return ds.Tables[0];
    }

    public DataTable GetLastCommentByTaskID(int taskid)
    {
        try
        {
            string sql = @"select top 1 * from Comment where TaskID=@taskid order by id desc";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@taskid", taskid);
            DataSet ds = SqlHelper.Query(sql, par);
            return ds.Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool AddComment(int taskID,string content,string userID)
    {
        try
        {
            string sql = @"Insert into Comment(taskID,replyTime,Content,UserID) values(@taskID,@replyTime,@Content,@userID)";
            SqlParameter[] par = new SqlParameter[4];
            par[0] = new SqlParameter("@taskID", taskID);
            par[1] = new SqlParameter("@replyTime", DateTime.Now);
            par[2] = new SqlParameter("@Content", content);
            par[3] = new SqlParameter("@userID", userID);
            int result = SqlHelper.ExecuteSql(sql, par);
            return result > 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool DeleteComment(int id)
    {
        try
        {
            string sql = @"delete from Comment where id=@id";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@id", id);
            int result = SqlHelper.ExecuteSql(sql, par);
            return result > 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
   
}
public class CommentEntity
{
    public int RowID { get; set; }
    public int ID { get; set; }
    public string TaskID { get; set; }
    public string Content { get; set; }
    public string userID { get; set; }
    public DateTime ReplyTime { get; set; }
}