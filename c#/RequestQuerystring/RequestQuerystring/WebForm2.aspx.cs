using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RequestQuerystring
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string item = Request.QueryString["item"];
            Label1.Text = "pass value:" + item;

            string value = Server.UrlDecode(item);
            Label2.Text = value;
        }
    }
}