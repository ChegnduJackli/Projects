using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using FileUtil;
using System.IO;

namespace DAL
{
    public class TableDAL
    {
        private string TableRootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Tables");

        public List<string> GetAllTableName()
        {
            List<string> tableList = new List<string>();
            try
            {
                string sql = "select table_name from information_schema.tables";
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
        //如果表的数据太大。可以分段取数据存在不同的文件中，在做还原的时候需要dataset的合并。再写入数据库。
        public DataSet GetTableData(string tableName)
        {
            try
            {
                string sql = string.Format("select * from {0}", tableName);
                DataSet ds = SqlHelper.Query(sql);
                ds.DataSetName = tableName;
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void BackUpTableList(List<string> tableNameList)
        {
            foreach (string tableName in tableNameList)
            {
                WriteTableToFile(tableName);
                Log4.LogInstance.FileLogInstance().WriteLog("back up table " + tableName + " successfully");
            }
        }

        #region 递归存含有外键的表
        private void BackUpTableWithForeignKey(string parentTable)
        {
            string sql = string.Empty;
            string sonTable = string.Empty;

            sql = string.Format(@"select object_name(parent_object_id) AS TableWithForeignKey
                                        ,object_name(referenced_object_id) AS MyTable
                                    from .sys.foreign_keys 
                                    WHERE object_name(referenced_object_id)='{0}'", parentTable);
            DataTable dtForeign = SqlHelper.Query(sql).Tables[0];
            if (dtForeign.Rows.Count > 0)
            {
                foreach (DataRow dr in dtForeign.Rows)
                {
                    sonTable = dr["TableWithForeignKey"].ToString();
                    WriteTableToFile(sonTable);
                    BackUpTableWithForeignKey(sonTable);
                }
            }
        }
        #endregion

        /// <summary>
        /// store table data to xml file
        /// </summary>
        /// <param name="tableName"></param>
        private void WriteTableToFile(string tableName)
        {
            string fileName = Path.Combine(TableRootPath, tableName + ".xml");
            DataSet ds = GetTableData(tableName);
            ds.WriteXml(fileName, XmlWriteMode.IgnoreSchema);
        }

        #region for single table
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
                            string sql = string.Format("delete from table {0}", tableName);
                        
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
                isSuccuss = false;
                throw ex;
            }
            return isSuccuss;
        }
        #endregion

        public bool RetoreDataTableList(List<string> tableNameList)
        {
            bool isSuccuss = false;
            string sql = string.Empty;

            try
            {
                using (SqlConnection conn = new SqlConnection(SqlHelper.connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    SqlTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;

                    try
                    {
                        //disable all contraints
                        sql = string.Format(@"EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT all'");
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();

                        foreach (string tableName in tableNameList)
                        {
                            //back up son table to reference current table as foreign key.
                            //BackUpTableWithForeignKey(tableName);

                            string fileName = Path.Combine(TableRootPath, tableName + ".xml");
                            DataSet ds = new DataSet();
                            ds.ReadXml(fileName);

                            //delete table data first
                            sql = string.Format("delete from {0}", tableName);

                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();

                            //insert datatable to db tables
                            //KeepIdentity保留源标识值。 如果未指定，则由目标分配标识值。
                            SqlBulkCopy bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.KeepIdentity | SqlBulkCopyOptions.FireTriggers, transaction);
                            bulkCopy.DestinationTableName = tableName;
                            bulkCopy.WriteToServer(ds.Tables[0]);
                            Log4.LogInstance.FileLogInstance().WriteLog("restore table " + tableName + " successfully");   
                        }

                        sql = string.Format("EXEC sp_msforeachtable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all'");
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();

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
            catch (Exception ex)
            {
                isSuccuss = false;
                Log4.LogInstance.FileLogInstance().WriteLog("restore table failed" + ex.Message);
                throw ex;
            }
            return isSuccuss;
        }
    }
}
