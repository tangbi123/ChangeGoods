using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace 交易平台.tb
{
    class TbSql
    {
        public static string mail = SQLCon.mail;

        public static string ConStr =  "Data Source = 127.0.0.1; " +
                "Persist Security Info=True;" +
                "Initial Catalog=Change;" +
                "Integrated Security=false;" +
                "User ID=admin;" +
                "Password=123456;";

        /// <summary>
        /// 执行 查询 语句 ，输入 SQL语句  输出 dataset数据集
        /// 
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string sqlstr)
        {
            SqlConnection conn = new SqlConnection(ConStr);
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

        /// <summary>
        /// 执行 更新、删除、增加等操作，返回受影响行数，输入sql语句
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public static int UpdateSql(string sqlstr)
        {
            SqlConnection conn = new SqlConnection(ConStr);
            int rowCount = 0;
            try
            {
                SqlCommand sc = new SqlCommand(sqlstr, conn);
                conn.Open();
                rowCount = sc.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
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
