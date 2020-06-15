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
        public Browse()
        {
            InitializeComponent();
            Show();
        }

        public void Show()
        {
            string sqlstr = string.Format("select * from 商品表");
            DataSet ds = TbSql.GetDataSet(sqlstr);

            int row = ds.Tables[0].Rows.Count;
            for (int i = 0; i < row; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                listBox.Items.Add(new Frame().Content = new Good(dr));
               // listBox.Items.Add(new Separator());
            }
        }

    }
}
