using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GenereateTableDictionary
{
    public class GenerateView : IGenerateExcel
    {
        string SQL_View = "select view_name, text_length from user_views";

        ExcelHelper excelHelper = new ExcelHelper();

        public void GenerateExcel()
        {
            try
            {
                DataSet ds = OracleHelper.ExecuteDataset(CommandType.Text, SQL_View);
                ds.Tables[0].TableName = "View";
                excelHelper.GenerateExcel(ds, PubConstant.TableViewFilePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
