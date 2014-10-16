using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenereateTableDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
             
                /*//this one can also work
                Context context = new Context();
                context.AddObject(new GenerateTable());
                context.AddObject(new GenerateIndex());
                context.AddObject(new GenerateTrigger());
                context.AddObject(new GenerateView());
                context.AddObject(new GenerateSP());
                context.AddObject(new GenerateFunction());
                context.AddObject(new GenerateSequence());
                context.GenerateExcel();*/

                IGenerateExcel dal;
                show("We are trying to generate excel file,Please hold on......");

                show("Generate table dictionary list,Please hold on......");
                dal = new GenerateTable();
                dal.GenerateExcel();

                show("Generate table index list,Please hold on......");
                dal = new GenerateIndex();
                dal.GenerateExcel();

                show("Generate table trigger list,Please hold on......");
                dal = new GenerateTrigger();
                dal.GenerateExcel();

                show("Generate table view list,Please hold on......");
                dal = new GenerateView();
                dal.GenerateExcel();

                show("Generate store procedure list,Please hold on......");
                dal = new GenerateSP();
                dal.GenerateExcel();

                show("Generate function list,Please hold on......");
                dal = new GenerateFunction();
                dal.GenerateExcel();

                show("Generate sequence list,Please hold on......");
                dal = new GenerateSequence();
                dal.GenerateExcel();

                show("Generate table data count,Please hold on......");
                dal = new GenerateTableDataCount();
                dal.GenerateExcel();

                Console.WriteLine("Finish all,thanks......");
                System.Threading.Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                FileHelper.WriteLog(ex);
            }
        }
        static void show(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine();
        }
    }
}
