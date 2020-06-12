using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace 交易平台
{
    class SQLCon
    {
        public string s = null;
        public SqlConnection conn;
        public SQLCon()
        {
            s = "Data Source = 127.0.0.1; " +
                "Persist Security Info=True;" +
                "Initial Catalog=交易平台;" +
                "Integrated Security=false;" +
                "User ID=sa;" +
                "Password=123456;";
            conn = new SqlConnection(s);
        }

        public int Logon(string sql)
        {
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                int i = command.ExecuteNonQuery();
                return i;
            }
            catch (Exception e)
            {
                return -1;
            }
            finally
            {
                conn.Close();
            }

        }

        public string Login(string phone)
        {
            string password = "";
            try
            {
                conn.Open();
                SqlCommand comd = conn.CreateCommand();
                comd.CommandText = string.Format("(select * from 用户表 where 手机号={0})", phone);
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
                if(conn != null)
                {
                    conn.Close();
                }
            }
            return password;
        }
    }
}
