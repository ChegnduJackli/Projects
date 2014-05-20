using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;

public partial class BindGridview1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static Names[] GetNames()
    {
        List<Names> list = new List<Names>();
        DataTable dt = DataStore.GetDataTable();
        foreach (DataRow row in dt.Rows)
        {
            Names _names = new Names();
            _names.FirstName = row["Name"].ToString();
            _names.Age = row["age"].ToString();

            list.Add(_names);
        }
        return list.ToArray();
    }

    private void Test()
    {
        string sql = @"insert into tableName(columan) values(ColumnValue,)";
    }
}