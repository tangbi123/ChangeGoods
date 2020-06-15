using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 交易平台.tb.User
{
    /// <summary>
    /// UserDetail.xaml 的交互逻辑
    /// </summary>
    public partial class UserDetail : Page
    {
        public UserDetail()
        {
            InitializeComponent();
            
        }
        public UserDetail(string userno)
        {
            InitializeComponent();
            GetUserInfo(userno);
        }

        private void GetUserInfo(string userno)
        {
            string sqlstr = string.Format("select * from 会员表 where 用户号 = '{0}'", userno);
            //MessageBox.Show(sqlstr);

            DataSet ds = TbSql.GetDataSet(sqlstr);

            DataRow dr = ds.Tables[0].Rows[0];

            // 基本信息.Content = dr[5] + "的基本信息";
            用户号.Text = "用户号：" + dr[0].ToString();
            //手机号.Content = dr[1];
            邮箱.Text = "邮箱：" + dr[2].ToString(); ;

            性别.Text = "性别：" + dr[4].ToString();

            昵称.Text = "昵称：" + dr[5].ToString();

            用户等级.Text  = "用户等级" + dr[6].ToString();
            信誉等级.Text = "信誉等级"  + dr[7].ToString();
        }

    }
}
