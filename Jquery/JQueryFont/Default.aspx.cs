using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           this.GridView1.DataSource= BandTable();
           this.GridView1.DataBind();
        }
    }
    private DataTable  BandTable()
    {
        DataTable dt = new DataTable();
        dt.Clear();
        dt.Columns.Add("Name");
        dt.Columns.Add("Marks");
        DataRow rows = dt.NewRow();
        rows["Name"] = "ravi";
        rows["Marks"] = "500";
        dt.Rows.Add(rows);
        rows = dt.NewRow();
        DataRow rows1 = dt.NewRow();
        rows1["Name"] = "rav3i";
        rows1["Marks"] = "501";
        dt.Rows.Add(rows1);
        DataRow rows2 = dt.NewRow();
        rows2["Name"] = "rav2i";
        rows2["Marks"] = "502";
        dt.Rows.Add(rows2);
        DataRow rows3 = dt.NewRow();
        rows3["Name"] = "ravi1";
        rows3["Marks"] = "400";
        dt.Rows.Add(rows3);

        dt.DefaultView.Sort = "Marks asc";
        dt = dt.DefaultView.ToTable();
        return dt;
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        string s = TextBox1.Text;
      Label1.Text =  getDate(s).ToShortDateString();
    }
    private DateTime getDate(string s)
    {
        DateTime dt;
        if (DateTime.TryParse(s, out dt))
        {
            return dt;
        }
        return dt;
    }
}
