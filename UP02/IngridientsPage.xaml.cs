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
    public partial class IngridientsPage : Page
    {
        newIngTableAdapter ing = new newIngTableAdapter();
        public IngridientsPage()
        {
            InitializeComponent();
            CLEANTXT();
        }


        private void CLEANTXT()
        {
            Iarticle.Clear();
            Iname.Clear();
            ied.Clear();
            icount.Clear();
            itype.Clear();
            iprice.Clear();
            igost.Clear();
            ifas.Clear();
            InGrid.ItemsSource = ing.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Iname.Text.Length != 0 &&
                ied.Text.Length != 0 &&
                icount.Text.Length != 0 &&
                itype.Text.Length != 0 &&
                iprice.Text.Length != 0 &&
                igost.Text.Length != 0 &&
                ifas.Text.Length != 0 && Iarticle.Text.Length != 0)
            {
                ing.InsertQuery(
                  Convert.ToInt32(Iarticle.Text),
                   Iname.Text,
                   ied.Text,
                   icount.Text,
                   itype.Text,
                   iprice.Text,
                   igost.Text,
                   ifas.Text
                    );

                CLEANTXT();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Iname.Text.Length != 0 &&
                ied.Text.Length != 0 &&
                icount.Text.Length != 0 &&
                itype.Text.Length != 0 &&
                iprice.Text.Length != 0 &&
                igost.Text.Length != 0 &&
                ifas.Text.Length != 0 && Iarticle.Text.Length != 0)
            {
                ing.UpdateQuery(
                   Convert.ToInt32(Iarticle.Text),
                   Iname.Text,
                   ied.Text,
                   icount.Text,
                   itype.Text,
                   iprice.Text,
                   igost.Text,
                   ifas.Text,
                   Convert.ToInt32((InGrid.SelectedItem as DataRowView).Row[0])
                    );

                CLEANTXT();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (InGrid.SelectedItem != null)
            {
                ing.DeleteQuery(Convert.ToInt32((InGrid.SelectedItem as DataRowView).Row[0]));

                CLEANTXT();

            }
            else
            {
                MessageBox.Show("Запись не была выбрана");
            }
        }

        private void InGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(InGrid.SelectedItem != null)
            {
                Iarticle.Text = ((InGrid.SelectedItem as DataRowView).Row[0]).ToString();
                Iname.Text = ((InGrid.SelectedItem as DataRowView).Row[1]).ToString();
                ied.Text = ((InGrid.SelectedItem as DataRowView).Row[2]).ToString();
                icount.Text = ((InGrid.SelectedItem as DataRowView).Row[3]).ToString();
                itype.Text = ((InGrid.SelectedItem as DataRowView).Row[4]).ToString();
                iprice.Text = ((InGrid.SelectedItem as DataRowView).Row[5]).ToString();
                igost.Text = ((InGrid.SelectedItem as DataRowView).Row[6]).ToString();
                ifas.Text = ((InGrid.SelectedItem as DataRowView).Row[7]).ToString();
            }
         
        }
    }
}
