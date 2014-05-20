<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;

public class Handler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        System.Threading.Thread.Sleep(2000);
        context.Response.Write("Y");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}