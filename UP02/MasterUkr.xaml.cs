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
using UP02.UpDbDataSetTableAdapters;

namespace UP02
{
    /// <summary>
    /// Логика взаимодействия для MasterUkr.xaml
    /// </summary>
    public partial class MasterUkr : Page
    {
        newUkrTableAdapter k = new newUkrTableAdapter();
        public MasterUkr()
        {
            InitializeComponent();
            UkrGrid.ItemsSource = k.GetData();
        }
    }
}
