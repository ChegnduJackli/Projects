using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GenereateTableDictionary
{
    public class GenerateTableDataCount : IGenerateExcel
    {
        string column_TableName = "Table Name";
        string column_Count = "Data Count";

        ExcelHelper excelHelper = new ExcelHelper();
        string SQL_Count = "select count(1) as Count from {0}";

        public void GenerateExcel()
        {
            try
            {
                DataSet ds = new DataSet();

                DataTable dt = GetTableHeader("Table Data Count");
                DataSet dsTable = new Common().GetAllTableName();
                foreach (DataRow dr in dsTable.Tables[0].Rows)
                {
                    DataRow row = dt.NewRow();

                    string tableName = dr["table_name"].ToString();
                    string sql = string.Format(SQL_Count, tableName);
                    DataTable dtCount = OracleHelper.ExecuteDataset(CommandType.Text, sql).Tables[0];
                    int count = Convert.ToInt32(dtCount.Rows[0]["Count"]);
                    row[column_TableName] = tableName;
                    row[column_Count] = count;
                    dt.Rows.Add(row);
                }
                ds.Tables.Add(dt);
                excelHelper.GenerateExcel(ds, PubConstant.DataCountFilePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetTableHeader(string tableName)
        {
            DataTable table = new DataTable(tableName);
            table.Columns.Add(new DataColumn(column_TableName, typeof(string)));
            table.Columns.Add(new DataColumn(column_Count, typeof(int)));
            return table;
        }
    }
}
