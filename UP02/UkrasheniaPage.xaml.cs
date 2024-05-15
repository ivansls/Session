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
    /// Логика взаимодействия для UkrasheniaPage.xaml
    /// </summary>
    public partial class UkrasheniaPage : Page
    {
        newUkrTableAdapter ukr = new newUkrTableAdapter();
        public UkrasheniaPage()
        {
            InitializeComponent();
            CLEANTEXT();
        }

        private void CLEANTEXT()
        {
            Article.Clear();
            Name.Clear();
            EdIzm.Clear();
            CountUkr.Clear();
            TypeUkr.Clear();
            PriceUkr.Clear();
            WeightUkr.Clear();
            UkrGrid.ItemsSource = ukr.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Article.Text.Length != 0 &&
                Name.Text.Length != 0 &&
                EdIzm.Text.Length != 0 &&
                CountUkr.Text.Length != 0 &&
                TypeUkr.Text.Length != 0 &&
                PriceUkr.Text.Length != 0 &&
                WeightUkr.Text.Length != 0)
            {
                ukr.InsertQuery(
                   Convert.ToInt32(Article.Text),
                    Name.Text,
                    EdIzm.Text,
                    Convert.ToByte(CountUkr.Text),
                    TypeUkr.Text,
                    PriceUkr.Text,
                    WeightUkr.Text
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
            if (Article.Text.Length != 0 &&
                Name.Text.Length != 0 &&
                EdIzm.Text.Length != 0 &&
                CountUkr.Text.Length != 0 &&
                TypeUkr.Text.Length != 0 &&
                PriceUkr.Text.Length != 0 &&
                WeightUkr.Text.Length != 0)
            {
                ukr.UpdateQuery(
                   Convert.ToInt32(Article.Text),
                    Name.Text,
                    EdIzm.Text,
                    Convert.ToByte(CountUkr.Text),
                    TypeUkr.Text,
                    PriceUkr.Text,
                    WeightUkr.Text,
                    Convert.ToInt32(Article.Text)
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
            if(UkrGrid.SelectedItem != null)
            {
                ukr.DeleteQuery(Convert.ToInt32((UkrGrid.SelectedItem as DataRowView).Row[0]));
                CLEANTEXT();
            }
            else
            {
                MessageBox.Show("Запись не выбрана");
            }
        }

        private void UkrGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(UkrGrid.SelectedItem != null)
            {
                Article.Text = ((UkrGrid.SelectedItem as DataRowView).Row[0]).ToString();
                Name.Text = ((UkrGrid.SelectedItem as DataRowView).Row[1]).ToString();
                EdIzm.Text = ((UkrGrid.SelectedItem as DataRowView).Row[2]).ToString();
                CountUkr.Text = ((UkrGrid.SelectedItem as DataRowView).Row[3]).ToString();
                TypeUkr.Text = ((UkrGrid.SelectedItem as DataRowView).Row[4]).ToString();
                PriceUkr.Text = ((UkrGrid.SelectedItem as DataRowView).Row[5]).ToString();
                WeightUkr.Text = ((UkrGrid.SelectedItem as DataRowView).Row[6]).ToString();
            }
        }
    }
}
