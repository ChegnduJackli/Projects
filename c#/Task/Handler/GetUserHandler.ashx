<%@ WebHandler Language="C#" Class="GetUserHandler" %>

using System;
using System.Web;

public class GetUserHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        try
        {
            string userName = context.Request.QueryString["userName"];
            string password = context.Request.QueryString["password"];
            string status = "0";
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
               status="0";
            }
            else
            {
                UserDAL u = new UserDAL();
                if (u.Login(userName, password))
                {
                    status = "1";
                    context.Session["User"] = userName;
                }
            }
            context.Response.Write(status);
        }
        catch
        {
            context.Response.Write("0");
        }
        HttpContext.Current.ApplicationInstance.CompleteRequest();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}