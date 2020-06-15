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
    /// Order1.xaml 的交互逻辑
    /// </summary>
    public partial class Order1 : Page
    {
        public string 买ID;
        public string 卖ID;
        public string goodno;
        public Order1()
        {
            InitializeComponent();
        }

        public Order1(DataRow dr)
        {
            InitializeComponent();
            GetGOrderInfo(dr);
        }

        /// <summary>
        /// 输入是 订单的 查询结果
        /// </summary>
        /// <param name="dr"></param>
        public void GetGOrderInfo(DataRow dr)
        {
            买ID = dr[0].ToString();
            卖ID = dr[1].ToString();
            goodno = dr[2].ToString();

            string sqlstr1 = string.Format("select * from 商品表 where 商品号 ='{0}'",goodno); ;
            DataRow goodDR = TbSql.GetDataSet(sqlstr1).Tables[0].Rows[0];
            
            // get  商品信息 
            商品号.Text = "商品号：" + goodDR[0].ToString();
            商品名称.Text = "商品名称：" + goodDR[2].ToString();
            价格.Content = "单价:" + goodDR[3] + "￥";
            图片.Source = new BitmapImage(new Uri(goodDR[5].ToString(), UriKind.RelativeOrAbsolute));

            //订单 信息
            时间.Text = "时间：" + dr[5].ToString();
            订单状态.Text = "订单状态：" + dr[6].ToString();
                
        }
    }
}
