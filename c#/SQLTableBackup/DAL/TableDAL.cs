using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using FileUtil;

namespace DAL
{
    public class TableDAL
    {
        public List<string> GetAllTableName()
        {
            List<string> tableList = new List<string>();
            try
            {
                string sql = "select table_name from information_schema.tables";
                //SqlParameter[] par = new SqlParameter[1];
                //par[0] = new SqlParameter("@id", id);
                DataSet ds = SqlHelper.Query(sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    tableList.Add(dr["table_name"].ToString());
                }
                return tableList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetTableData(string tableName)
        {
            try
            {
                string sql = string.Format("select * from {0}", tableName);
                DataSet ds = SqlHelper.Query(sql);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //the restore file don't have data to back up.
        //so,just delete the data in DB
        public bool RetoreDataTable(string tableName)
        {
            string sql = string.Format("truncate table {0}", tableName);
            int i = SqlHelper.ExecuteSql(sql);
            return true;
        }
        //insert datatable to DB
        public bool RetoreDataTable(string tableName, DataTable dataTable)
        {
            bool isSuccuss = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlHelper.connectionString))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            //delete table data first
                            string sql = string.Format("truncate table {0}", tableName);
                        
                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.Transaction = transaction;
                            cmd.ExecuteNonQuery();

                            //insert datatable to db tables
                            //KeepIdentity保留源标识值。 如果未指定，则由目标分配标识值。
                            SqlBulkCopy bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.KeepIdentity | SqlBulkCopyOptions.FireTriggers, transaction);
                            bulkCopy.DestinationTableName = tableName;
                            bulkCopy.WriteToServer(dataTable);

                            transaction.Commit();

                            isSuccuss = true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //isSuccuss = false;
                throw ex;
            }
            return isSuccuss;
        }
    }
}
