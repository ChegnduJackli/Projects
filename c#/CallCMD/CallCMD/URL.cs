using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace CallCMD
{
    public class URL
    {
        //this is not recommended
        public static readonly string VendorGovRunScript = "http://app-stg.intranet.agd.gov.sg/runscript.aspx";
        public static readonly string VendorGovIndex = @"http://app-stg.vendors.gov.sg/index.aspx";
        public static readonly string ReqSys = @"http://app.reqsys.agd.gov.sg/Logon.aspx";
        public static readonly string PacPath = @"http://pacgov.agd.gov.sg/agd_oss/Dashboard.aspx";
        public static readonly string NcsService = @"https://ncsserviceconnect.com.sg/sc/shine.do";
        public static readonly string Mailer = @"http://intranet-stg.mailer.agd.gov.sg/agd-cms/home.do";



        public static List<string> GetURLList()
        {
            List<string> urlList = new List<string>();
            urlList.Add(VendorGovIndex);
            urlList.Add(VendorGovRunScript);
            urlList.Add(ReqSys);
            urlList.Add(PacPath);
            urlList.Add(NcsService);
            urlList.Add(Mailer);
            return urlList;
        }
    }

    public class Browsers
    {
        //this one config in txt file better
        public static readonly string Chrome = "Chrome";
        public static readonly string FireFox = "FireFox";
        public static readonly string IE = "IE";

        public static readonly string ChromePath = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
        public static readonly string FireFoxPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
        public static readonly string IEPath = @"C:\Program Files\Internet Explorer\iexplore.exe";

        public static List<BrowserInfo> GetBrowserList()
        {
            return new List<BrowserInfo> {
                new BrowserInfo {BrowserName=Chrome,BrowserPath=ChromePath},
                new BrowserInfo{BrowserName=FireFox,BrowserPath=FireFoxPath},
                new BrowserInfo{BrowserName=IE,BrowserPath=IEPath}
            };
        }
    }
    public class BrowserInfo
    {
        public string BrowserName { get; set; }
        public string BrowserPath { get; set; }
    }
}
