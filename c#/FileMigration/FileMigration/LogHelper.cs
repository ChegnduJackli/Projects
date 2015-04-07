using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace FileMigration
{
    class LogHelper
    {
        static string _FileName = string.Empty;

        static LogHelper()
        {
            string LogFileExit = ".log";
            string RootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Logs");
            if (!Directory.Exists(RootPath))
            {
                Directory.CreateDirectory(RootPath);
            }

            string FileName = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo) + LogFileExit;
            _FileName = Path.Combine(RootPath, FileName);
            if (!File.Exists(_FileName))
            {
                File.Create(_FileName).Close();
            }
        }

        public static string GetLogFileName()
        {
            return _FileName;
        }

        public static void WriteLog(object obj)
        {
            try
            {
                using (FileStream fs = new FileStream(_FileName, FileMode.Append))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(DateTimeFormat.LongTimeFormat + ":" + obj);
                        sw.Close();
                    }
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        class DateTimeFormat
        {
            internal static string LongTimeFormat
            {
                get
                {
                    return "[" + DateTime.Now.ToString("G") + "]";
                }
            }
        }

    }
}
