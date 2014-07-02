using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace CallCMD
{
    

    public class Browsers
    {
        //this one config in txt file better
        public static readonly string Chrome = "Chrome";
        public static readonly string FireFox = "FireFox";
        public static readonly string IE = "IE";

        public static readonly string ChromePath = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
        public static readonly string FireFoxPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
        public static readonly string IEPath = @"C:\Program Files\Internet Explorer\iexplore.exe";
        
        public static List<string> GetBrowserList()
        {
            List<string> BrowserList = new List<string>();
            BrowserList.Add(Chrome);
            BrowserList.Add(FireFox);
            BrowserList.Add(IE);
            return BrowserList;
        }

    }
}
