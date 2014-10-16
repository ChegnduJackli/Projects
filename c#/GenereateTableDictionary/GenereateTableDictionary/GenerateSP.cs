using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GenereateTableDictionary
{
    public class GenerateSP : IGenerateExcel
    {
        string SQL_SP_PackageName = @"SELECT distinct object_name as packageName FROM User_Procedures
                                        where object_type in('PROCEDURE','PACKAGE') and procedure_name is not null 
                                        order BY object_name";
        string SQL_SP_Name = @"SELECT object_name as packageName,procedure_name FROM User_Procedures 
                                        where object_type in('PROCEDURE','PACKAGE') and procedure_name is not null and object_name='{0}'";

        ExcelHelper excelHelper = new ExcelHelper();
        string SP_PackageName = "Package Name";
        string SP_Name = "Procedure Name";

        public void GenerateExcel()
        {
            try
            {
                DataSet dsSP = new DataSet();

                DataSet ds = OracleHelper.ExecuteDataset(CommandType.Text, SQL_SP_PackageName);

                if (ds.Tables[0].Rows.Count == 0) return;

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string packageName = dr["packageName"].ToString();
                    DataTable dtSPHeader = GetSPHeader(packageName);
                    string sql = string.Format(SQL_SP_Name, packageName);
                    DataTable dtSPName = OracleHelper.ExecuteDataset(CommandType.Text, sql).Tables[0];
                    foreach (DataRow drIndex in dtSPName.Rows)
                    {
                        DataRow row = dtSPHeader.NewRow();
                        row[SP_PackageName] = packageName;
                        row[SP_Name] = drIndex["procedure_name"].ToString();
                        dtSPHeader.Rows.Add(row);
                    }
                    dsSP.Tables.Add(dtSPHeader);
                }
                excelHelper.GenerateExcel(dsSP, PubConstant.SPFilePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetSPHeader(string tableName)
        {
            DataTable table = new DataTable(tableName);
            table.Columns.Add(new DataColumn(SP_PackageName, typeof(string)));
            table.Columns.Add(new DataColumn(SP_Name, typeof(string)));
            return table;
        }
    }
}

