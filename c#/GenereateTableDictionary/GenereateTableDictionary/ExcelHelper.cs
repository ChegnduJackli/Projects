using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Xml;
using System.Xml.Xsl;
using System.IO;

namespace GenereateTableDictionary
{
    public class ExcelHelper
    {
        public void GenerateExcel(DataSet ds,string filePath)
        {
            if (ds.Tables[0].Rows.Count == 0) return;

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            ExportDataSetToExcel(ds, filePath);
        }
        //write dataset to excel
        private void ExportDataSetToExcel(DataSet ds,string filePath)
        {
            //Creae an Excel application instance
            Excel.Application excelApp = new Excel.Application();

            //Create an Excel workbook instance and open it from the predefined location
            //Excel.Workbook excelWorkBook = excelApp.Workbooks.Open(PubConstant.FileFullName);
            Excel.Workbook excelWorkBook = excelApp.Workbooks.Add();

            foreach (DataTable table in ds.Tables)
            {
                //Add a new worksheet to workbook with the Datatable name
                Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add();
                excelWorkSheet.Name = table.TableName;

                for (int i = 1; i < table.Columns.Count + 1; i++)
                {
                    excelWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
                    excelWorkSheet.StandardWidth = table.Columns[i - 1].ColumnName.Length + 10;
                }
                //set  column header color and font
                Excel.Range usedRange = excelWorkSheet.UsedRange;
                usedRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                usedRange.Font.Bold = true;

                for (int j = 0; j < table.Rows.Count; j++)
                {
                    for (int k = 0; k < table.Columns.Count; k++)
                    {
                        excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                    }
                }
            }
            excelWorkBook.SaveAs(filePath);
            excelWorkBook.Close();
            excelApp.Quit();
        }

        protected virtual bool IsFileLocked(string filePath)
        {
            FileStream stream = null;
            FileInfo file = new FileInfo(filePath);

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }
    }
}
