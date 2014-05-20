using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.Services;

public partial class Ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //lblBatchInvoiceScript.Text = GetScript();
        if (!IsPostBack)
        {
            string model = Request.QueryString["Model"];
            if (model == "LoadData")
            {
                string strResponseReturn = GetData();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.AddHeader("Cache-Control", "no-cache");
                Response.ContentType = "text/xml";
                Response.Write(strResponseReturn);
                Response.Flush();
                Response.End();
            }
        }
      //  GetData();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        lblBatchInvoiceScript.Text = GetScript();
    }
 //[WebMethod]
 //   public static string GetData()
 //   {
 //       return "Y";
 //   }
    private string GetData()
    {
        return "Y";
    }
    private string GetScript()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type='text/javascript' language='javascript'>");

        sb.Append("var req;");
        sb.Append("function SendRequest()");
        sb.Append("{");
        sb.Append("if(navigator.appName == 'Microsoft Internet Explorer')");
        sb.Append("req = new ActiveXObject('Microsoft.XMLHTTP');");
        sb.Append("else");
        sb.Append(" req = new XMLHttpRequest();");
        sb.Append("var url = 'Ajax.aspx?Model=LoadData';");
       // sb.Append("var url = 'Handler.ashx';");
        sb.Append("req.onreadystatechange = function()");
        sb.Append("{");
        sb.Append("if(req.readyState == 4 && req.status == 200)");
        sb.Append("{");
        sb.Append("if(req.responseText == 'Y')");
        sb.Append("{");
        sb.Append("stopTimer();");
        sb.Append("window.location.href = 'Default.aspx';");
        sb.Append("}");
        sb.Append("}");
        sb.Append("};");


        sb.Append("req.open('Post', url, true);");
        sb.Append("req.send(null);");
        sb.Append("}");


        sb.Append("var timer = '';");
        sb.Append("function startTimer()");
        sb.Append("{");
        sb.Append("timer = window.setInterval('SendRequest()', 5000);");
        sb.Append("}");

        sb.Append("function stopTimer()");
        sb.Append("{");
        sb.Append("window.clearInterval(timer);");
        sb.Append("timer = '';");
        sb.Append("}");

        sb.Append("window.onload = function(){BlockPageEdit();startTimer();};");
        sb.Append("function BlockPageEdit(){");
        sb.Append("var newdiv = document.createElement('div');");
        sb.Append("var divIdName = 'myBlockingDiv';");
        sb.Append("newdiv.setAttribute('id',divIdName);");
        sb.Append("newdiv.setAttribute('z-index',2000);");

        sb.Append("newdiv.innerHTML = '<br/>&nbsp;&nbsp;&nbsp;&nbsp;Retrieve data... Please wait...&nbsp; <img src = \"Images/loading.gif\"/>';");
        sb.Append("document.body.appendChild(newdiv);");
        sb.Append("}");
        sb.Append("</script>");

        return sb.ToString();
    }
}