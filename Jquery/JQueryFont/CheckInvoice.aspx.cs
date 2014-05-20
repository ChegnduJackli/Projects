using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CheckInvoice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.chkDirectInvoice.Attributes.Add("onclick", "javascript:checkDirectInvoices();");
    }
}