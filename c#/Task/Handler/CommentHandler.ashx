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
        string loginUserID = "";
        if (context.Session["User"] != null)
        {
            loginUserID = context.Session["User"].ToString();
        }
        try
        {
            string type = context.Request.QueryString["Type"];
            string taskID = context.Request.QueryString["taskID"];
            string content = context.Request.QueryString["Content"];
            string commentID = context.Request.QueryString["ID"];
            if (!string.IsNullOrEmpty(type) && type == "AddComment")
            {
                if (context.Session["User"] == null)
                {
                    context.Response.Write("false");
                    return;
                }
                else if (!string.IsNullOrEmpty(taskID) && !string.IsNullOrEmpty(content))
                {
                    if (AddComment(taskID, content, loginUserID))
                    {
                        //after insert successfully. need return comment. 
                        //JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                        //string responseText = javaScriptSerializer.Serialize(GetLastComment(taskID));
                        //context.Response.ContentType = "text/json";
                        //context.Response.Write(responseText);
                        string htmlCode = PopulateComment(taskID, loginUserID);
                        context.Response.ContentType = "text/html";
                        context.Response.Write(htmlCode);
                    }
                }
            }
            if (!string.IsNullOrEmpty(type) && type == "AllComment")
            {
                string htmlCode = PopulateComment(taskID, loginUserID);
                //JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                //string responseText = javaScriptSerializer.Serialize(GetComment(taskID));
                context.Response.ContentType = "text/html";
                context.Response.Write(htmlCode);
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
        DataTable dt = cmt.GetCommentByID(Convert.ToInt32(taskID),1); //the first page.
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
    private string PopulateComment(string taskID,string loginUser)
    {
        StringBuilder sb = new StringBuilder();
        //if(comment userid== login id) can edit ,delete
        //else only can see.
        string loginID = loginUser;
        var tab = "<table width='100%' cellpadding='1' cellspacing='0' border='0' id='content'>";
        var trHeader = "<tr style='background-color: #ddd; padding-top: 5px;'>";
        var trBegin = "<tr style='height: 30px; overflow: auto;'>";
        var trEnd = "</tr>";
        var tabEnd = "</table>";
        sb.Append(tab);
        List<CommentEntity> cmtList = GetComment(taskID);
        foreach (CommentEntity entity in cmtList)
        {
            if (loginUser.Length > 0 && entity.userID == loginUser)
            {
                sb.Append(trHeader);
                sb.Append("<td align='left'>" + "#" + entity.ID + " " + entity.userID + "</td>");
                sb.Append("<td align='right'>" + entity.ReplyTime + "</td>");
                sb.Append(trBegin + "<td colspan='2'>" + entity.Content + "</td>" + trEnd);
                sb.Append(trBegin + "<td colspan='2'  align='right'><a href='javascript:void(0)' onclick='javascript:EditRow( " + entity.ID + ");'>Edit</a> | <a href='javascript:void(0)' onclick='javascript:deleteRow( " + entity.ID + ");'>delete</a></td>" + trEnd);
                sb.Append(trEnd);
            }
            else
            {
                sb.Append(trHeader);
                sb.Append("<td align='left'>" + "#" + entity.ID + " " + entity.userID + "</td>");
                sb.Append("<td align='right'>" + entity.ReplyTime + "</td>");
                sb.Append(trBegin + "<td colspan='2'>" + entity.Content + "</td>" + trEnd);
                sb.Append(trBegin + "<td colspan='2'></td>" + trEnd);
                sb.Append(trEnd);
            }
        }
        sb.Append(tabEnd);
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