using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

namespace 交易平台
{
    /// <summary>
    /// Logon1.xaml 的交互逻辑
    /// </summary>
    public partial class Logon : UserControl
    {
        string code = "";
        string a = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        int time;

        public Logon()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Main(); 
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            label3.Visibility = Visibility.Hidden;
            label4.Visibility = Visibility.Hidden;
            label5.Visibility = Visibility.Hidden;
            label6.Visibility = Visibility.Hidden;
            label7.Visibility = Visibility.Hidden;
            label9.Visibility = Visibility.Hidden;
            string emial = textBox.Text;
            string pass1 = passwordBox.Password;
            string pass2 = passwordBox1.Password;
            if(emial == "" || emial.Length != 11)
            {
                label3.Visibility = Visibility.Visible;
                return;
            }
            if(pass1 == "")
            {
                label7.Visibility = Visibility.Visible;
                return;
            }
            if(pass1.Length > 20)
            {
                label5.Visibility = Visibility.Visible;
                return;
            }
            if(pass2 == "" || pass1 != pass2)
            {
                label4.Visibility = Visibility.Visible;
                return;
            }
            //if()
            SQLCon sqlcon = new SQLCon();
            string sql = string.Format("insert into 用户表 values({0},{1})", emial, pass1);
            int i = sqlcon.Logon(sql);
            if(i != 1)
            {
                label6.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("注册成功！");
                this.Content = new Main();
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //实例化一个随机数
            Random b = new Random();
            string yzm = "";
            //循环6次得到一个随机的六位数的验证码
            for (int i = 0; i < 6; i++)
            {
                code = code + a.Substring(b.Next(0, a.Length), 1);
            }
            //创建服务器对象
            SmtpClient smtp = new SmtpClient("smtp.qq.com");
            //创建邮件对象准备发送
            MailAddress mail1 = new MailAddress("邮箱账号@qq.com");

        }
    }
}