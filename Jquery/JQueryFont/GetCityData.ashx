<%@ WebHandler Language="C#" Class="GetCityData" %>

using System;
using System.Web;
using System.Collections.Generic;
public class GetCityData : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Write("Hello World");

        string strPar = null;
        try
        {
            //获取URL中的参数
            strPar = context.Request.QueryString[0];
        }
        catch
        {
            //若出现异常向客户端响应一个空的输出并终止该方法
            context.Response.Write("");
            return;
        }

        List<string> dataList = GetData(strPar);
        //创建一个可变长度的字符串
        System.Text.StringBuilder sbCityData = new System.Text.StringBuilder();

        foreach (string s in dataList)
        {
            sbCityData.Append("<p>(" + s + ") </p>"); 
        }
        //响应客户端输出
        context.Response.Write(sbCityData.ToString());
        
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

    private List<string> GetData(string par)
    {
        List<string> dataList = new List<string>();
        dataList.Add("tiananmen");
        dataList.Add("tiananme1");
        dataList.Add("tiananme2");
        dataList.Add("tiananme3");
        dataList.Add("tiananme4");
        dataList.Add("tiananme5");
        dataList.Add("eiananme6");
        dataList.Add("diananme6");
        dataList.Add("diananme6");

        return dataList;
    }

}