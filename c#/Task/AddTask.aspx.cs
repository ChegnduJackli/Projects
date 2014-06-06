using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class AddTask : System.Web.UI.Page
{
    TaskDAL taskDal = new TaskDAL();
    string userID = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] != null)
        {
            userID = Session["User"].ToString();
        }
        else
        {
            Response.Redirect("UserLogin.aspx",true);
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        string id = this.hidID.Value;
        string TypeID = this.ddlTaskType.TypeID;
        string processID = this.ddlProcessType.ProcessingID;
        string content = this.txtDetails.Text.Trim();
        string title = this.txtTitle.Text.Trim();

        if (title.Length == 0)
        {
            MessageBox.Show(this, "Title cannot be empty.");
            return;
        }

        if (content.Length == 0)
        {
            MessageBox.Show(this, "Content cannot be empty.");
            return;
        }
        if (TypeID == "0")
        {
            MessageBox.Show(this, "Please select type.");
            return;
        }
        if (TypeID =="1" && processID == "0")
        {
            MessageBox.Show(this, "Please select Process.");
            return;
        }
        if ((TypeID != "1" || TypeID == "0") && processID!="0")
        {
            MessageBox.Show(this, "Please select Process.");
            return;
        }
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
            }

            TaskEntity tt = new TaskEntity();
            tt.Content = content;
            tt.TypeID = TypeID;
            tt.ProcessID = processID;
            tt.UserID = userID;
            tt.Title = title;
            tt.CreateTime = DateTime.Now;
            tt.Attachment = fileFullPath;
            tt.FileName = fileName;
            if (taskDal.AddTask(tt))
            {
                MessageBox.Show(this, "Add task successfully.");
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
}