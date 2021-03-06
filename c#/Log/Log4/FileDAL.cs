﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using System.Configuration;

namespace Log4
{
    internal class FileDAL
    {
        private string _LogRootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Logs");
        private static readonly string LogFileExit = ".log";
        private static readonly string CommonFolder = "Normal";
        private static readonly string ErrorFolder = "Error";

        private static object obj = new object();
        private string _fileName;
        private FileLog.LogLevel _LogLevel;

        public FileDAL(FileLog.LogLevel logLevel)
        {
            this._LogLevel = logLevel;
            this._fileName = GetFileName();
        }

        private string LogRootPath
        {
            get
            {
                string pathFromConfig = ConfigurationManager.AppSettings["LogPath"];
                if (!string.IsNullOrEmpty(pathFromConfig))
                    _LogRootPath = pathFromConfig;

                if (!_LogRootPath.EndsWith(Path.DirectorySeparatorChar.ToString())) //endwith "\\"
                {
                    _LogRootPath += Path.DirectorySeparatorChar;
                }

                return _LogRootPath;
            }
        }
        public void Write(Exception ex)
        {
            try
            {
                string filePath = this._fileName;
                lock (obj)
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Delete | FileShare.ReadWrite))
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.WriteLine(DateTimeFormat.LongTimeFormat + " : " + ex);
                            //sw.Flush();
                            sw.Close();
                            fs.Close();
                            sw.Dispose();
                            fs.Dispose();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Write(string message)
        {
            try
            {
                string filePath = this._fileName;
                lock (obj)
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Delete | FileShare.ReadWrite))
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.WriteLine(DateTimeFormat.LongTimeFormat + " : " + message);
                            //sw.Flush();
                            sw.Close();
                            fs.Close();
                            sw.Dispose();
                            fs.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string GetFileName()
        {
            string dirPath = LogRootPath;

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            String ym = DateTime.Now.ToString("yyyyMM", DateTimeFormatInfo.InvariantInfo);
            dirPath += ym + "/";

            String ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
            dirPath += ymd + "/";

            if (this._LogLevel == FileLog.LogLevel.Error)
            {
                dirPath += ErrorFolder + "/";
            }
            else
            {
                dirPath += CommonFolder + "/";
            }

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

    
            String newFileName = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo) + LogFileExit;
            String filePath = dirPath + newFileName;
            return filePath;
        }
    }
    class DateTimeFormat
    {
        internal static string LongTimeFormat
        {
            get
            {
                //DateTime now = DateTime.Now;
                //return now.ToShortDateString() +" "+ now.ToShortTimeString();
                return "[" + DateTime.Now.ToString("G") + "]";
            }
        }
    }
}
