using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Handler_LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string userName = Request.QueryString["userName"];
            string password = Request.QueryString["password"];
            string status = "0";
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                status = "0";
            }
            else
            {
                UserDAL u = new UserDAL();
                if (u.Login(userName, password))
                {
                    status = "1";
                    Session["User"] = userName;
                }
            }
            Response.Write(status);
        }
        catch
        {
            Response.Write("0");
        }
        HttpContext.Current.ApplicationInstance.CompleteRequest();
    }
}