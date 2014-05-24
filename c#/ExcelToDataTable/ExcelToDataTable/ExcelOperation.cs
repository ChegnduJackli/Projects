using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.POIFS;
using NPOI.Util;
using System.Configuration;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace ExcelToDataTable
{
    public class ExcelOperation
    {
        string Field_TableName = "TABLENAME";
        string Table_Name = "";

        
        /// <summary>
        /// 读取Excel[.xls](返回DataTable)
        /// </summary>
        /// <param name="path">Excel路径</param>
        /// <returns></returns>
        public string ReadExcel(string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    // HSSFWorkbook workbook = new HSSFWorkbook(fs);
                    XSSFWorkbook workbook = new XSSFWorkbook(fs);
                    ISheet sheet = workbook.GetSheetAt(0);
                    IRow row = sheet.GetRow(0);

                    //create tableName
                    if (row.GetCell(0).StringCellValue.ToUpper() == Field_TableName)
                    {
                        Table_Name = row.GetCell(1).ToString();
                    }

                  
                    row = sheet.GetRow(1);
                    StringBuilder sbColumnName = new System.Text.StringBuilder();
                    string columnName = string.Empty;

                    string seperator = PubConstant.Field_Seperator;

                    for (int k = 1; k < row.LastCellNum; k++)
                    {
                        sbColumnName.Append(row.GetCell(k).StringCellValue );
                        sbColumnName.Append(",");
                    }
                    columnName = sbColumnName.ToString();
                    if (columnName.LastIndexOf(",") > -1)
                    {
                        columnName = columnName.Substring(0, columnName.Length - 1);
                    }

                    List<string> dataList = new List<string>();
                    StringBuilder sbData = new System.Text.StringBuilder();
                    string data = "";
                    IRow rType = sheet.GetRow(2);
                    for (int j = 3; j < sheet.LastRowNum; j++)  //LastRowNum 是当前表的总行数
                    {

                        IRow r = sheet.GetRow(j);  //读取当前行数据
                        if (r != null)
                        {
                            for (int k = 1; k < rType.LastCellNum; k++)  //LastCellNum 是当前行的总列数
                            {
                             
                                ICell cell = r.GetCell(k);  //当前表格
                                if (cell != null)
                                {
                                    string type = rType.GetCell(k).StringCellValue;
                                    cell.SetCellType(CellType.String);
                                    if (type.Equals("string", StringComparison.OrdinalIgnoreCase))
                                    {
                                        sbData.Append(seperator + cell.StringCellValue.ToString() + seperator);
                                    }
                                    else if (type.Equals("number", StringComparison.OrdinalIgnoreCase))
                                    {
                                        sbData.Append(cell.StringCellValue.ToString());
                                    }

                                    sbData.Append(",");
                                }
                                else
                                {
                                    string type = rType.GetCell(k).StringCellValue;
                                    if (type.Equals("string", StringComparison.OrdinalIgnoreCase))
                                    {
                                        sbData.Append(seperator + "" + seperator);
                                    }
                                    else if (type.Equals("number", StringComparison.OrdinalIgnoreCase))
                                    {
                                        sbData.Append("");
                                    }

                                    sbData.Append(",");
                                }
                            }
                            data = sbData.ToString();
                            if (data.LastIndexOf(",") > -1)
                            {
                                data = data.Substring(0, data.Length - 1);
                            }
                            sbData.Clear();

                            dataList.Add(data);
                        }
                    }

                    string Template = @"INSERT INTO @TABLENAME (@COLUMNNAME) VALUES (@VALUEDATA);";
                    Template = Template.Replace("@TABLENAME", Table_Name).Replace("@COLUMNNAME", columnName);
                    StringBuilder sbScripts = new System.Text.StringBuilder();
                    foreach (string s in dataList)
                    {
                        string item = s;
                        item = s.Replace(seperator, "'");
                        string stemplate = Template.Replace("@VALUEDATA", item);
                        sbScripts.AppendLine(stemplate);
                    }
                    new FileOperation().WriteFile(Path.GetFileName(path), sbScripts.ToString());
                
                    sheet = null;
                    workbook = null;
                }
                return string.Empty;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
