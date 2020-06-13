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
    /// Find.xaml 的交互逻辑
    /// </summary>
    public partial class Find : UserControl
    {

        string code = "";
        string a = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        int time;
        DispatcherTimer timer = null;
        public Find()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Main();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            label2.Visibility = Visibility.Hidden;
            label3.Visibility = Visibility.Hidden;
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
                //判断该邮箱是否注册
                SQLCon sqlcon = new SQLCon();
                bool f = sqlcon.Check(textBox.Text);
                if (!f)
                {
                    label3.Visibility = Visibility.Visible;
                    return;
                }
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
                button.IsEnabled = false;
                //倒计时30秒
                time = 30;
                //激活timer事件
                timer.Tick += Tick;
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Start();
                MessageBox.Show("发送成功");
            }
            catch (Exception ex)
            {
                label2.Visibility = Visibility.Visible;

            }
        }

        private void Tick(object sender, EventArgs e)
        {
            button.Content = time-- + "s";
            if (time < 0)
            {
                timer.Stop();
                button.Content = "获取验证码";
                button.IsEnabled = true;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            label2.Visibility = Visibility.Hidden;
            label4.Visibility = Visibility.Hidden;
            string email = textBox.Text;
            string pass = textBox1.Text;
            if(email.Equals(""))
            {
                label2.Visibility = Visibility.Visible;
                return;
            }
            if(pass != code)
            {
                label4.Visibility = Visibility.Visible;
                return;
            }
            this.Content = new Change(email);
        }
    }
}
