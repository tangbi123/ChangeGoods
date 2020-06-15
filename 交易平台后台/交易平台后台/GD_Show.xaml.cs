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
    /// GD_Show.xaml 的交互逻辑
    /// </summary>
    public partial class GD_Show : Page
    {
        public string num;
        public GD_Show()
        {
            InitializeComponent();

        }

        public GD_Show(DataRow dr)
        {
            InitializeComponent();
            show(dr);
        }

        public void show(DataRow dr)
        {
            SQLCon sqlcon = new SQLCon();
            DataSet buy_ds = sqlcon.GetDataSet(string.Format("select 昵称 from 会员表 where 用户号='{0}'", dr[1].ToString()));
            DataRow buy_dr = buy_ds.Tables[0].Rows[0];
            label.Content = dr[2];
            label1.Content = dr[6];
            label2.Content = "类型：" + dr[4];
            label3.Content = "价格：" + dr[3] + "元";
            label4.Content = "卖家：" + buy_dr[0];
            image.Source = new BitmapImage(new Uri(dr[5].ToString(), UriKind.RelativeOrAbsolute));
            num = dr[0].ToString();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string sql = string.Format("delete from 商品表 where 商品号='{0}'", num);
            SQLCon sqlcon = new SQLCon();
            sqlcon.UpdateSql(sql);
            button.IsEnabled = false;
        }
    }
}
