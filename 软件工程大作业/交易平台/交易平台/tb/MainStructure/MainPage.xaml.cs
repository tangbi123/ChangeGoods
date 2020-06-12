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
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_CLick(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            if (btn.Tag != null)
            {
                //frame1.Source = new Uri("/Examples/" + btn.Tag + ".xaml", UriKind.Relative);
                MessageBox.Show(btn.Content.ToString());
            }
        }
    }
}
