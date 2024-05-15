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
using System.Windows.Shapes;
using UP02.UpDbDataSetTableAdapters;

namespace UP02
{
    /// <summary>
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        OrdersTableAdapter orders = new OrdersTableAdapter();
        public ManagerWindow()
        {
            InitializeComponent();

            CLEANTXT();


        }

        private void OrderGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(OrderGrid.SelectedItem != null)
            {
                DatePlan.Text = (OrderGrid.SelectedItem as DataRowView).Row[8].ToString();
            }
        }

        private void CLEANTXT()
        {
            OrderGrid.ItemsSource = orders.GetData();
            DatePlan.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(DatePlan.Text.Length != 0)
            {
                orders.UpdateQuery1(UserLogin.LoggedInUser, Convert.ToDateTime(DatePlan.Text), Convert.ToInt32((OrderGrid.SelectedItem as DataRowView).Row[0]));
                CLEANTXT();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(OrderGrid.SelectedItem != null)
            {
                orders.DeleteQuery(Convert.ToInt32((OrderGrid.SelectedItem as DataRowView).Row[0]));
                CLEANTXT();
            }
            else
            {
                MessageBox.Show("Запись не выбрана");
            }
        }
    }
}
