using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Data;

/// <summary>
/// Summary description for Common
/// </summary>
public class Common
{
	public Common()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //public static DataTable  GetStatus()
    //{
    //    try
    //    {
    //        string sql = @"select * from TaskType";
    //        DataSet ds = SqlHelper.Query(sql);
    //        return ds.Tables[0];
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    public static List<string> StatusNoShow()
    {
        List<string> status = new List<string>();

        status.Add("--Please select status--");
        status.Add("Course");
        status.Add("Meeting");
        return status;
    }
    public static string GetFullName(string fileName)
    {
        if (fileName.Length > 0)
        {
            String fileExt = System.IO.Path.GetExtension(fileName).ToLower();
            String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;
            return newFileName;
        }
        return string.Empty;
    }

    public static string ListToString(List<string> obj)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        string separator = ";";
        foreach (string s in obj)
        {
            sb .Append(s + separator);
        }
        return sb.ToString();
    }
}