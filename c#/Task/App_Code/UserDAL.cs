using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for User
/// </summary>
public class UserDAL
{
    public static string TaskUserID = "";
    public static string LoginUserID = "";

    public enum RoleEnum
    {
        Admin = 1,
        Member = 2
    };
    public RoleEnum EnumRole = RoleEnum.Member;


    public int ID { get; set; }
    public string UserName { get; set; }
    public string roleID { get; set; }
    public string EmailAddr { get; set; }

    public UserDAL()
    { }
    public UserDAL(string userName)
	{
        string sql = string.Empty;
        try
        {
            sql = "select id,userName,RoleID,EmailAddr from users where userName = @userName";
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@userName", userName);
            DataSet ds = SqlHelper.Query(sql, par);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                this.UserName = userName;
                this.roleID = dr["RoleID"].ToString();
                this.ID = Convert.ToInt32(dr[ID]);
                this.EmailAddr = dr["EmailAddr"].ToString();

                if (roleID == "1")
                {
                    EnumRole = RoleEnum.Admin;
                }
                else
                {
                    EnumRole = RoleEnum.Member;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
	}

    public bool Login(string userName, string password)
    {
        try
        {
            string sql = @"select id,userName,RoleID,EmailAddr from users where userName=@userName and  password=@password";
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@userName", userName);
            par[1] = new SqlParameter("@password", password);
            DataSet ds = SqlHelper.Query(sql, par);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                this.UserName = userName;
                this.roleID = dr["RoleID"].ToString();
                this.ID = Convert.ToInt32(dr[ID]);
                this.EmailAddr = dr["EmailAddr"].ToString();

                if (roleID == "1")
                {
                    EnumRole = RoleEnum.Admin;
                }
                else
                {
                    EnumRole = RoleEnum.Member;
                }
                return true;
            }
            return false;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public bool IsCurrentUser(string useID)
    {
        return UserDAL.LoginUserID.Equals(useID, StringComparison.OrdinalIgnoreCase);
    }
    public bool IsAdmin(string userID)
    {
        UserDAL u = new UserDAL(userID);
        return (u.EnumRole == RoleEnum.Admin);
    }
}