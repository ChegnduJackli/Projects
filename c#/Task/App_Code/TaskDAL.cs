using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;

/// <summary>
/// Summary description for DAL
/// </summary>
public class TaskDAL
{
    private string basicSQL = @"select t.*,a.TypeName,p.ProcessTypeName from task t 
                                    inner join TaskType a on t.TypeID = a.ID
                                    inner join ProcessType p on t.ProcessID = p.ID ";



    public TaskDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   
    public DataTable GetTaskByID(int id)
    {
        try
        {
            string sql = basicSQL + " where t.id=@id order by t.id desc";
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
    public DataSet GetTaskByUserID(string userID)
    {
        try
        {
            string sql =basicSQL+ " where userid=@userid order by id desc";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@userid", userID);
            DataSet ds = SqlHelper.Query(sql, par);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// search data from login user with some status
    /// </summary>
    /// <param name="userID"></param>
    /// <param name="status"></param>
    /// <returns></returns>
    public DataSet GetTaskByStatus(string userID,string typeID)
    {
        string sql = string.Empty;
        try
        {
            if (typeID == "0") //get all
            {
                sql = basicSQL + " where userid=@userid order by id desc";
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@userid", userID);
                DataSet ds = SqlHelper.Query(sql,par);
                return ds;
            }
            else
            {
                sql = basicSQL + " where TypeID=@TypeID and userid=@userid order by id desc";
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@TypeID", typeID);
                par[1] = new SqlParameter("@userid", userID);
                DataSet ds = SqlHelper.Query(sql, par);
                return ds;
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// search all data with some status
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    public DataSet GetTaskByCondition(string taskTypeID, string processTypeID)
    {
        string sql = basicSQL + " where ";
        string filter = string.Empty;
        DataSet ds = new DataSet();

        TaskType t =new TaskType (taskTypeID);

        if (t.TaskStatus == TaskType.Task.Choose) //get all task
        {
            filter += " 1=1";
        }
        else
        {
            filter += " TypeID =" + taskTypeID;
        }

        ProcessType p = new ProcessType(processTypeID);
        if (p.ProcessStatus == ProcessType.Process_Status.Choose)//get task all status.
        {
            filter += " and 1=1";
        }
       
        else
        {
            filter += " and processID =" + processTypeID;
        }
        filter += "order by id desc";
        sql += filter;
        ds = SqlHelper.Query(sql);
        return ds;
    }

    public DataSet GetAllTask()
    {
        try
        {
            string sql = basicSQL + "order by id desc";
            DataSet ds = SqlHelper.Query(sql);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //update processid to some other status
    public bool UpdateStatus(int id,string status)
    {
        try
        {
            string sql = @"update task set ProcessID=@ProcessID, CompleteTime=@CompleteTime where id=@id";
            SqlParameter[] par = new SqlParameter[3];
            par[0] = new SqlParameter("@ProcessID", status);
            par[1] = new SqlParameter("@CompleteTime", DateTime.Now);
            par[2] = new SqlParameter("@id", id);
            int result = SqlHelper.ExecuteSql(sql, par);
            return result > 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool AddTask(TaskEntity entity)
    {
        try
        {
            string sql = @"insert into task(TypeID,CompleteTime,Title,Content,userid,createTime,Attachment,FileName,ProcessID)
                            values(@TypeID,@CompleteTime,@Title,@Content,@userid,@createTime,@Attachment,@FileName,@ProcessID)";

            SqlParameter[] par = new SqlParameter[9];
            par[0] = new SqlParameter("@TypeID", entity.TypeID);
            if (entity.Status == "Completed")
            {
                par[1] = new SqlParameter("@CompleteTime", DateTime.Now);
            }
            else
            {
                par[1] = new SqlParameter("@CompleteTime", DBNull.Value);
            }
            par[2] = new SqlParameter("@Title", entity.Title);
            par[3] = new SqlParameter("@Content", entity.Content);
            par[4] = new SqlParameter("@userid", entity.UserID);
            par[5] = new SqlParameter("@createTime", entity.CreateTime);
            par[6] = new SqlParameter("@Attachment", entity.Attachment);
            par[7] = new SqlParameter("@FileName", entity.FileName);
            par[8] = new SqlParameter("@ProcessID", entity.ProcessID);
            int result = SqlHelper.ExecuteSql(sql, par);
            return result > 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool UpdateTask(TaskEntity entity)
    {
        try
        {
            ProcessType p = new ProcessType(entity.ProcessID);

            string sql = @"update task set status=@status, CompleteTime=@CompleteTime,
                           Title=@Title,Content=@Content,Attachment=@Attachment,FileName=@FileName,ProcessID=@ProcessID where id=@id";
            SqlParameter[] par = new SqlParameter[8];
            par[0] = new SqlParameter("@status", entity.Status);
            if (p.ProcessStatus == ProcessType.Process_Status.Compeleted)
            {
                par[1] = new SqlParameter("@CompleteTime", DateTime.Now);
            }
            else
            {
                par[1] = new SqlParameter("@CompleteTime", DBNull.Value);
            }
            par[2] = new SqlParameter("@Title",entity.Title);
            par[3] = new SqlParameter("@Content", entity.Content);
            par[4] = new SqlParameter("@Attachment", entity.Attachment);
            par[5] = new SqlParameter("@FileName", entity.FileName);
            par[6] = new SqlParameter("@ProcessID", entity.ProcessID);
            par[7] = new SqlParameter("@id", entity.ID);
            int result = SqlHelper.ExecuteSql(sql, par);
            return result > 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool DeleteAttachmentInDB(int id)
    {
        try
        {
            string sql = @"update task set Attachment =NULL, FileName=NULL where id=@id";
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
    public bool DeleteTask(int id)
    {
        try
        {
            DeleteAttachmemtInFolder(id);

            string sql = @"delete from task where id=@id";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@id", id);
            int result = SqlHelper.ExecuteSql(sql, par);

            //delete comment
            sql = @"delete from comment where taskid=@id";
            int comment = SqlHelper.ExecuteSql(sql, par);

            //delete sub task, assign to someone.
            new SubTask().DeleteTask(id);

            return result > 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public string GetFileFullName(int id)
    {
        string fileName = string.Empty;
        try
        {
            DataTable dt = GetTaskByID(id);
            if (dt.Rows.Count > 0)
            {
                fileName = dt.Rows[0]["Attachment"].ToString();
            }
            return fileName;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private bool DeleteAttachmemtInFolder(int id)
    {
        try
        {
            string fileName = GetFileFullName(id);
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}

public class TaskEntity
{
    public string Title { get; set; }
    public DateTime CreateTime { get; set; }
    public string Content { get; set; }
    public DateTime CompleteTime { get; set; }
    public string UserID { get; set; }
    public string Status { get; set; }
    public int ID { get; set; }
    public string Attachment { get; set; }
    public string FileName { get; set; }
    public string TypeID { get; set; }
    public string ProcessID { get; set; }
}