using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GenereateTableDictionary
{
    public class GenerateTable:IGenerateExcel
    {
       
        string SQL_ColumnNameByTable = "select column_name, data_type, data_length from USER_TAB_COLUMNS where table_name='{0}' ";
        string SQL_PKAndIndex = @"SELECT  cols.column_name, cons.Index_Name
                                    FROM all_constraints cons, all_cons_columns cols
                                    WHERE 
                                    cols.table_name = '{0}'
                                    AND cons.constraint_type = 'P'
                                    AND  cons.constraint_name = cols.constraint_name
                                    AND cons.owner = cols.owner
                                    ORDER BY cols.table_name, cols.position";
        string SQL_Count = "select count(1) as Count from {0}";

        string Column_Name = "Column Name";
        string Column_Data_Type = "Data Type";
        string Column_Data_Length = "Data Length";
        string Column_Is_PK = "PK";
        string Column_TableName = "Table Name";
        string Coulumn_DataCount = "Data Count";

        ExcelHelper excelHeler = new ExcelHelper();
        Common com = new Common();

        public void GenerateExcel()
        {
            try
            {
                DataSet dsExcel = new DataSet();

                DataSet ds = com.GetAllTableName();
                //table list
                DataTable dtTableHeader = GetTableHeader();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string tableName = dr["table_name"].ToString();
                    DataRow row = dtTableHeader.NewRow();
                    string sql = string.Format(SQL_Count, tableName);
                    DataTable dtCount = OracleHelper.ExecuteDataset(CommandType.Text, sql).Tables[0];
                    int count = Convert.ToInt32(dtCount.Rows[0]["Count"]);
                    row[Column_TableName] = tableName;
                    row[Coulumn_DataCount] = count;
                    dtTableHeader.Rows.Add(row);
                }

                dsExcel.Tables.Add(dtTableHeader);

                //table details
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string tableName = dr["table_name"].ToString();
                    string sqlCol = string.Format(SQL_ColumnNameByTable, tableName);
                    DataTable dtColumn = OracleHelper.ExecuteDataset(CommandType.Text, sqlCol).Tables[0];
                    DataTable dtHeader = GetHeader(tableName);
                    foreach (DataRow drCol in dtColumn.Rows)
                    {
                        DataRow row = dtHeader.NewRow();
                        row[Column_Name] = drCol["column_name"].ToString();
                        row[Column_Data_Type] = drCol["data_type"].ToString();
                        row[Column_Data_Length] = drCol["data_length"].ToString();

                        string sqlPKandIndex = string.Format(SQL_PKAndIndex, tableName);
                        DataTable dtPk = OracleHelper.ExecuteDataset(CommandType.Text, sqlPKandIndex).Tables[0];
                        foreach (DataRow PKR in dtPk.Rows)
                        {
                            if (PKR["column_name"] != DBNull.Value && drCol["column_name"].ToString() == PKR["column_name"].ToString())
                            {
                                row["PK"] = "Y";
                            }
                        }
                        dtHeader.Rows.Add(row);
                    }
                    dsExcel.Tables.Add(dtHeader);
                }
                excelHeler.GenerateExcel(dsExcel, PubConstant.TableColumnFilePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetHeader(string tableName)
        {
            DataTable table = new DataTable(tableName);
            table.Columns.Add(new DataColumn(Column_Name, typeof(string)));
            table.Columns.Add(new DataColumn(Column_Data_Type,typeof(string)));
            table.Columns.Add(new DataColumn(Column_Data_Length, typeof(int)));
            table.Columns.Add(new DataColumn(Column_Is_PK, typeof(string)));
            return table;
        }

        public DataTable GetTableHeader()
        {
            DataTable table = new DataTable("Table List");
            table.Columns.Add(new DataColumn(Column_TableName, typeof(string)));
            table.Columns.Add(new DataColumn(Coulumn_DataCount, typeof(int)));
            return table;
        }

    }
}
