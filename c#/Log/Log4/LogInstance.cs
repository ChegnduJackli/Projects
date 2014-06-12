using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log4
{
    public class LogInstance
    {
        private static ILog _FileLogInstance;
        private static ILog _DatabaseLogInstance;
        private static object _lockFile = new object();
        private static object _lockData = new object();


        public static ILog FileLogInstance()
        {
            if (_FileLogInstance == null)
            {
                lock (_lockFile)
                {
                    if (_FileLogInstance == null)
                    {
                        _FileLogInstance = new FileLog();
                    }
                }
            }
            return _FileLogInstance;
        }

        public static ILog DatabaseLogInstance()
        {
            if (_DatabaseLogInstance == null)
            {
                lock (_lockData)
                {
                    if (_DatabaseLogInstance == null)
                    {
                        _DatabaseLogInstance = new DatabaseLog();
                    }
                }
            }
            return _DatabaseLogInstance;
        }
    }
}
