using Microsoft.Win32;
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

namespace 交易平台.zfw
{
    /// <summary>
    /// upload.xaml 的交互逻辑
    /// </summary>
    public partial class upload : Page
    {
        public upload()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string filepath = "";

            OpenFileDialog openfilejpg = new OpenFileDialog();

            openfilejpg.Filter = "jpg图片(*.jpg)|*.jpg|gif图片(*.gif)|*.gif";

            openfilejpg.FilterIndex = 0;

            openfilejpg.RestoreDirectory = true;

            openfilejpg.Multiselect = false;

            if (openfilejpg.ShowDialog() == true)

            {

                filepath = openfilejpg.FileName;

                BitmapImage bImg = new BitmapImage();

                image1.IsEnabled = true;

                bImg.BeginInit();

                bImg.UriSource = new Uri(filepath, UriKind.RelativeOrAbsolute);

                bImg.EndInit();

                image1.Source = bImg;
        }
    }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            label4.Visibility = Visibility.Hidden;
            string user_num = SQLCon.num;
            string good_num = "";
            string name = textBox1.Text;
            string text = textBox.Text;
            string imgpath = "";
            string price = textBox2.Text;
            string type = comboBox.Text;
            if (name.Equals(""))
            {
                label4.Visibility = Visibility.Visible;
                return;
            }
            if (image1.Source != null)
                imgpath = image1.Source.ToString();
            string sql1 = "select top 1 商品号 from 商品表 order by 商品号 desc";
            DataSet ds = TbSql.GetDataSet(sql1);
            if (ds.Tables[0].Rows.Count>0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                good_num = (Int32.Parse(dr[0].ToString()) + 1).ToString();
            }
            else
            {
                good_num = "100001";
            }
            if (price.Equals(""))
                price = "1";
            
            SQLCon sqlcon = new SQLCon();
            //MessageBox.Show(good_num + "\n" + user_num + "\n" + name + "\n" + price + "\n" + type + "\n" + imgpath + "\n" + text);
            string sql = string.Format("insert into 商品表 values('{0}','{1}','{2}',{3},'{4}','{5}','{6}')",
                good_num, user_num, name, price, type, imgpath, text);
            bool f = sqlcon.Upload(sql);
            if (f)
            {
                MessageBox.Show("上传成功！");
            }

        }
    }
}
