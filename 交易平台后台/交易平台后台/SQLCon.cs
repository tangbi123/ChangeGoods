using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace 交易平台后台
{
    class SQLCon
    {
        public static string UID;
        public string s = null;
        public SqlConnection conn = null;
        public SQLCon()
        {
            s = "Data Source = 127.0.0.1; " +
                "Persist Security Info=True;" +
                "Initial Catalog=Change;" +
                "Integrated Security=false;" +
                "User ID=admin;" +
                "Password=123456;";
            conn = new SqlConnection(s);
        }

        public string Login(string ID)
        {
            UID = ID;
            string password = "";
            try
            {
                conn = new SqlConnection(s);
                conn.Open();
                SqlCommand comd = conn.CreateCommand();
                comd.CommandText = string.Format("(select * from 管理员 where 管理员id='{0}')", ID);
                SqlDataReader reader = comd.ExecuteReader();
                if (!reader.Read())
                {
                    return "";
                }
                password = reader.GetString(reader.GetOrdinal("密码"));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return password;
        }

        public DataSet GetDataSet(string sqlstr)
        {

            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sqlstr, conn);
                da.Fill(ds);
            }
            catch
            {
                MessageBox.Show("查询失败");
            }
            //ds.Dispose();
            conn.Close();
            return ds;
        }

        public int UpdateSql(string sqlstr)
        {
            int rowCount = 0;
            try
            {
                SqlCommand sc = new SqlCommand(sqlstr, conn);
                conn.Open();
                rowCount = sc.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("操作 失败");
            }
            finally
            {
                if (conn != null)
                    conn.Close();

            }
            return rowCount;
        }
    }
}
