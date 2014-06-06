using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_UserControlProcessType : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ddlStatus.Items.Clear();
            this.ddlStatus.DataSource = ProcessType.GetAllProcessType();
            this.ddlStatus.DataTextField = "ProcessTypeName";
            this.ddlStatus.DataValueField = "ID";
            this.ddlStatus.DataBind();
        }
    }
    public string ProcessingName
    {
        get
        {
            return this.ddlStatus.SelectedItem.Text;
        }

    }
    public string ProcessingID { get { return this.ddlStatus.SelectedValue; } }
    public ListItemCollection Items { get { return this.ddlStatus.Items; } }
   

}