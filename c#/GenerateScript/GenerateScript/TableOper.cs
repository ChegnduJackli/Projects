using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;

namespace GenerateScript
{
   public class TableOper
    {
       string Column_ColumnName = "ColumnName";
       string Type_Number = "Number";
       string Type_String = "String";
       string Type_Date = "Date";

        //get table all headers
       private String PopulateHeader(DataTable dt)
       {
           string seperator = PubConstant.FieldSeperator;
           string headerColumn = string.Empty;
           StringBuilder sb = new StringBuilder();
           try
           {
               foreach (DataColumn dc in dt.Columns)
               {
                   if (dc.ColumnName == Column_ColumnName) continue;
                   sb.Append(dc.ColumnName);
                   sb.Append(",");
               }
               headerColumn = sb.ToString();
               if (headerColumn.LastIndexOf(",") > -1)
               {
                   headerColumn = headerColumn.Substring(0, headerColumn.Length - 1);
               }
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return headerColumn;

       }
       private bool IsDateTime(string date)
       {
           DateTime dt;
           if (DateTime.TryParse(date, out dt))
           {
               return true;
           }
           return false;
       }
       private List<string> PopulateData(DataTable dt)
       {
           string dataColumn = string.Empty;
           StringBuilder sb = new StringBuilder();
           string seperator = PubConstant.FieldSeperator;
           List<string> dataList = new List<string>();
           try
           {

               for (int i = 2; i < dt.Rows.Count; i++)
               {
                   for (int j = 1; j < dt.Columns.Count; j++)
                   {
                       if (dt.Rows[1][j].ToString().Equals(Type_Number,StringComparison.OrdinalIgnoreCase))  //judge type
                       {
                           sb.Append(dt.Rows[i][j]);
                       }
                       else if (dt.Rows[1][j].ToString().Equals(Type_Date,StringComparison.OrdinalIgnoreCase))
                       {
                           if (dt.Rows[i][j].ToString().Equals("sysdate", StringComparison.OrdinalIgnoreCase))
                           {
                               sb.Append(dt.Rows[i][j]);
                           }
                           else
                           {
                               if (IsDateTime(dt.Rows[i][j].ToString()))
                               {
                                   sb.Append("to_date(" + seperator + Convert.ToDateTime(dt.Rows[i][j]).ToString("yyyy/MM/dd HH:mm") + seperator + "," + seperator + ("yyyy/MM/dd hh24:mi") + seperator + ")");
                               }
                               else
                               {
                                   sb.Append(seperator + string.Empty + seperator);
                               }
                           }
                       }
                       else
                       {
                           //type is string
                           sb.Append(seperator + dt.Rows[i][j] + seperator);
                       }
                       sb.Append(",");
                   }
                   dataColumn = sb.ToString();
                   sb.Clear();
                   if (dataColumn.LastIndexOf(",") > -1)
                   {
                       dataColumn = dataColumn.Substring(0, dataColumn.Length - 1);
                   }
                   dataList.Add(dataColumn);
               }
           }
           catch(Exception ex)
           {
               throw ex;
           }
           return dataList;
       }

       public string PopulateScript(DataTable dt)
       {
           string result = string.Empty;
           string headerColumn = string.Empty;
           string dataColumn = string.Empty;
           string seperator = PubConstant.FieldSeperator;
           string template = ConfigurationManager.AppSettings["ScriptTemplate"];
           StringBuilder sb = new StringBuilder();
           string TableName = "";

           try
           {

               TableName = dt.Rows[0][1].ToString();
               headerColumn = PopulateHeader(dt);

               List<string> dataList = PopulateData(dt);
               template = template.Replace("@TableName", TableName).Replace("@TableColumns", headerColumn);
               foreach (string item in dataList)
               {
                   string eachItem = item.Replace(seperator, "'");
                   string stemplate = template.Replace("@TableData", eachItem);
                   sb.AppendLine(stemplate);
               }

           }
           catch (Exception ex)
           {
               throw ex;
           }
           return sb.ToString(); ;
 
       }
    }
}
