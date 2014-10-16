using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GenereateTableDictionary
{
    public class GenerateIndex : IGenerateExcel
    {
        string index_Uniqueness = "Uniqueness";
        string index_Name = "Index Name";
        string index_TableName = "Table Name";
        string index_ColumnName = "Column Name";

        string SQL_Index = @"select distinct
                            b.uniqueness, a.index_name, a.table_name, a.column_name 
                            from all_ind_columns a, all_indexes b
                            where a.index_name=b.index_name 
                            and a.table_name = upper('{0}')";

        Common com = new Common();
        ExcelHelper excelHelper = new ExcelHelper();

        public DataTable GetIndexHeader(string tableName)
        {
            DataTable table = new DataTable(tableName);
            table.Columns.Add(new DataColumn(index_TableName, typeof(string)));
            table.Columns.Add(new DataColumn(index_ColumnName, typeof(string)));
            table.Columns.Add(new DataColumn(index_Name, typeof(string)));
            table.Columns.Add(new DataColumn(index_Uniqueness, typeof(string)));
            return table;
        }

        public void GenerateExcel()
        {
            try
            {
                DataSet ds = new DataSet();
                DataSet dsTable = com.GetAllTableName();
                //table list
                foreach (DataRow dr in dsTable.Tables[0].Rows)
                {
                    string tableName = dr["table_name"].ToString();
                    string sqlCol = string.Format(SQL_Index, tableName);
                    DataTable dtIndex = OracleHelper.ExecuteDataset(CommandType.Text, sqlCol).Tables[0];
                    DataTable dtIndexHeader = GetIndexHeader(tableName);
                    foreach (DataRow drIndex in dtIndex.Rows)
                    {
                        DataRow row = dtIndexHeader.NewRow();
                        row[index_Uniqueness] = drIndex["uniqueness"].ToString();
                        row[index_Name] = drIndex["index_name"].ToString();
                        row[index_TableName] = drIndex["table_name"].ToString();
                        row[index_ColumnName] = drIndex["column_name"].ToString();
                        dtIndexHeader.Rows.Add(row);
                    }
                    if (dtIndexHeader.Rows.Count > 0)//have index then add to dataset
                    {
                        ds.Tables.Add(dtIndexHeader);
                    }
                }
                //generate index to excel
                excelHelper.GenerateExcel(ds, PubConstant.TableIndexFilePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
