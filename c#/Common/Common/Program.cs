using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringExtension;

namespace Common
{
    class Program
    {
        static void Main(string[] args)
        {
            //string fileName = @"D:\text.txt";
            //for (int i = 0; i < 100; i++)
            //{
            //    FileUtil.FileDAL.WriteToFile(fileName, "good1 job "+i, false);
            //    FileUtil.FileDAL.WriteToFile(fileName, "bad job" + i, false);
            //}
            //FileUtil.FileDAL.DeleteFile(fileName);
            //clear all file or sub folder ins test dir.
            FileUtil.FileDAL.DeleteFolder(@"D:\test");

            string input="I am  jack";
            string s = MD5Helper.MD5Helper.EncriptMD5(input);
            Console.WriteLine(s);
            input = "I am  jack";
             s = MD5Helper.MD5Helper.EncriptMD5(input);
            Console.WriteLine(s);

            Console.WriteLine("convert type use");
            string s1 = "";
            int i1 = ConvertType.ConvertToType.To<int>(s1);
            Console.WriteLine(i1);
            string s2 = "2010-01-01";
            DateTime dt1 = ConvertType.ConvertToType.To<DateTime>(s2);
            Console.WriteLine("datetime is:{0}", dt1);

            string s3 = null;
            Console.WriteLine(s3.IsNullOrEmpty());
            Console.ReadLine();
        }
    }
}
