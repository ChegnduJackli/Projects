using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using SQL;

namespace DataAccess
{
    public class DAL
    {
        public DataTable GetAllWords()
        {
            try
            {
                string sql="select * from words";
                DataSet ds =SqlHelper.Query(sql);
                return ds.Tables[0];
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetDescByWords(string word)
        {
            try
            {
                string sql = "select * from WORDS where word=@word";
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@word", word);
                DataSet ds = SqlHelper.Query(sql, par);
                return ds.Tables[0];
            }
            catch
            {
                throw;
            }
        }
        public int AddWord(Entity.WordsEntity entity)
        {
            try
            {
                string sql = "insert into WORDS(WORD,DESCRIPTION,ADDTIME) values (@Word,@Desc,@AddTime)";
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@word", entity.Word);
                par[1] = new SqlParameter("@Desc", entity.Description);
                par[2] = new SqlParameter("@AddTime", entity.AddTime);
                int result = SqlHelper.ExecuteSql(sql, par);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public int UpdateWord(Entity.WordsEntity entity)
        {
            try
            {
                string sql = "update WORDS set DESCRIPTION=@Desc where word=@word";
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@Desc", entity.Description);
                par[1] = new SqlParameter("@word", entity.Word);
                int result = SqlHelper.ExecuteSql(sql, par);
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
