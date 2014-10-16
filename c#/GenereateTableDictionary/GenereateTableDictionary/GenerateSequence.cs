using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GenereateTableDictionary
{
    public class GenerateSequence:IGenerateExcel
    {
        string SQL_SEQ = "select sequence_name, min_value, max_value, increment_by, last_number from USER_SEQUENCES";

        ExcelHelper excelHelper = new ExcelHelper();

        public void GenerateExcel()
        {
            try
            {
                DataSet ds = OracleHelper.ExecuteDataset(CommandType.Text, SQL_SEQ);
                ds.Tables[0].TableName = "Sequence";
                excelHelper.GenerateExcel(ds, PubConstant.SequenceFilePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
