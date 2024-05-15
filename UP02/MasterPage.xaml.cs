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
using UP02.UpDbDataSetTableAdapters;

namespace UP02
{
    /// <summary>
    /// Логика взаимодействия для MasterPage.xaml
    /// </summary>
    public partial class MasterPage : Page
    {
        IzdelieTableAdapter izdelie = new IzdelieTableAdapter();
        public MasterPage()
        {
            InitializeComponent();
            CLEANTEXT();
        }

        private void CLEANTEXT()
        {
            IzdelieGrid.ItemsSource = izdelie.GetData();
            IzName.Clear();
            IzSize.Clear();
        }

        private void IzdelieGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(IzdelieGrid.SelectedItem != null)
            {
                IzName.Text = ((IzdelieGrid.SelectedItem as DataRowView).Row[1]).ToString();
                IzSize.Text = ((IzdelieGrid.SelectedItem as DataRowView).Row[2]).ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(IzName.Text.Length != 0 && IzSize.Text.Length != 0)
            {
                izdelie.InsertQuery(
                    IzName.Text, IzSize.Text
                    );
                CLEANTEXT();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (IzName.Text.Length != 0 && IzSize.Text.Length != 0)
            {
                izdelie.UpdateQuery(
                    IzName.Text, IzSize.Text,Convert.ToInt32((IzdelieGrid.SelectedItem as DataRowView).Row[0])
                    );
                CLEANTEXT();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(IzdelieGrid.SelectedItem != null)
            {
                izdelie.DeleteQuery(Convert.ToInt32((IzdelieGrid.SelectedItem as DataRowView).Row[0]));
                CLEANTEXT();
            }
            else
            {
                MessageBox.Show("Запись не выбрана");
            }
        }
    }
}
