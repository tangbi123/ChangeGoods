using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Windows.Threading;

namespace 交易平台.zfw
{
    /// <summary>
    /// Logon1.xaml 的交互逻辑
    /// </summary>
    public partial class Logon : UserControl
    {
        string code = "";
        string a = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        int time;
        DispatcherTimer timer = null;

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
            string email = textBox.Text;
            string pass1 = passwordBox.Password;
            string pass2 = passwordBox1.Password;
            string pass3 = textBox1.Text;
            if(email == "")
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
            if(pass3 != code)
            {
                label9.Visibility = Visibility.Visible;
                return;
            }
            SQLCon sqlcon = new SQLCon();
            string sql = string.Format("insert into 用户表 values('{0}',{1})", email, pass1);
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
            timer = new DispatcherTimer();
            //循环6次得到一个随机的六位数的验证码
            for (int i = 0; i < 6; i++)
            {
                code = code + a.Substring(b.Next(0, a.Length), 1);
            }
            //创建服务器对象
            SmtpClient smtp = new SmtpClient("smtp.qq.com");
            //创建邮件对象准备发送
            MailAddress mail1 = new MailAddress("545974184@qq.com");
            try
            {
                //获取文本框的收件人的邮箱

                MailAddress mail2 = new MailAddress(textBox.Text);
                //创建邮件对象，准备发送【mail1是发件人地址，mail2是收件人地址】
                MailMessage mess = new MailMessage(mail1, mail2);
                //邮件的标题
                mess.Subject = "邮件验证码";
                //邮件的内容
                mess.Body = "您的验证码为" + code + ",请在30分钟内验证，系统邮件请勿回复！";
                //创建互联网安全证书
                NetworkCredential cred = new NetworkCredential("545974184@qq.com", "wcslfmzechhxbdhe");
                //证书绑定到服务器对象以便服务器验证
                smtp.Credentials = cred;
                //开始发送
                smtp.Send(mess);
                //发送完成后按钮不可用
                button2.IsEnabled = false;
                //倒计时30秒
                time = 30;
                //激活timer事件
                timer.Tick += Timer_Tick;
                timer.Start();
                MessageBox.Show("发送成功");
            }
            catch(Exception ex)
            {
                MessageBox.Show("输入正确的邮箱格式！");
                MessageBox.Show(ex.Message);

            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            button2.Content = time--;
            if(time < 0)
            {
                button2.Content = "获取验证码";
                button2.IsEnabled = true;
                timer.Stop();
            }
        }
    }
}