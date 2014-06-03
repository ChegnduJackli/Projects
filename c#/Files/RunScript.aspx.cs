using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Configuration;
using VendorsEntity;
using System.Data.OracleClient;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;

public partial class RunScript : System.Web.UI.Page
{
    string DDL_Batch = "Batch";
    string DDL_Script = "UpdateOrInsert";
    string DDL_Query = "Query";
    string DDL_Item10 = "10";
    string DDL_Item20 = "20";
    string DDL_Item50 = "50";
    string DDL_Item100 = "100";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
            InitControl();
        }
    }
    private void BindData()
    {
        this.DropDownList1.Items.Clear();
        this.DropDownList1.Items.Add(DDL_Query);
        this.DropDownList1.Items.Add(DDL_Script);
        this.DropDownList1.Items.Add(DDL_Batch);

        this.ddlItems.Items.Clear();
        this.ddlItems.Items.Add(DDL_Item10);
        this.ddlItems.Items.Add(DDL_Item20);
        this.ddlItems.Items.Add(DDL_Item50);
        this.ddlItems.Items.Add(DDL_Item100);
        this.ddlItems.SelectedIndex = 1;
        
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        this.txtContent.Text = string.Empty;
        this.lblMsg.Text = string.Empty;
        this.GridView1.DataSource = null;
        this.GridView1.DataBind();
        
        Session["DS"] = null;
    }
    protected void btnRun_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.DropDownList1.SelectedItem.Text == DDL_Script)
            {
                string script = this.txtContent.Text.Trim();
                if (script.Length == 0)
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "Information", "<script>alert('Script cannot be empty.');</script>");
                    return;
                }
                //run script
                if (script.ToLower().IndexOf("update") < 0 && script.ToLower().IndexOf("insert") < 0 && script.ToLower().IndexOf("delete") < 0)
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "Information", "<script>alert('Invalid Script.');</script>");
                    return;
                }
                int i = RunScripts(script);
                this.lblMsg.Text = "Total " + i + " rows affected";
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "Success", "<script>alert('script run successfully.');</script>");
            }
            else if (this.DropDownList1.SelectedItem.Text == DDL_Query)
            {
                string script = this.txtContent.Text.Trim();
                if (script.Length == 0)
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "Information", "<script>alert('Script cannot be empty.');</script>");
                    return;
                }
                if (script.ToUpper().IndexOf("SELECT") < 0)
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "Information", "<script>alert('Invalid Script.');</script>");
                    return;
                }
                Session["DS"] = null;
                BindQueryData();
            }
            else//run script in file
            {
                if (this.FileUpload1.HasFile)
                {
                    string fileName = this.FileUpload1.PostedFile.FileName;
                    if (fileName.ToLower().IndexOf(".sql") <= 0)
                    {
                        ClientScript.RegisterStartupScript(ClientScript.GetType(), "Information", "<script>alert('File extension is not corrent');</script>");
                        return;
                    }
                    string scripts = GetFileContentByName();
                    int i = RunScripts(scripts);
                    this.lblMsg.Text = "Total " + i + " rows affected";
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "Success", "<script>alert('File script run successfully.');</script>");
                }
            }
        }
        catch (Exception ex)
        {
            this.lblMsg.Text = ex.Message;
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "Error", "<script>alert('" + ex.Message + "');</script>");
        }
    }
    private string GetFileContentByName()
    {
        StringBuilder sb = new StringBuilder();
        try
        {
            using (Stream fileStream = FileUpload1.PostedFile.InputStream)
            {
                using (StreamReader sr = new StreamReader(fileStream))
                {
                    string idNum = null;
                    while ((idNum = sr.ReadLine()) != null)
                    {
                        sb.Append(idNum);
                    }
                }
            }
            return sb.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private int RunScripts(string scripts)
    {
        string Separator = ";";
        Database db = null;
        DbCommand dbCommand = null;
        int count=0;
        try
        {
            db = DatabaseFactory.CreateDatabase("AGD");
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    if (scripts.IndexOf(";") < 0)
                    {
                        scripts += Separator;
                    }

                    string[] array = scripts.Split(new string[] { Separator }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string sql in array)
                    {
                        if (sql.Trim().Length > 0)
                        {
                            dbCommand = db.GetSqlStringCommand(sql);
                            int i = db.ExecuteNonQuery(dbCommand);
                            count += i;
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    if (db != null) { db = null; }
                    if (dbCommand != null) { dbCommand = null; }
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            return count;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        InitControl();
    }
    private void InitControl()
    {
        if (DropDownList1.SelectedItem.Text == DDL_Script || DropDownList1.SelectedItem.Text == DDL_Query)
        {
            paneScripts.Visible = true;
            panelFile.Visible = false;
        }
        else
        {
            paneScripts.Visible = false;
            panelFile.Visible = true;
        }
        if (DropDownList1.SelectedItem.Text == DDL_Query)
        {
            panelResults.Visible = true;
        }
        else
        {
            panelResults.Visible = false;
        }
            
        this.lblMsg.Text = string.Empty;
    }

    private void BindQueryData()
    {
        DataSet ds = new DataSet();
        try
        {
            string sql = this.txtContent.Text.Trim();
            sql=sql.Replace(";","");
            if (Session["DS"] == null)
            {
                ds = GetDataset(sql);
                Session["DS"] = ds;
            }
            else
            {
                ds = (DataSet)Session["DS"];
            }
            GridView1.PageSize = Convert.ToInt16(this.ddlItems.SelectedValue);
            this.GridView1.DataSource = ds;
            this.GridView1.DataBind();
            this.lblMsg.Text = "Total " + ds.Tables[0].Rows.Count.ToString() + " Records Found.";
            ds = null;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private DataSet GetDataset(string sql)
    {
        Database db = null;
        DataSet ds = null;
        DbCommand dbCommand = null;
        try
        {
            db = DatabaseFactory.CreateDatabase("AGD");
            dbCommand = db.GetSqlStringCommand(sql);
            dbCommand.CommandType = CommandType.Text;
            ds = new DataSet();
            ds = db.ExecuteDataSet(dbCommand);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (db != null)
                db = null;

            if (dbCommand != null)
                dbCommand = null;
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        BindQueryData();
    }

    protected void imgExcel_Click(object sender, ImageClickEventArgs e)
    {

        try
        {
            Response.ClearHeaders();
            DataSet ds = new DataSet();
            if (this.GridView1.Rows.Count==0)
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "Warn", "<script>alert('No data to export.');</script>");
                return;
            }
            if (Session["DS"]==null)
            {
                BindQueryData();
            }
            ds = (DataSet)Session["DS"];
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "Warn", "<script>alert('No data to export.');</script>");
                return;
            }
            string attachment = "attachment; filename=QueryResult.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/vnd.ms-excel";
            string tab = "";

            foreach (DataColumn dc in dt.Columns)
            {
                Response.Write(tab + dc.ColumnName.ToUpper());
                tab = "\t";
            }
            Response.Write("\n");
            int i;

            foreach (DataRow dr in dt.Rows)
            {
                tab = "";
                for (i = 0; i < dt.Columns.Count; i++)
                {
                    Response.Write(tab + dr[i].ToString());
                    tab = "\t";
                }
                Response.Write("\n");
            }
            ds = null;
            Response.End();
        }
        catch (Exception ex)
        {
            this.lblMsg.Text = ex.Message;
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "Error", "<script>alert('" + ex.Message + "');</script>");
        }
    }
    protected void ddlItems_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.GridView1.Rows.Count > 0)
        {
            BindQueryData();
        }
    }
}
