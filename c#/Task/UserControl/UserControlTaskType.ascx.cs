using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_UserControlTaskType : System.Web.UI.UserControl
{
    public string TypeName { get { return this.ddlStatus.SelectedItem.Text; } }
    public string TypeID { get { return this.ddlStatus.SelectedValue; } }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ddlStatus.Items.Clear();
            this.ddlStatus.DataSource = TaskType.GetAllTaskType();
            this.ddlStatus.DataTextField = "TypeName";
            this.ddlStatus.DataValueField = "ID";
            this.ddlStatus.DataBind();
        }
    }
 
}