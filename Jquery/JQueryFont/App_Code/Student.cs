using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Student
/// </summary>
public class Names
{
    public Names()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string _firstName;
    private string _age;
    public string FirstName
    {
        set { _firstName = value; }
        get { return _firstName; }
    }
    public string Age
    {
        set { _age = value; }
        get { return _age; }
    }

}

public class DataStore
{
    public DataStore()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static DataTable GetDataTable()
    {
        DataTable dt = new DataTable("Names");
        DataColumn dc1 = new DataColumn("Name");
        DataColumn dc2 = new DataColumn("Age");
        dt.Columns.AddRange(new DataColumn[] { dc1, dc2 });
        DataRow dr1 = dt.NewRow();
        dr1[0] = "Ahmed";
        dr1[1] = "27";
        DataRow dr2 = dt.NewRow();
        dr2[0] = "Peter";
        dr2[1] = "30";
        DataRow dr3 = dt.NewRow();
        dr3[0] = "John";
        dr3[1] = "20";
        DataRow dr4 = dt.NewRow();
        dr4[0] = "Ali";
        dr4[1] = "30";
        dt.Rows.Add(dr1);
        dt.Rows.Add(dr2);
        dt.Rows.Add(dr3);
        dt.Rows.Add(dr4);

        return dt;
    }

}