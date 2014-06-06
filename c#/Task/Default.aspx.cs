using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    TaskDAL taskDal = new TaskDAL();
    string userID = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["User"] != null)
            {
                userID = Session["User"].ToString();
            }

            if (!IsPostBack)
            {
                BindData();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
    }


    private void BindData()
    {
        DataSet ds = null;
        if (ViewState["ds"] == null)
        {
            ds = taskDal.GetAllTask();
        }
        else
        {
            ds = (DataSet)ViewState["ds"];
        }
        // ds = taskDal.GetAllTask();
        DataView dv = ds.Tables[0].DefaultView;
        AspNetPager1.RecordCount = dv.Count;

        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = dv;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        Repeater1.DataSource = pds;
        Repeater1.DataBind();
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            Label lblUser = e.Item.FindControl("lblUser") as Label;
            if (!IsCurrentUser(lblUser.Text))
            {
                return;//no access
            }

            if (e.CommandName == "Confirm")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                DropDownList myDDL = (DropDownList)e.Item.FindControl("ddlTaskStatus");
                string status = myDDL.SelectedItem.Text;
                if (status == "--Please select status--")
                {
                    MessageBox.Show(this, "Please select status");
                    return;
                }

            }

            if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                taskDal.DeleteTask(id);
            }
            BindData();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string taskValue = ddlTaskType.TypeID;

        string processingValue = ddlProcessType.ProcessingID;

        //if (!((taskValue == "1") && processingValue != "0"))
        //{
        //    MessageBox.Show(this, "Only Type is Task has processing type.");
        //    return;
        //}

        try
        {
            DataSet ds = taskDal.GetTaskByCondition(taskValue, processingValue);
            ViewState["ds"] = ds;
            BindData();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
    }
    protected void AspNetPager1_PageChanged(object sender, System.EventArgs e)
    {       //页索引改变方法 
        BindData();
    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblType = e.Item.FindControl("lblType") as Label;
            if (lblType != null)
            {
                if (!lblType.Text.Equals("Task", StringComparison.OrdinalIgnoreCase))
                {
                    Label lblStatus = e.Item.FindControl("lblStatus") as Label;
                    Label lblProcessStatus = e.Item.FindControl("lblProcessStatus") as Label;
                    lblStatus.Visible = false;
                    lblProcessStatus.Visible = false;
                }
            }
          
        }
    // lblUser
    }
    private bool IsCurrentUser(string taskUser)
    {
        return new UserDAL().IsCurrentUser(taskUser);
    }
}
