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
                        Console.WriteLine("File {0} Generate script successfully.", fileinfo.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Waiting 5 seconds will auto exit...");
            System.Threading.Thread.Sleep(5000);
        }
    }
}
