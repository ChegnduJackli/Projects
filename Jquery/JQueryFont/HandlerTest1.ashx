<%@ WebHandler Language="C#" Class="HandlerTest1" %>

using System;
using System.Web;

public class HandlerTest1 : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
       // context.Response.ContentType = "text/plain";
     //for get ,use QuerySting,
        string name =context.Request.QueryString["name"];
        
        //for Post,use Form
      //  string name = context.Request.Form["name"];
        //params
        string params1 =context.Request.QueryString["params"];
     
        context.Response.Write("true");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}