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
        public static string mail;
        public string s = null;
        public SqlConnection conn;
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


        public int Logon(string email, string password, string sex, string name)
        {
            try
            {
                conn.Open();
                int num = 0;
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT TOP 1 用户号 FROM 会员表 order by 用户号 desc";
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                num = Int32.Parse(reader.GetString(reader.GetOrdinal("用户号")));
                reader.Close();
                string sql = string.Format("insert into 会员表(用户号,手机号,邮箱,密码,性别,昵称) values('{0}',null,'{1}','{2}','{3}','{4}')",
                                            num + 1, email, password, sex, name);
                cmd = new SqlCommand(sql, conn);
                int i = cmd.ExecuteNonQuery();
                return i;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageBox.Show(e.Message);
                MessageBox.Show(e.Source);
                return -1;
            }
            finally
            {
                conn.Close();
            }

        }

        public string Login(string email)
        {
            mail = email;
            string password = "";
            try
            {
                conn.Open();
                SqlCommand comd = conn.CreateCommand();
                comd.CommandText = string.Format("(select * from 会员表 where 邮箱='{0}')", email);
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

        public bool Check(string email)
        {
            try
            {
                conn.Open();
                SqlCommand comd = conn.CreateCommand();
                comd.CommandText = string.Format("(select * from 会员表 where 邮箱='{0}')", email);
                SqlDataReader reader = comd.ExecuteReader();
                if (!reader.Read())
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public bool Change(string email, string password)
        {
            try
            {
                conn.Open();
                string sql = string.Format("update 会员表 set 密码='{0}' where 邮箱='{1}'", password, email);
                SqlCommand cmd = new SqlCommand(sql, conn);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        
    }
}
