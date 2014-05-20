using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Common_DownloadFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FileStream fs = null;
        System.IO.Stream iStream = null;
        string filePath = string.Empty;
        long dataToRead = 0;
        const long ChunkSize = 102400; //100K
        int length = 0;
        string fileName = string.Empty;

        try
        {
            if (Request.QueryString["FilePath"] == null)
            {
                return;
            }
            else
            {
                filePath = Request.QueryString["FilePath"].ToString();
            }
            fileName = Path.GetFileName(filePath);
            iStream = new System.IO.FileStream(filePath, System.IO.FileMode.Open,
                      System.IO.FileAccess.Read, System.IO.FileShare.Read);

            byte[] buffer = new Byte[ChunkSize]; //100k
            // Total bytes to read:
            dataToRead = iStream.Length;
            if (dataToRead == 0)
            {
                return;
            }
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            //Response.ContentType = "application/octet-stream";
            Response.ContentType = MimeType(System.IO.Path.GetExtension(fileName));
            Response.AppendHeader("Content-Length", dataToRead.ToString());
            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            // Read the bytes.
            while (dataToRead > 0)
            {
                // Verify that the client is connected.
                if (Response.IsClientConnected)
                {
                    length = iStream.Read(buffer, 0, Convert.ToInt32(ChunkSize));
                    Response.OutputStream.Write(buffer, 0, length);
                    Response.Flush();
                    dataToRead = dataToRead - length;
                }
                else
                {
                    //prevent infinite loop if user disconnects
                    dataToRead = -1;
                }
            }
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            Response.Close();
          
        }
        catch (Exception ex)
        {
            string strRedirectURL = "../Common/ErrorPage.aspx";
            Response.Redirect(strRedirectURL, true);
            throw ex;
        }
        finally
        {
            if (fs != null) { fs.Close(); }
            if (iStream != null) { iStream.Close(); }
            //if (dataToRead > 0)
            //{
            //    Response.Close();
            //    HttpContext.Current.ApplicationInstance.CompleteRequest();
            //}
            //if (File.Exists(filePath)) { File.Delete(filePath); }

        }
    }

    private string MimeType(string Extension)
    {
        string mime = "application/octetstream";
        if (string.IsNullOrEmpty(Extension))
            return mime;
        string ext = Extension.ToLower();
        Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
        if (rk != null && rk.GetValue("Content Type") != null)
            mime = rk.GetValue("Content Type").ToString();
        return mime;
    }
}