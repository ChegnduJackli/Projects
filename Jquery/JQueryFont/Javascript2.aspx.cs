using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

public partial class Javascript2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static string RegUsers(string username, string name)
    {
        string response = username + name;

        return response;
    }
    public static string test()
    {
        return "good";
    }
}