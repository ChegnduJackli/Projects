using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserLogin : System.Web.UI.Page
{
    UserDAL user = new UserDAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["UserName"] != null)
            {
                Session["User"] = Request.Cookies["UserName"].Value;
                UserDAL.LoginUserID = Session["User"].ToString();
                Response.Redirect("Default.aspx");
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string name = this.txtUserName.Text.Trim();
        string pwd = this.txtPassword.Text.Trim();
        try
        {
            if (name.Length == 0 || pwd.Length == 0)
            {
                MessageBox.Show(this, "user name and password cannot be empty.");
                return;
            }
            if (user.Login(name, pwd))
            {
                Session["User"] = name;
                UserDAL.LoginUserID = name;
                if (this.chkRem.Checked)
                {
                    HttpCookie userid = new HttpCookie("UserName");
                    userid.Value = name;
                    userid.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Add(userid);
                }
                else
                {
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                }
                Response.Redirect("Default.aspx", true);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }

    }
}