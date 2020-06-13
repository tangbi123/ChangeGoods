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

namespace 交易平台.zfw
{
    /// <summary>
    /// Change.xaml 的交互逻辑
    /// </summary>
    public partial class Change : UserControl
    {
        string email { get; set; }
        public Change(string email)
        {
            this.email = email;
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            label2.Visibility = Visibility.Hidden;
            label3.Visibility = Visibility.Hidden;
            label4.Visibility = Visibility.Hidden;
            string pass1 = passwordBox.Password;
            string pass2 = passwordBox1.Password;
            if (pass1.Equals(""))
            {
                label2.Visibility = Visibility.Visible;
                return;
            }
            if(pass1.Length > 20)
            {
                label3.Visibility = Visibility.Visible;
                return;
            }
            if(pass1 != pass2)
            {
                label4.Visibility = Visibility.Visible;
                return;
            }
            SQLCon sqlcon = new SQLCon();
            bool f = sqlcon.Change(email, pass1);
            if (f)
            {
                MessageBox.Show("修改成功！");
                this.Content = new Main();
            }
            else
                MessageBox.Show("修改失败！");

        }
    }
}
