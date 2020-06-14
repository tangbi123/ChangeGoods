using System;
using System.Collections.Generic;
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
using 交易平台.tb.MainStructure;
using 交易平台.tb;
using System.Data;

namespace 交易平台.tb.User
{
    /// <summary>
    /// User.xaml 的交互逻辑
    /// </summary>
    public partial class User : Page
    {
        public bool btnC=false;
        public User()
        {
            InitializeComponent();
            GetInfo();
        }

        /// <summary>
        /// 修改 昵称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            昵称.IsReadOnly = !昵称.IsReadOnly;
            密码.IsReadOnly = !密码.IsReadOnly;
            if(btnC == false) //编辑
            {
                btnC = true;
                btn1.Content = "保存";

                密码.Background = Brushes.White;
                昵称.Background = Brushes.White;
            }
            else//保存
            {
                btnC = false;
                btn1.Content = "编辑";
                密码.Background = new SolidColorBrush(Color.FromArgb(0x60, 0xAD, 0xD6, 0xE6));
                昵称.Background = new SolidColorBrush(Color.FromArgb(0x60, 0xAD, 0xD6, 0xE6));

                string nicheng = 昵称.Text;
                string pwd = 密码.Text;

                string sqlstr = string.Format("Update 会员表 set 密码='{0}' , 昵称 ='{1}' where 邮箱='{2}'", pwd, nicheng, TbSql.mail);

                //MessageBox.Show(sqlstr);
                int row = TbSql.UpdateSql(sqlstr);
                if (row > 0) MessageBox.Show("修改成功!");
            }

        }

        private void GetInfo()
        {
            string sqlstr = string.Format("select * from 会员表 where 邮箱 = '{0}'", TbSql.mail);
            //MessageBox.Show(sqlstr);

            DataSet ds = TbSql.GetDataSet(sqlstr);

            DataRow dr = ds.Tables[0].Rows[0];

            基本信息.Content = dr[5] + "的基本信息";
            用户号.Content = dr[0];
            //手机号.Content = dr[1];
            邮箱.Content = dr[2];

            密码.Text = dr[3].ToString();
            密码.IsReadOnly = true;
            密码.Background = new SolidColorBrush(Color.FromArgb(0x60, 0xAD, 0xD6, 0xE6));

            性别.Content = dr[4];

            昵称.Text = dr[5].ToString();
            昵称.IsReadOnly = true;
            昵称.Background = new SolidColorBrush(Color.FromArgb(0x60,0xAD,0xD6,0xE6)); 

            用户等级.Content = dr[6];
            信誉等级.Content = dr[7];
            注册时间.Content = dr[8];
        }


        
    }
}
