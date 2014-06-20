using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ProcessType
/// </summary>
public class ProcessType
{
    public enum Process_Status
    {
        Choose = 0,  //please select status
        NotStarted = 1,
        Processing = 2,
        Compeleted = 3
    };
    public Process_Status ProcessStatus = Process_Status.Choose;

	public ProcessType()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public ProcessType(string typeID)
    {
        if (typeID == "0")
        {
            ProcessStatus = Process_Status.Choose;
        }
        else if (typeID == "1")
        {
            ProcessStatus = Process_Status.NotStarted;
        }
        else if (typeID == "2")
        {
            ProcessStatus = Process_Status.Processing;
        }
        else if (typeID == "3")
        {
            ProcessStatus = Process_Status.Compeleted;
        }
        else
        {
            ProcessStatus = Process_Status.Choose;
        }
    }
    public static DataTable GetAllProcessType()
    {
        try
        {
            string sql = @"select * from ProcessType";
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