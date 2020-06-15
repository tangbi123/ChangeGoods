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

namespace 交易平台.tb.User
{
    /// <summary>
    /// OrderDetail.xaml 的交互逻辑
    /// </summary>
    public partial class OrderDetail : Page
    {
        public OrderDetail()
        {
            InitializeComponent();
        }

        public OrderDetail(string 买ID,string 卖ID, string goodno)
        {
            InitializeComponent();
            string sqlstr = string.Format("select * from 商品表 where 商品号 = '{0}'", goodno);

            DataSet ds = TbSql.GetDataSet(sqlstr);

            f1.NavigationService.Navigate(new UserDetail(买ID));
            f2.NavigationService.Navigate(new GouwuGood(ds.Tables[0].Rows[0]));
            f3.NavigationService.Navigate(new UserDetail(卖ID));
            //f1.Source = new UserDetail(买ID);
            ////f2.Source = new GouwuGood();
            //f1.Source = new UserDetail(卖ID);
        }
    }
}
