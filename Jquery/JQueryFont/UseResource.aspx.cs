using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UseResource : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label1.Text = GetUser();
        }
    }
    private string GetUser()
    {
        string key ="MaxNum";
        string message = string.Empty;
        message =Resources.Resource.ResourceManager.GetString(key);
        message = string.Format(message, 3);
       // message = Resources.Resource.UserName;
       return message;
       Page.ClientScript.RegisterStartupScript(this.GetType(), "clientscript", "document.getElementById('G2').style.visibility = 'visible';", true);
    }
}