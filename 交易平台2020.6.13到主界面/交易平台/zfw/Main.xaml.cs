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

namespace 交易平台.zfw
{
    /// <summary>
    /// Main.xaml 的交互逻辑
    /// </summary>
    public partial class Main : UserControl
    {
        public Main()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Logon();
             
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            label2.Visibility = Visibility.Hidden;
            string emial = textBox.Text;
            if(emial == "")
            {
                label2.Visibility = Visibility.Visible;
                return;
            }
            string pass = passwordBox.Password;
            if(pass == "")
            {
                label2.Visibility = Visibility.Visible;
                return;
            }
           
            SQLCon sqlcon = new SQLCon();
            string password = sqlcon.Login(emial);
            if(pass == password)
            {
                this.Content = new Frame()
                {
                    Content = new MainPage()
                };
            }
            else
            {
                label3.Visibility = Visibility.Visible;
            }
        }

        private void click(object sender, RoutedEventArgs e)
        {
            this.Content = new Find();
        }
    }
}
