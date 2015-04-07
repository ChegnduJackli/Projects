using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";
        if (Request.Cookies["UserName"] != null)
        {
            Session["User"] = Request.Cookies["UserName"].Value;
        }
        // Check for your SessionID
        if (Session["User"] != null)
        {
            lblUser.Text = Session["User"].ToString();
			UserDAL.LoginUserID = Session["User"].ToString();
            this.linkLogin.Text = "[Log Out]";
        }
        else
        {
		    Session["User"]=null;
            lblUser.Text = "Master";
            this.linkLogin.Text = "[Log In]";
            UserDAL.LoginUserID = "";
        }

    }
    protected void linkLogin_Click(object sender, EventArgs e)
    {
        if (this.linkLogin.Text == "[Log In]")
        {
            Response.Redirect("UserLogin.aspx", true);
        }
        else
        {
            if (Session["User"] != null)
            {
                RemoveCookie();
                Session["User"] = null;
                this.linkLogin.Text = "[Log In]";
                lblUser.Text = "Master";
                UserDAL.LoginUserID = "";
                Response.Redirect("Default.aspx",true);
            }
        }
    }
    private void RemoveCookie()
    {
        if (Request.Cookies["UserName"] != null)
        {
            HttpCookie myCookie = new HttpCookie("UserName");
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookie);
        }
    }
}
