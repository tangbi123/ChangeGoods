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
    /// ShopCar.xaml 的交互逻辑
    /// </summary>
    public partial class ShopCar : Page
    {
        public ShopCar()
        {
            InitializeComponent();
            GetGoods();
        }

        public void GetGoods()
        {
            string sqlstr = string.Format("select * from 商品表");
            DataSet ds = TbSql.GetDataSet(sqlstr);

            DataRow drs = ds.Tables[0].Rows[0];
            // MessageBox.Show(drs[0].ToString() + drs[1].ToString());
            //lb.Items.Add(new Frame().Content = new Good(drs));

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                lb.Items.Add(new Frame().Content = new Good(ds.Tables[0].Rows[i]));
        }
    }
}
