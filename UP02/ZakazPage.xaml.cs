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
using System.Xml.Linq;
using UP02.UpDbDataSetTableAdapters;

namespace UP02
{
    /// <summary>
    /// Логика взаимодействия для ZakazPage.xaml
    /// </summary>
    public partial class ZakazPage : Page
    {

        OrdersTableAdapter ord = new OrdersTableAdapter();
        IzdelieTableAdapter izdelie = new IzdelieTableAdapter();
        public ZakazPage()
        {
            InitializeComponent();
            CLEANTXT();
        }
 

        private void CLEANTXT()
        {
            ComboBX.ItemsSource = izdelie.GetData();
            ComboBX.DisplayMemberPath = "izdelie_id";
            OrderGrid.ItemsSource = ord.GetDataBy3(UserLogin.LoggedInUser);
            Nubmer_date.Text = "";
            Name_Order.Text = "";
            Price.Text = "";
            Zakaz.Text = "";
            DatePlan.Text = "";
            Manager.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(ComboBX.SelectedItem != null)
            {
                Random random = new Random();
                string nameOrd = "";
                nameOrd = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + random.Next(1, 100); ;
                ord.InsertQuery(
                    1, DateTime.Now, nameOrd, Convert.ToInt32((ComboBX.SelectedItem as DataRowView).Row[0]), UserLogin.LoggedInUser, UserLogin.LoggedInUser, 5000, null, null
                    );
                CLEANTXT();
            }
            else
            {
                MessageBox.Show("Изделие не выбрано");
            }
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(OrderGrid.SelectedItem != null)
            {
                ord.DeleteQuery(Convert.ToInt32((OrderGrid.SelectedItem as DataRowView).Row[0]));
                CLEANTXT();
            }
            else
            {
                MessageBox.Show("Запись не выбрана");
            }
        }

        private void OrderGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(OrderGrid.SelectedItem != null)
            {
                Nubmer_date.Text = ((OrderGrid.SelectedItem as DataRowView).Row[1]).ToString();
                Name_Order.Text = ((OrderGrid.SelectedItem as DataRowView).Row[2]).ToString();
                Price.Text = ((OrderGrid.SelectedItem as DataRowView).Row[7]).ToString();
                Zakaz.Text = ((OrderGrid.SelectedItem as DataRowView).Row[4]).ToString();
                DatePlan.Text = ((OrderGrid.SelectedItem as DataRowView).Row[8]).ToString();
                Manager.Text = ((OrderGrid.SelectedItem as DataRowView).Row[6]).ToString();
            }
        }
    }
}
