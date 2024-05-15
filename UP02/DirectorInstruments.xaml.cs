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
    /// Логика взаимодействия для DirectorInstruments.xaml
    /// </summary>
    public partial class DirectorInstruments : Page
    {
        INstrumentsTableAdapter instruments = new INstrumentsTableAdapter();
        public DirectorInstruments()
        {
            InitializeComponent();
            CLEANTXT();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Naim.Text.Length != 0 && Desc.Text.Length != 0 && Type.Text.Length != 0 && Iznos.Text.Length != 0 && Post.Text.Length != 0 && Date.Text.Length != 0 && Count.Text.Length != 0)
            {
                instruments.InsertQuery(Naim.Text,
                    Desc.Text,
                    Convert.ToInt32(Type.Text),
                    Iznos.Text,
                    Convert.ToInt32(Post.Text),
                    Convert.ToDateTime(Date.Text),
                    Convert.ToInt32(Count.Text));

                CLEANTXT();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        private void InsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(InsGrid.SelectedItem != null)
            {
                Naim.Text = (InsGrid.SelectedItem as DataRowView).Row[1].ToString();
                Desc.Text = (InsGrid.SelectedItem as DataRowView).Row[2].ToString();
                Type.Text = (InsGrid.SelectedItem as DataRowView).Row[3].ToString();
                Iznos.Text = (InsGrid.SelectedItem as DataRowView).Row[4].ToString();
                Post.Text = (InsGrid.SelectedItem as DataRowView).Row[5].ToString();
                Date.Text = (InsGrid.SelectedItem as DataRowView).Row[6].ToString();
                Count.Text = (InsGrid.SelectedItem as DataRowView).Row[7].ToString();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Naim.Text.Length != 0 && Desc.Text.Length != 0 && Type.Text.Length != 0 && Iznos.Text.Length != 0 && Post.Text.Length != 0 && Date.Text.Length != 0 && Count.Text.Length != 0)
            {
                instruments.UpdateQuery(Naim.Text,
                    Desc.Text,
                    Convert.ToInt32(Type.Text),
                    Iznos.Text,
                    Convert.ToInt32(Post.Text),
                    Convert.ToDateTime(Date.Text),
                    Convert.ToInt32(Count.Text),
                    Convert.ToInt32((InsGrid.SelectedItem as DataRowView).Row[0].ToString()));
                    CLEANTXT();

            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (InsGrid.SelectedItem != null)
            {
                instruments.DeleteQuery(Convert.ToInt32((InsGrid.SelectedItem as DataRowView).Row[0]));

                CLEANTXT();

            }
            else
            {
                MessageBox.Show("Запись не была выбрана");
            }
        }

        private void CLEANTXT()
        {
            Naim.Clear();
            Desc.Clear();
            Type.Clear();
            Iznos.Clear();
            Post.Clear();
            Date.Clear();
            Count.Clear();

            InsGrid.ItemsSource = instruments.GetData();

        }
    }
}
