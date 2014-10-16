using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GenereateTableDictionary
{
    public class GenerateTrigger : IGenerateExcel
    {
        string sql = "select trigger_name,trigger_type, table_name, triggering_event from USER_TRIGGERS";

        ExcelHelper excelHelper = new ExcelHelper();

        public void GenerateExcel()
        {
            try
            {
                DataSet ds = OracleHelper.ExecuteDataset(CommandType.Text, sql);
                ds.Tables[0].TableName = "Trigger";
                excelHelper.GenerateExcel(ds, PubConstant.TriggerFilePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
