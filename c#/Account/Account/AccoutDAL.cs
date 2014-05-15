using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Account
{
    public class AccoutDAL
    {
        public bool AddAccount(string user, double Amount, string desc)
        {
            try
            {
                string sql = "Select count(1) from AccountInfo where UserName=@UserName";
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@UserName", user);
                if (SqlHelper.GetSingle(sql, par) != null && Convert.ToInt32(SqlHelper.GetSingle(sql, par)) > 0)
                {
                    throw new ApplicationException("该记录已存在.");
                }
                sql = @"Insert into AccountInfo(UserName,Amount,Description,AddTime) values(@UserName,@Amount,@Description,@AddTime)";
                 par = new SqlParameter[4];
                par[0] = new SqlParameter("@UserName", user);
                par[1] = new SqlParameter("@Amount", Amount);
                par[2] = new SqlParameter("@Description", desc);
                par[3] = new SqlParameter("@AddTime", DateTime.Now);
                int i = SqlHelper.ExecuteSql(sql, par);
                return i > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetAllAccount()
        {
            List<string> AccountList = new List<string>();
            try
            {
                string sql = @"Select UserName, Amount,Description,AddTime from AccountInfo";
                DataTable dt = SqlHelper.Query(sql).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteAccount(string userName) 
        {
            try
            {
                string sql = @"Delete from AccountInfo where userName=@userName";
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@UserName", userName);
                int i = SqlHelper.ExecuteSql(sql, par);
                return i>0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
