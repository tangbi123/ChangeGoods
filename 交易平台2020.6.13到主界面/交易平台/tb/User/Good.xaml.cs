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
using 交易平台.yuhe;


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
            商品号.Text = /*"商品号：" + */dr[0].ToString();
            商品名称.Text =  dr[2].ToString();
            价格.Content = "单价:" + dr[3] + "￥";
            图片.Source = new BitmapImage(new Uri(dr[5].ToString(), UriKind.RelativeOrAbsolute));
            //new Uri(dr[5].ToString(), UriKind.Relative)
            商品信息.Text = "商品信息：" + dr[6].ToString();
        }

        //<<<<<<< HEAD
        /// <summary>
        /// 加入购物车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addBtn(object sender, RoutedEventArgs e)
        {
            string sno = 商品号.Text;
            string uno = SQLCon.num;

            string sql = string.Format("insert into 购物车 values ('{0}', '{1}')", uno, sno);

            int row = TbSql.UpdateSql(sql);
            if (row > 0) MessageBox.Show("添加成功!!");
            //else MessageBox.Show("添加失败!!");
        }
//=======
/// <summary>
/// 结算函数
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void Click_pay(object sender, RoutedEventArgs e)
        {
            //this.Content = new Frame();
            //var pay = new consume();
            //pay.ShowsNavigationUI;
            //Content = new consume();
            Window w = new Window();
            w.Width = 800;
            consume pay = new consume();
            w.Content = pay;
            pay.Detail_Image.Source = 图片.Source;
            pay.ItemDetail_Textbox.Text = 商品信息.Text;
            //pay.Type_TextBlock.Text = 
            pay.ItemID_TextBlock.Text = 商品号.Text;
            pay.ItemName_TextBox.Text = 商品名称.Text;
            pay.price_TextBox.Text = 价格.Content.ToString();
            w.Show();

//>>>>>>> 352b4b8caef75cc90c98ef5eb53f6d5f585694d5
        }
    }
}
