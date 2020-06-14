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
using 交易平台.tb;
using 交易平台.tb.MainStructure;
using 交易平台.tb.User;

namespace 交易平台.zfw
{
    /// <summary>
    /// Browse.xaml 的交互逻辑
    /// </summary>
    public partial class Browse : Page
    {
        private MainPage parentpage;
        public Browse()
        {
            InitializeComponent();
            Show();
        }

        public MainPage ParentWindow
        {
            get { return parentpage; }
            set { parentpage = value; }
        }

        public void Show()
        {
            //string sqlstr = string.Format("select * from 帖子表");
            //DataSet ds_1 = TbSql.GetDataSet(sqlstr);

            //int row = ds_1.Tables[0].Rows.Count;
            //for (int i = 0; i < row; i++)
            //{
            //DataRow dr_1 = ds_1.Tables[0].Rows[i];
            //DataSet ds_2 = TbSql.GetDataSet(string.Format("select 昵称 from 会员表 where 用户号='{0}'", dr_1[2]));
            //DataRow dr_2 = ds_2.Tables[0].Rows[0];
            //string name = dr_2[0].ToString();
            //ListBoxItem lb_1 = new ListBoxItem();
            //lb_1.FontSize = 16;
            //lb_1.Content = string.Format("发帖人：{0}", name);
            //lb_1.Visibility = Visibility.Visible;
            //listBox.Items.Add(lb_1);
            //ListBoxItem con = new ListBoxItem();
            //con.FontSize = 20;
            //con.Content = ds_1.Tables[0].Rows[i][3];
            //listBox.Items.Add(con);
            //listBox.Items.Add(new Separator());
            //}
            listBox.Items.Add(new Frame().Content = new Good());
            listBox.Items.Add(new Separator());
            listBox.Items.Add(new Frame().Content = new Good());
            listBox.Items.Add(new Separator());
            listBox.Items.Add(new Frame().Content = new Good());
            listBox.Items.Add(new Separator());
        }

    }
}
