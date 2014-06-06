using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class TaskDetails : System.Web.UI.Page
{
    string postID = string.Empty;
    TaskDAL taskDal = new TaskDAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillControl();
        }
    }
    private void FillControl()
    {
        postID = Request.QueryString["TaskID"];
        DataTable dt = taskDal.GetTaskByID(Convert.ToInt32(postID));
        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            this.txtTitle.Text = row["Title"].ToString();
            this.txtDetails.Text = row["Content"].ToString();
            this.lblCreateTime.Text = row["CreateTime"] == DBNull.Value ? "" : row["CreateTime"].ToString();
            this.lblComTime.Text = row["CompleteTime"] == DBNull.Value ? "" : row["CompleteTime"].ToString();
            string status = row["status"].ToString();
            string processID = row["ProcessID"].ToString();
            string attachment = row["FileName"] == DBNull.Value ? "" : row["FileName"].ToString();
            if (attachment.Length > 0)
            {
                this.linkAttachment.Text = attachment;
                this.linDelete.Visible=true;
            }
            this.hidID.Value = row["ID"].ToString();

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
    protected void btnOK_Click(object sender, EventArgs e)
    {
        string id = this.hidID.Value;
        string status = this.ddlProcessType.ProcessingID;
        string content = this.txtDetails.Text;
        string title = this.txtTitle.Text;


        try
        {
            string msg = ValidateAttachment();
            if (msg.Length > 0)
            {
                MessageBox.Show(this, msg);
                return;
            }
            string fileFullPath = string.Empty;
            string fileName = string.Empty;
            bool hasAttachment = false;
            if (this.FileUpload1.HasFile && this.FileUpload1.PostedFile.ContentLength > 0)
            {
                fileName = System.IO.Path.GetFileName(this.FileUpload1.FileName).ToLower();

                string savePath = Server.MapPath("~/") + @"Atttachment\";
                if (!System.IO.Directory.Exists(savePath))
                {
                    System.IO.Directory.CreateDirectory(savePath);
                }
                fileFullPath = System.IO.Path.Combine(savePath, Common.GetFullName(fileName));
                FileUpload1.SaveAs(fileFullPath);
                hasAttachment = true;
            }
            if (!hasAttachment) //no upload attachment
            {
                if (this.linkAttachment.Text.Length > 0 && this.linkAttachment.Text != "No Attachment")
                {
                    postID = Request.QueryString["TaskID"];
                    DataTable dt = taskDal.GetTaskByID(Convert.ToInt32(postID));
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        fileFullPath = row["Attachment"] == DBNull.Value ? "" : row["Attachment"].ToString();
                        fileName = row["fileName"] == DBNull.Value ? "" : row["fileName"].ToString();
                    }
                }
            }

            TaskEntity tt = new TaskEntity();
            tt.ID = Convert.ToInt32(id);
            tt.Status = status;
            tt.Content = content;
            tt.Status = status;
            tt.Title = title;
            tt.Attachment = fileFullPath;
            tt.FileName = fileName;
            tt.ProcessID = status;
            if (taskDal.UpdateTask(tt))
            {
                MessageBox.Show(this, "update task successfully.");
                postID = Request.QueryString["TaskID"];
                Response.Redirect("ShowTask.aspx?TaskID=" + postID);
            }
         
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }


    }

    private string ValidateAttachment()
    {
        string message = string.Empty;
        try
        {
            if (this.FileUpload1.HasFile)
            {
                if (string.IsNullOrEmpty(this.FileUpload1.FileName))
                {
                    message = "File is empty.";
                }
            }
            return message;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string id = this.hidID.Value;
        try
        {
            int ID = Convert.ToInt32(id);
            if (taskDal.DeleteTask(ID))
            {
                MessageBox.Show(this, "Delete task successfully.");
            }
            Server.Execute("Default.aspx");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
    }
    //download file
    protected void linkAttachment_Click(object sender, EventArgs e)
    {
        try
        {
            string id = this.hidID.Value;
            string fileName = taskDal.GetFileFullName(Convert.ToInt32(id));
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
    //delete attachment
    protected void linDelete_Click(object sender, EventArgs e)
    {
        this.linkAttachment.Text = "";
        string id = this.hidID.Value;
        if (taskDal.DeleteAttachmentInDB(Convert.ToInt32(id)))
        {
            this.linDelete.Visible = false;
            MessageBox.Show(this, "Attachment deleted successfully");
        }
    }
}