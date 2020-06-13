using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _201800800538唐彪数据库.Programes
{
    class SqlOperation:BaseManager<SqlOperation>
    {
        public static string ConStr =
                @"Data Source=DESKTOP-R5TQB0I\SQLEXPRESS;Initial Catalog=Salary;Integrated Security = TRUE";


        /// <summary>
        /// 执行查询 操作
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
            catch
            {
                MessageBox.Show("操作 失败");
            }
            finally {
                if (conn != null)
                    conn.Close();
                    
                        }
            return rowCount;
        }
        public static SqlCommand BuildProcCommand(SqlConnection conn,string procName,SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(procName, conn);
            command.CommandType = CommandType.StoredProcedure;
            if(parameters != null)
            foreach (SqlParameter para in parameters)
            {
                if (parameters != null)
                {
                    if ((para.Direction == ParameterDirection.InputOutput
                        || para.Direction == ParameterDirection.Input)
                        && para.Value == null) 
                        para.Value = DBNull.Value;

                    command.Parameters.Add(para);
                }
            }

            return command;
        }

        public static int RunProc(string procName,SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(ConStr);

            int rowAffected = 0;
            try
            {
                conn.Open();
                SqlCommand command = BuildProcCommand(conn, procName, parameters);
                rowAffected = command.ExecuteNonQuery();
                
            }

            catch
            {
                MessageBox.Show("数据库 打开失败");
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return rowAffected;
        }

    }
}
