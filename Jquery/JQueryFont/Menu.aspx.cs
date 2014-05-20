using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindData();
        }

    }
    private void bindData()
    {
        List<string> ddlData = new List<string>();
        for (int i = 100; i < 500; i++)
        {
            ddlData.Add("00"+i.ToString());
        }
        DropDownList1.DataSource = ddlData;
        DropDownList1.DataBind();
    }
}