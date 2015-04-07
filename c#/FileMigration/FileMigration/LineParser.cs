using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileMigration
{
    public class LineParser
    {
        /// <summary>
        /// parse file line
        /// </summary>
        /// <param name="logLine"></param>
        /// <returns></returns>
        public LineInfo ParseLine(string logLine)
        {
            LineInfo logLineInfo=null;
            string separator = "==";

            if (!logLine.StartsWith("#") && logLine.StartsWith("@") && logLine.IndexOf(separator) > 0 )
            {
                string[] splitLogLine = logLine.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);

                if (splitLogLine[0].Trim().Equals(Common.Indicator_Upload_Flag, StringComparison.OrdinalIgnoreCase))
                {
                    logLineInfo = new LineInfo
                    {
                        Indicator = splitLogLine[0].Trim(),
                        LocalFile = splitLogLine[1].Trim(),
                        PRDFile = splitLogLine[2].Trim(),
                        BackUpFile = splitLogLine[3].Trim()
                    };
                }
               //for download
                else if (splitLogLine[0].Trim().Equals(Common.Indicator_Download_Flag, StringComparison.OrdinalIgnoreCase))
                {
                    logLineInfo = new LineInfo
                   {
                       Indicator = splitLogLine[0].Trim(),
                       PRDFile = splitLogLine[1].Trim(),
                   };
                }
            }
            else
            {
                logLineInfo = null;
            }

            return logLineInfo;
        }
    }
}
