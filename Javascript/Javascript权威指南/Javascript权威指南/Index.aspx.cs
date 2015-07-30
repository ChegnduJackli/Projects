using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Javascript权威指南
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            DateTime dt = currentTime.AddMinutes(-3);
            Label1.Text = currentTime.ToString();
            Label2.Text = dt.ToString();
        }
    }
}