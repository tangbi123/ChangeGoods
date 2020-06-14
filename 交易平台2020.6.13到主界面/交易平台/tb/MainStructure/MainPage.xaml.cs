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
using 交易平台.tb;
using 交易平台.yuhe;

namespace 交易平台.tb.MainStructure
{
    /// <summary>
    /// MainPage.xaml 的交互逻辑
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_CLick(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            if (btn == null) return;

            //MessageBox.Show(btn.Content.ToString());
            Uri source = new Uri(btn.Tag.ToString(), UriKind.Relative);

            //测试 路径设置是否正确
            Object obj = null;
            try {
                obj = Application.LoadComponent(source);

            }
            catch
            {
                MessageBox.Show("未找到\t" + source.OriginalString);
                return;
            }

            Page p = obj as Page;
            if(p!=null)
            {
                //MessageBox.Show(source.OriginalString);
                //frame1.NavigationService.RemoveBackEntry();
                frame1.Source = source;
                return;
            }
            //else MessageBox.Show("无法转换 成 Page");

            Window w = obj as Window;
            if (w != null)
            {
                //w.Owner = this;
                w.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                w.ShowDialog();
            }
            else MessageBox.Show("无法转换 成 Window");
        }
    }
}
