using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace GenerateScript
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generating script,Please hold on........");
            try
            {

                FileOpers fileOper = new FileOpers();
                Context menu = new Context();

                menu.SetStrategy();

                List<string> files = fileOper.GetFiles();
                if (files.Count == 0)
                {
                    Console.WriteLine("No file");
                }
                else
                {
                    foreach (string file in files)
                    {
                        FileInfo fileinfo = new FileInfo(file);
                        menu.GenereateScript(fileinfo.Name);
                        Console.WriteLine("Generate script successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            /*
            Console.WriteLine("Generating script,Please hold on........");
            FileOpers fileOper = new FileOpers();
            TableOper to = new TableOper();
            WorkbookOper work = new WorkbookOper();
            try
            {
                List<string> files = fileOper.GetFiles();
                foreach (string file in files)
                {
                    FileInfo fileinfo = new FileInfo(file);
                    
                    string fileName = fileinfo.Name;
                    // DataTable dt = WorkbookOper.exceldata(fileName);
                    DataSet ds = work.Parse(fileName);
                    if (ds == null)
                    {
                        throw new ApplicationException("File is locked");
                    }
                    string scripts = to.PopulateScript(ds.Tables[0]);
                    fileOper.WriteFile(fileName, scripts);
                    Console.WriteLine("Generate script successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
             * */
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
