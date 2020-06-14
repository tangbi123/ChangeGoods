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
            //记得这个函数
            GetGoods();
        }

        public void GetGoods()
        {
            string sqlstr = string.Format("select * from 商品表");

            DataSet ds = TbSql.GetDataSet(sqlstr);//DataSet 是查询结果

            //DataRow drs = ds.Tables[0].Rows[0];
            
            //循环  将每一个商品记录 加入 listbox 里面
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                lb.Items.Add(new Frame().Content = new Good(ds.Tables[0].Rows[i]));
        }
    }
}
