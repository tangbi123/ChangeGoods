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

namespace 交易平台后台
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            label2.Visibility = Visibility.Hidden;
            label3.Visibility = Visibility.Hidden;
            string ID = textBox.Text;
            if(ID.Equals(""))
            {
                label2.Visibility = Visibility.Visible;
                return;
            }
            string pass = passwordBox.Password;
            SQLCon sqlcon = new SQLCon();
            string password = sqlcon.Login(ID);
            if(pass != password)
            {
                label3.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                MessageBox.Show("登录成功！");
                NavigationService.Navigate(new Uri("/Main.xaml", UriKind.Relative));
            }
        }
    }
}
