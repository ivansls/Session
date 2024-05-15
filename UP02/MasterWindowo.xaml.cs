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
using System.Windows.Shapes;

namespace UP02
{
    /// <summary>
    /// Логика взаимодействия для MasterWindowo.xaml
    /// </summary>
    public partial class MasterWindowo : Window
    {
        public MasterWindowo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameM.Content = new MasterPage();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameM.Content = new MasterIng();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FrameM.Content = new MasterUkr();
        }
    }
}
