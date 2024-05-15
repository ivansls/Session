using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    /// Логика взаимодействия для DirectorWindoow.xaml
    /// </summary>
    public partial class DirectorWindoow : Window
    {
        INstrumentsTableAdapter nstrumentsTableAdapter = new INstrumentsTableAdapter();
        newIngTableAdapter newIngTableAdapter = new newIngTableAdapter();
        public DirectorWindoow()
        {
            InitializeComponent();

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameLay.Content = new DirectorInstruments();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameLay.Content = new IngridientsPage();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FrameLay.Content = new UkrasheniaPage();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string reportContent = "";
            var temp = nstrumentsTableAdapter.GetData().Rows;
            for (int i = 0; i < temp.Count; i++)
            {
                reportContent += "Имя: " + temp[i][1].ToString() +" " + "Описание: "+ temp[i][2]
                    +" " + "Тип: " +  temp[i][3] + " " + "Износ: " +  temp[i][4] + " " + "Поставщик: " +  temp[i][5] + " " + "Дата: " + temp[i][6] + " "+ "Количество:" + temp[i][7] + "\n";
            }

            string filePath = @"C:\Users\User\Desktop\Otchet.txt";

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(reportContent);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string reportContent = "";
            var temp = newIngTableAdapter.GetData().Rows;
            for (int i = 0; i < temp.Count; i++)
            {
                reportContent += "Article: " + temp[i][0].ToString() + " " + "Имя: " + temp[i][1]
                    + " " + "Единица измерения: " + temp[i][2] + " " + "Количество: " + temp[i][3] + " " + "Тип: " + temp[i][4] + " " + "Цена: " + temp[i][5] + " " + "Гост:" + temp[i][6] + " " + "Фасовка: " + temp[i][7] +  "\n";
            }

            string filePath = @"C:\Users\User\Desktop\OtchetIng.txt";

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(reportContent);
            }
        }
    }
}
