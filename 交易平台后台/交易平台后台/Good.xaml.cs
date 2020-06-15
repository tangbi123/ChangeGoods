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

namespace 交易平台后台
{
    /// <summary>
    /// Good.xaml 的交互逻辑
    /// </summary>
    public partial class Good : Page
    {
        public Good()
        {
            InitializeComponent();
            show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Main.xaml", UriKind.Relative));
        }

        private void show()
        {
            string sqlstr = string.Format("select * from 商品表");
            SQLCon sqlcon = new SQLCon();
            DataSet ds = sqlcon.GetDataSet(sqlstr);
            int row = ds.Tables[0].Rows.Count;
            for (int i = 0; i < row; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                listBox.Items.Add(new Frame().Content = new GD_Show(dr));
                listBox.Items.Add(new Separator());
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
            show();
        }
    }
}
