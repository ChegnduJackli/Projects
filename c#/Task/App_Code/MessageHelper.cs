using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

public class MessageBox
{
    const string javaScriptHead = "<script type='text/javascript' defer>";
    const string javaScriptFoot = "</script>";

    public static void Show(Page page, string message)
    {
        Type pageType = page.GetType();
        page.ClientScript.RegisterStartupScript(pageType, pageType.Name, javaScriptHead + "alert('" + message.Replace("'", " ") + "')" + javaScriptFoot);
    }

    public static void Show(Page page, string key, string message)
    {
        Type pageType = page.GetType();
        page.ClientScript.RegisterStartupScript(pageType, key, javaScriptHead + "alert('" + message.Replace("'", " ") + "')" + javaScriptFoot);
    }
}