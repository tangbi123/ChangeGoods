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
    /// Order.xaml 的交互逻辑
    /// </summary>
    public partial class Order : Page
    {
        public static string buy_num;
        public static string shop_num;
        public static string good_num;
        public Order()
        {
            InitializeComponent();
        }

        public Order(DataRow dr)
        {
            InitializeComponent();
            show(dr);
        }

        public void show(DataRow dr) 
        {
            buy_num = dr[0].ToString();
            shop_num = dr[1].ToString();
            good_num = dr[2].ToString();
            SQLCon sqlcon = new SQLCon();
            DataSet buy_ds = sqlcon.GetDataSet(string.Format("select 昵称 from 会员表 where 用户号='{0}' ", buy_num));
            DataSet shop_ds = sqlcon.GetDataSet(string.Format("select 昵称 from 会员表 where 用户号='{0}' ", shop_num));
            DataSet good_ds = sqlcon.GetDataSet(string.Format("select * from 商品表 where 商品号='{0}'", good_num));
            DataRow buy_dr = buy_ds.Tables[0].Rows[0];
            DataRow shop_dr = shop_ds.Tables[0].Rows[0];
            DataRow good_dr = good_ds.Tables[0].Rows[0];
            label.Content = "商品名称：" + good_dr[2];
            label1.Content = "卖家：" + shop_dr[0];
            label2.Content = "买家：" + buy_dr[0];
            image.Source = new BitmapImage(new Uri(dr[5].ToString(), UriKind.RelativeOrAbsolute));
            label4.Content = dr[5];
            label3.Content = dr[6];
            if(label3.Content.ToString() == "已发货")
            {
                button.IsEnabled = false;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            button.IsEnabled = false;
            string sql = string.Format("update 订单表 set 订单状态='已发货' where 买家id='{0}' and 卖家id='{1}' and 商品id='{2}'", buy_num, shop_num, good_num);
            SQLCon sqlcon = new SQLCon();
            sqlcon.UpdateSql(sql);
        }
    }
}
