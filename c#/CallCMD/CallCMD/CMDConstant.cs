using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;

namespace CallCMD
{
    public class CMDConstant
    {
        public static readonly string CmdPath = ConfigurationManager.AppSettings["CMDPath"];
        public static readonly string ProxyEnable = "OpenProxy.cmd";
        public static readonly string ProxyDisable = "disableProxy.cmd";
        public static readonly string ShutdownPC = "Shutdown.cmd";
        public static readonly string RestartPC = "Restart.cmd";
        public static readonly string CancelShutDownPC = "Cancel_Shutdown.cmd";

        public static string GetCMDPath(string cmdFile)
        {
            try
            {
                string filePath = Path.Combine(CmdPath, cmdFile);
                if (!File.Exists(filePath))
                {
                    throw new ApplicationException("File cannot be found!");
                }
                return filePath;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
