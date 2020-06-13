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

namespace 交易平台.tb.MainStructure
{
    /// <summary>
    /// MainPage.xaml 的交互逻辑
    /// </summary>
    public partial class MainPage : Window
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_CLick(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            MessageBox.Show(btn.Content.ToString());

            Uri source = new Uri(btn.Tag.ToString(), UriKind.Relative);

            //调试 是否有这个source
            Object obj = null;
            try
            {
                obj = Application.LoadComponent(source);
            }
            catch {

                MessageBox.Show("未找到" + source.OriginalString);
                return;
            }

            Page p = obj as Page;
            if(p!=null)
            {
                frame1.NavigationService.RemoveBackEntry();
                frame1.Source = source;
                return;
            }

            Window w = obj as Window;
            if (w != null)
            {
                w.Owner = this;
                w.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                w.ShowDialog();
            }
            else MessageBox.Show("无法将对象转化为Window类型");

        }

       
    }
}
