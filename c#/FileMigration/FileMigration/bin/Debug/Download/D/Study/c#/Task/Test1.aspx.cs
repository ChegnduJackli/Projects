using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<string> email = new List<string>();
        email.Add("lideng@ncs.com.sg");
        //EmailHelper.SendEmail(email,"edd");
    }
}