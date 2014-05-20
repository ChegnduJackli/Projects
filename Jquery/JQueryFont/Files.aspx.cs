using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Files : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strNull = null;
        string str = strNull ?? string.Empty;
        string ss = strNull == null ? string.Empty : strNull;

        string strEmpy = string.Empty;
        string sadf = strEmpy ?? "df";
    }
    protected void btnDownloadfile_Click(object sender, EventArgs e)
    {
        try
        {
            string filePath = this.FileUpload1.FileName;
            string fileDir = @"C:\Users\lideng\Desktop\";
            filePath = System.IO.Path.Combine(fileDir, filePath);
            Server.Execute(string.Format("DownloadFile.aspx?FilePath={0}", filePath));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}