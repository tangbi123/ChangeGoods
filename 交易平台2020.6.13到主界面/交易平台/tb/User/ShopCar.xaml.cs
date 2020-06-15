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
        private bool guanli = false;
        public ShopCar()
        {
            InitializeComponent();
            //记得这个函数
            GetGoods();
            l.Content = "";
        }

        /// <summary>
        /// 获取 购物车库 里的 信息
        /// </summary>
        public void GetGoods()
        {
            string sql1 = string.Format("select 商品号 from 购物车 where 用户号='{0}'", SQLCon.num);
            DataSet ds1 = TbSql.GetDataSet(sql1);

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                DataRow dr1 = ds1.Tables[0].Rows[i];

                string sqlstr = string.Format("select * from 商品表 where 商品号= '{0}'",dr1[0] );

                DataSet ds2 = TbSql.GetDataSet(sqlstr);//DataSet 是查询结果

                //DataRow drs = ds.Tables[0].Rows[0];

                //循环  将每一个商品记录 加入 listbox 里面
                for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                {
                    lb.Items.Add(new Frame().Content = new GouwuGood(ds2.Tables[0].Rows[j]));
                    //Separator s = new Separator();
                    //s.Height = 1;
                    //lb.Items.Add(s);
                }
            }
            //lb.Items.Add(new CheckBox().Content = new Frame().Content = new GouwuGood());
        }

        /// <summary>
        /// 管理 btn的 事件函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void guanli_btn(object sender, RoutedEventArgs e)
        {
            if (guanli == false)
            {
                l.Content = "双击删除";
                guanli = true;
                lb.MouseDoubleClick += Lb_MouseLeftButtonDown;

                guanliBtn.Content = "完成";
            }
            else
            {
                l.Content = "";
                guanli = false;
                lb.MouseDoubleClick -= Lb_MouseLeftButtonDown;

                guanliBtn.Content = "管理";
            }
        }

        /// <summary>
        /// 双击 listbox 的 item的事件函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
            Object o = lb.SelectedItem;
            //MessageBox.Show(o.Name);

            GouwuGood g = o as GouwuGood;
            if (g == null) return;

            string sql = string.Format("delete from 购物车 where 商品号='{0}' and 用户号 ='{1}'",g.goodno,SQLCon.num);

            int row = TbSql.UpdateSql(sql);
            if (row > 0) MessageBox.Show("删除成功!!!");

            //最后删除
            if (o == null) return;
                lb.Items.Remove(o);
        }

        /// <summary>
        /// 这里是 结算的 接口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void js_btn(object sender, RoutedEventArgs e)
        {

        }
    }
}
