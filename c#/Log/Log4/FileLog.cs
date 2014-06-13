using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log4
{
    public class FileLog : ILog
    {
        public enum LogLevel
        {
            Normal = 1,
            Important = 2,
            Error = 3
        };
        public LogLevel LogLevels = LogLevel.Normal;

        //FileDAL _fileDAL;
        //public FileLog()
        //{
        //    if (_fileDAL == null)
        //    {
        //        _fileDAL = new FileDAL();
        //    }
        //}
    
        public void WriteLog(string message)
        {
            FileDAL fileDAL = new FileDAL(LogLevel.Normal);
            fileDAL.Write(message);
        }

        public void ErrorLog(string message)
        {
           FileDAL fileDAL = new FileDAL(LogLevel.Error);
           fileDAL.Write(message);
        }
    }
}
