using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace 交易平台.zfw
{
    /// <summary>
    /// Send.xaml 的交互逻辑
    /// </summary>
    public partial class Send : UserControl
    {
        public Send()
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

                Image img = new Image();

                BitmapImage bImg = new BitmapImage();

                img.IsEnabled = true;

                bImg.BeginInit();

                bImg.UriSource = new Uri(filepath, UriKind.Relative);

                bImg.EndInit();

                img.Source = bImg;

                if (bImg.Height > 100 || bImg.Width > 100)

                {

                    img.Height = bImg.Height * 0.5;

                    img.Width = bImg.Width * 0.5;

                }

                img.Stretch = Stretch.Uniform;  //图片缩放模式

                new InlineUIContainer(img, richTextBox.Selection.Start); //插入图片到选定位置
            }
        }
    }
}
