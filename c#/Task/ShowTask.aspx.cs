using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ShowTask : System.Web.UI.Page
{
    string postID = string.Empty;
    TaskDAL taskDal = new TaskDAL();
    Comment comDAL = new Comment();
    string userID = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] != null)
        {
            userID = Session["User"].ToString();
        }
        //else
        //{
        //    Response.Redirect("Login.aspx", true);
        //}

        if (!IsPostBack)
        {
            FillControl();
            BindComment();

            InitBindControl();
        }
    }
    private void BindComment()
    {
        postID = Request.QueryString["TaskID"];
        DataTable dt = comDAL.GetCommentByTaskID(Convert.ToInt32(postID));
        //this.Repeater1.DataSource = dt;
       // this.Repeater1.DataBind();
    }

    private void FillControl()
    {
        postID = Request.QueryString["TaskID"];
        if (string.IsNullOrEmpty(postID))
        {
            Response.Redirect("default.aspx", true);
        }
        try
        {
            DataTable dt = taskDal.GetTaskByID(Convert.ToInt32(postID));
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                this.lblTitle.Text = row["Title"].ToString();
                this.lblContent.Text = row["Content"].ToString();
                this.lblCreateTime.Text = row["CreateTime"] == DBNull.Value ? "" : row["CreateTime"].ToString();
                this.lblComTime.Text = row["CompleteTime"] == DBNull.Value ? "" : row["CompleteTime"].ToString();
                hidTaskUser.Value = row["userid"] == DBNull.Value ? "" : row["userid"].ToString();
                string status = row["status"].ToString();
                string typeID = hidTypeID.Value = row["TypeID"] == DBNull.Value ? "0" : row["TypeID"].ToString();
                string processID = row["ProcessID"].ToString();
                lblStatus.Text = status;
                hidID.Value = postID;
                // ddlProcessType.ProcessingID = status;
                lblAuthor.Text = hidTaskUser.Value;
                if (this.lblComTime.Text.Length == 0)
                {
                    //this.lblComTime.Text = "not completed";
                }
                string attachment = row["FileName"] == DBNull.Value ? "" : row["FileName"].ToString();
                if (attachment.Length > 0)
                {
                    this.linkAttachment.Text = attachment;
                }
                TaskType t = new TaskType(typeID);
                if (t.TaskStatus != TaskType.Task.Task)
                {
                    this.lblStatusMessage.Visible = false;
                    this.lblStatus.Visible = false;
                    this.lblComTime.Visible = false;
                    lblCompleteTime.Visible = false;
                }

                foreach (ListItem il in this.ddlProcessType.Items)
                {
                    if (il.Value == processID)
                    {
                        il.Selected = true;
                        break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this,ex.Message);
        }
    }
    private void InitBindControl()
    {
        if (!IsCurrentUser(this.hidTaskUser.Value) || hidTypeID.Value !="1") //not a task
        {
            this.Panel1.Visible = false;
        }
        else
        {
            this.Panel1.Visible = true;
        }
    }
    protected void linkEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("TaskDetails.aspx?TaskID=" + hidID.Value,true);
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                DataTable dt = comDAL.GetCommetByid(id);
                if (dt.Rows.Count > 0)
                {
                    string userId = dt.Rows[0]["userid"] == DBNull.Value ? "" : dt.Rows[0]["userId"].ToString();
                    if (IsCurrentUser(userId))
                    {
                        comDAL.DeleteComment(id);
                        BindComment();
                    }
                    else
                    {
                        //no access
                    }
                }
            }
            
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
    }
    //delete task
    protected void linkDel_Click(object sender, EventArgs e)
    {
        try
        {
            if (!IsCurrentUser(this.hidTaskUser.Value))
            {
                return;//no access
            }
            postID = Request.QueryString["TaskID"];
            if (taskDal.DeleteTask(Convert.ToInt32(postID)))
            {
                MessageBox.Show(this, "delete successfully.");
                Response.Redirect("Default.aspx");
            }
            
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
    }
    //change status
    protected void linkConfirm_Click(object sender, EventArgs e)
    {
        try
        {
            if (!IsCurrentUser(this.hidTaskUser.Value))
            {
                return;//no access
            }

            postID = Request.QueryString["TaskID"];
            int id = Convert.ToInt32(postID);
            string status = ddlProcessType.ProcessingName;
            string processValue = ddlProcessType.ProcessingID;
            if (processValue == "0")
            {
                MessageBox.Show(this, "Please select process status");
                return;
            }
            if (taskDal.UpdateStatus(id, status))
            {
                string mesg = string.Format("Update status to {0} successfully.", status);
                MessageBox.Show(this, mesg);
            }
            FillControl();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this,ex.Message);
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Session["User"] == null)
        {
            MessageBox.Show(this, "Please log in first.");
            return;
        }
        try
        {
            string userid = Session["User"].ToString();

            string content = this.txtComment.Text.Trim();
            postID = Request.QueryString["TaskID"];
            int taskID = Convert.ToInt32(postID);
            if (content.Length == 0)
            {
                MessageBox.Show(this,"Comment cannot be empty");
                return;
            }
            if (comDAL.AddComment(taskID, content, userid))
            {
                //MessageBox.Show(this, "Add comment successfully");
                this.txtComment.Text = "";
            }
            BindComment();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
    }
    protected void linkAttachment_Click(object sender, EventArgs e)
    {
        try
        {
            postID = Request.QueryString["TaskID"];
            string fileName = taskDal.GetFileFullName(Convert.ToInt32(postID));
            if (!string.IsNullOrEmpty(fileName))
            {
                Server.Execute(string.Format("Common/DownloadFile.aspx?FilePath={0}", fileName));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblUser = e.Item.FindControl("lblUser") as Label;
            if (lblUser != null)
            {
                Panel panel = e.Item.FindControl("Panel1") as Panel;
                if (IsCurrentUser(lblUser.Text))
                {
                    panel.Visible = true;
                }
                else
                {
                    panel.Visible = false;
                }
            }
        }
    }
    private bool IsCurrentUser(string taskUser)
    {
        UserDAL u = new UserDAL();
        if ((taskUser ==userID) || u.IsAdmin(userID))
            return true;
        return false;
        //return new UserDAL().IsCurrentUser(taskUser) || new UserDAL().IsAdmin(userID);
    }
}