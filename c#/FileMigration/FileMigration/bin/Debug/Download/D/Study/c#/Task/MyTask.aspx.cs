using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MyTask : System.Web.UI.Page
{
    TaskDAL taskDal = new TaskDAL();

    string userID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null)
        {
            Response.Redirect("UserLogin.aspx", true);
        }
        else
        {
            userID = Session["User"].ToString();
        }
        if (!IsPostBack)
        {
            BindData();
        }
    }
    private void BindData()
    {
        try
        {
            DataSet ds = null;
            if (ViewState["ds"] == null)
            {
                ds = GetTask();
            }
            else
            {
                ds = (DataSet)ViewState["ds"];
            }
            string strSortBy = "ID DESC";
            if (ViewState["SortExp"] != null)
            {
                strSortBy = ViewState["SortExp"].ToString() + " " + ViewState["SortOrder"].ToString(); ;
            }

            DataView dv = ds.Tables[0].DefaultView;
            dv.Sort = strSortBy;
            AspNetPager1.RecordCount = dv.Count;

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dv;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;
            Repeater1.DataSource = pds;
            Repeater1.DataBind();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
    }
    private DataSet GetTask()
    {
        return taskDal.GetTaskByUserID(userID);
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string typeID = this.ddlTaskType.TypeID;

        try
        {
            DataSet ds = taskDal.GetTaskByStatus(userID, typeID);
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
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                if (e.CommandName.Equals("Sort"))
                {
                    if (this.ViewState["SortExp"] == null)
                    {
                        this.ViewState["SortExp"] = e.CommandArgument.ToString();
                        this.ViewState["SortOrder"] = "ASC";
                    }
                    else
                    {
                        if (this.ViewState["SortExp"].ToString() == e.CommandArgument.ToString())
                        {
                            if (this.ViewState["SortOrder"].ToString() == "ASC")
                                this.ViewState["SortOrder"] = "DESC";
                            else
                                this.ViewState["SortOrder"] = "ASC";
                        }
                        else
                        {
                            this.ViewState["SortOrder"] = "ASC";
                            this.ViewState["SortExp"] = e.CommandArgument.ToString();
                        }
                    }
                }
            }
            if (e.Item.ItemType == ListItemType.Item)
            {
                if (e.CommandName.Equals("Delete"))
                {
                    int taskID = Convert.ToInt32(e.CommandArgument.ToString());
                    if (taskDal.DeleteTask(Convert.ToInt32(taskID)))
                    {
                        MessageBox.Show(this, "delete task successfully.");
                        //Response.Redirect("Default.aspx");
                    }
                }
            }
            BindData();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this,ex.Message);
        }
    }
}