using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GenereateTableDictionary
{
    public class GenerateFunction : IGenerateExcel
    {
        string SQL_Func = "SELECT object_name as Function_Name FROM User_Procedures where object_type='FUNCTION'";

        ExcelHelper excelHelper = new ExcelHelper();

        public void GenerateExcel()
        {
            try
            {
                DataSet ds = OracleHelper.ExecuteDataset(CommandType.Text, SQL_Func);
                ds.Tables[0].TableName = "Function";
                excelHelper.GenerateExcel(ds, PubConstant.FunctionFilePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
