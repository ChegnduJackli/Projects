using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileConfiguration
{
    class Common
    {
        public static readonly string ROOT_BIN_PATH = AppDomain.CurrentDomain.BaseDirectory;
        public static readonly string CONFIG_FILE_PATH = System.IO.Path.Combine(ROOT_BIN_PATH, "FileMigration","config.txt");
        public static readonly string APP_CONFIG_PATH = System.IO.Path.Combine(ROOT_BIN_PATH, "FileMigration", "FileMigration.exe.config");

        public static readonly string DATA_SYSTEM_HELPDESK = System.IO.Path.Combine(ROOT_BIN_PATH, "Data", "Result_Helpdesk.txt");
        public static readonly string DATA_SYSTEM_OSS = System.IO.Path.Combine(ROOT_BIN_PATH, "Data", "Result_OSS.txt");
        public static readonly string DATA_SYSTEM_AGD = System.IO.Path.Combine(ROOT_BIN_PATH, "Data", "Result_AGD.txt");

    }
}
