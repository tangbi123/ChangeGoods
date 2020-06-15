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
    /// OrderList.xaml 的交互逻辑
    /// </summary>
    public partial class OrderList : Page
    {
        public OrderList()
        {
            InitializeComponent();
            GetOrders();

            lb.MouseDoubleClick += Lb_MouseDoubleClick;
        }

        private void Lb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Object o = lb.SelectedItem;
            Order1 order=o as Order1;

            if (order == null) return;

            this.NavigationService.Navigate ( new OrderDetail(order.买ID, order.卖ID, order.goodno));
        }

        public void GetOrders()
        {
            string sql1 = string.Format("select * from 订单表 where 卖家id='{0}' ", SQLCon.num);
            DataSet ds1 = TbSql.GetDataSet(sql1);

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                DataRow dr1 = ds1.Tables[0].Rows[i];

                lb.Items.Add(new Frame().Content = new Order1(ds1.Tables[0].Rows[i]));
            }


            string sql2= string.Format("select * from 订单表 where 买家id='{0}' ", SQLCon.num);
            DataSet ds2 = TbSql.GetDataSet(sql2);

            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                DataRow dr1 = ds1.Tables[0].Rows[i];

                lb.Items.Add(new Frame().Content = new Order1(ds2.Tables[0].Rows[i]));
            }
        }
    }
}
