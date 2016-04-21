using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Log
{
    public class LogHelper
    {

        //static string _FileName = string.Empty;

        //static LogHelper()
        //{
        //    string LogFileExit = ".log";
        //    string RootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Logs");
        //    if (!Directory.Exists(RootPath))
        //    {
        //        Directory.CreateDirectory(RootPath);
        //    }

        //    string FileName = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo) + LogFileExit;
        //    _FileName = Path.Combine(RootPath, FileName);
        //    if (!File.Exists(_FileName))
        //    {
        //        File.Create(_FileName).Close();
        //    }
        //}

        //public static string GetLogFileName()
        //{
        //    return _FileName;
        //}

        private static string CreateFile(string filePath = "", bool hasError = false)
        {
            string fileName = string.Empty;
            string _FileName = string.Empty;

            string RootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Logs");
            if (!string.IsNullOrEmpty(filePath))
            {
                RootPath = filePath;
            }

            if (!Directory.Exists(RootPath))
            {
                Directory.CreateDirectory(RootPath);
            }

            if (hasError)
            {
                fileName = GetErrorFileName();
            }
            else
            {
                fileName = GetInfoFileName();
            }

            _FileName = Path.Combine(RootPath, fileName);

            if (!File.Exists(_FileName))
            {
                File.Create(_FileName).Close();
            }

            return _FileName;
        }


        private static string GetFileName()
        {
            string LogFileExit = ".log";
            string FileName = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo) + LogFileExit;
            return FileName;
        }

        private static string GetErrorFileName()
        {
            return "Error_" + GetFileName();
        }

        private static string GetInfoFileName()
        {
            return "Info_" + GetFileName();
        }

        public static void LogInfo(string logDir, object obj)
        {
            WriteLog(logDir, obj, false);
        }

        public static void LogError(string logDir, object obj)
        {
            WriteLog(logDir, obj, true);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void WriteLog(string logDir, object obj, bool hasError = false)
        {
            try
            {
                string _FileName = CreateFile(logDir, hasError);

                using (FileStream fs = new FileStream(_FileName, FileMode.Append))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(DateTimeFormat.LongTimeFormat + ":" + obj);
                        sw.Flush();
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
