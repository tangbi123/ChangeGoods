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
    /// Good.xaml 的交互逻辑
    /// </summary>
    public partial class Good : Page
    {
        public Good()
        {
            InitializeComponent();
        }

        public Good(DataRow dr)
        {
            InitializeComponent();
            GetGoodInfo(dr);
        }

        public void GetGoodInfo(DataRow dr)
        {

            //MessageBox.Show(dr[0].ToString());
            商品号.Text = "商品号：" + dr[0].ToString();
            商品名称.Text = "商品名称：" + dr[2].ToString();
            价格.Content = dr[3] + "￥";
            图片.Source = new BitmapImage(new Uri(dr[5].ToString(), UriKind.RelativeOrAbsolute));
            //new Uri(dr[5].ToString(), UriKind.Relative)
            商品信息.Text = "商品信息：" + dr[6].ToString();
        }
    }
}
