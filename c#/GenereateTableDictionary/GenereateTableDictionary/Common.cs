using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GenereateTableDictionary
{
    public class Common
    {
        //string SQL_GetAllTableName = "select table_name from user_tables";
        string SQL_GetAllTableName = "select table_name from all_tables where owner='SYSADM'";

        public DataSet GetAllTableName()
        {
            DataSet ds = OracleHelper.ExecuteDataset(CommandType.Text, SQL_GetAllTableName);
            return ds;
        }
        public string GetOwner()
        {
            DataTable dt = GetAllTableName().Tables[0];
            string tableName = dt.Rows[0]["table_name"].ToString();
            string sql = string.Format("SELECT owner FROM ALL_OBJECTS where object_name='{0}'",tableName);
            DataTable dtOwner = OracleHelper.ExecuteDataset(CommandType.Text, SQL_GetAllTableName).Tables[0];
            return dtOwner.Rows[0]["owner"].ToString();
        }
    }
}
