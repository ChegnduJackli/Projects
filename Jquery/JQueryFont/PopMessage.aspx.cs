using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Caching;

public partial class PopMessage : System.Web.UI.Page
{
    Constant cs = new Constant();
    Constant.DateType dateType;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Button3.Attributes.Add("onclick", "javascript:popup();");
        this.Label1.Text = "";
    }
    protected void btnPopup_Click(object sender, EventArgs e)
    {
        string scriptText = @"<script>if(!confirm('sure to do this?')) {window.location.href='Default.aspx'};</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "ConfirmationForOverwrite", scriptText);//to do
        return;
     //   Page.ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>if(!confirm('Please confirm your phone number is correct:  Do you want to continue?'))return false;</script>");

        this.Label1.Text = "fdfddf";
     }
    protected void Button3_Click(object sender, EventArgs e)
    {
        dateType = Constant.DateType.Int32Type;
        
    }
}