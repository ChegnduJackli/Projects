using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for TaskType
/// </summary>
public class TaskType
{
    public enum Task
    {
        Choose = 0,
        Task = 1,
        Meeting = 2,
        Course = 3
    };

    public Task TaskStatus = Task.Choose;

    public TaskType(string typeID)
    {
        if (typeID == "0")
        {
            TaskStatus = Task.Choose;
        }
        else if (typeID == "1")
        {
            TaskStatus = Task.Task;
        }
        else if (typeID == "2")
        {
            TaskStatus = Task.Meeting;
        }
        else if (typeID == "3")
        {
            TaskStatus = Task.Course;
        }
        else
        {
            TaskStatus = Task.Choose;
        }
    }
	public TaskType()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static DataTable GetAllTaskType()
    {
        try
        {
            string sql = @"select * from TaskType";
            DataSet ds = SqlHelper.Query(sql);
            DataTable dt = ds.Tables[0]; ;
            return dt;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}