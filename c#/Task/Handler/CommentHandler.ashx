<%@ WebHandler Language="C#" Class="CommentHandler" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Serialization;
using System.Text;

public class CommentHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        // context.Response.ContentType = "text/plain";
        //        context.Response.Write("Hello World");
        //if (context.Session["User"] == null)
        //{
        //    context.Response.Redirect("../Default.aspx", true); 
        //    return;
        //}
        try
        {
            string type = context.Request.QueryString["Type"];
            string taskID = context.Request.QueryString["taskID"];
            string content = context.Request.QueryString["Content"];
            string commentID = context.Request.QueryString["ID"];
            string userID = "lideng"; //context.Session["User"].ToString();
            if (!string.IsNullOrEmpty(type) && type == "LastComment")
            {
                if (!string.IsNullOrEmpty(taskID) && !string.IsNullOrEmpty(content))
                {
                    if (AddComment(taskID, content, userID))
                    {
                        //after insert successfully. need return comment. 
                        JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                        string responseText = javaScriptSerializer.Serialize(GetLastComment(taskID));
                        context.Response.ContentType = "text/json";
                        context.Response.Write(responseText);

                    }
                }
            }
            else if (!string.IsNullOrEmpty(type) && type == "AllComment")
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                string responseText = javaScriptSerializer.Serialize(GetComment(taskID));
                context.Response.ContentType = "text/json";
                context.Response.Write(responseText);
            }
            else if (!string.IsNullOrEmpty(type) && type == "DeleteComment")
            {
                if (DeleteAttachment(commentID))
                {
                    context.Response.Write("true");
                }
                else
                {
                    context.Response.Write("false");
                }
            }
        }
        catch
        {
            context.Response.Write("");
        }
        HttpContext.Current.ApplicationInstance.CompleteRequest();
    }
    private bool DeleteAttachment(string id)
    {
        Comment cmt = new Comment();
        return cmt.DeleteComment(Convert.ToInt32(id)); 
    }
    private List<CommentEntity> GetLastComment(string taskID)
    {
        Comment cmt = new Comment();

        List<CommentEntity> cmtEntityList = new List<CommentEntity>();
        CommentEntity en = new CommentEntity();

        DataTable dt = cmt.GetLastCommentByTaskID(Convert.ToInt32(taskID));
        DataRow dr = dt.Rows[0];
        //en.RowID = Convert.ToInt32(dr["RowID"]);
        en.ID = Convert.ToInt32(dr["ID"]);
        en.TaskID = taskID;
        en.ReplyTime = Convert.ToDateTime(dr["ReplyTime"]);
        en.Content = dr["Content"].ToString();
        en.userID = dr["userID"].ToString();
        cmtEntityList.Add(en);
        
        return cmtEntityList;
    }
    private List<CommentEntity> GetComment(string taskID)
    {
        Comment cmt = new Comment();
       // DataTable dt = cmt.GetCommentByTaskID(Convert.ToInt32(taskID));
        DataTable dt = cmt.GetCommentByID(Convert.ToInt32(taskID),2); //the second page.
        List<CommentEntity> cmtEntityList = new List<CommentEntity>();
        foreach (DataRow dr in dt.Rows)
        {
            CommentEntity en = new CommentEntity();
            en.ID = Convert.ToInt32(dr["ID"]);
           // en.RowID = Convert.ToInt32(dr["RowID"]);
            en.TaskID = taskID;
            en.ReplyTime = Convert.ToDateTime(dr["ReplyTime"]);
            en.Content = dr["Content"].ToString();
            en.userID = dr["userID"].ToString();
            cmtEntityList.Add(en);
           
        }
        return cmtEntityList;
    }
    private string PopulateComment(string taskID)
    {
        StringBuilder sb = new StringBuilder();
        //if(comment userid== login id) can edit ,delete
        //else only can see.
        return sb.ToString(); 
    }
    private bool AddComment(string taskID, string content, string userID)
    {
        Comment cmt = new Comment();
        
        if (!ConvertToInt32(taskID)) return false;
        
        if (cmt.AddComment(Convert.ToInt32(taskID), content, userID))
        {
            return true;
        }
        return false;
    }
    private bool ConvertToInt32(string value)
    {
        int defaultValue = 0;
        if (Int32.TryParse(value, out defaultValue))
        {
            return true; 
        }
        return false;
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}