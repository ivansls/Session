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
using UP02.UpDbDataSetTableAdapters;


namespace UP02
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    /// 
    
    public partial class Auth : Window
    {
        newUsersTableAdapter users = new newUsersTableAdapter();
        public Auth()
        {
            InitializeComponent();
        }

        private void AuthBt_Click(object sender, RoutedEventArgs e)
        {

            if(LoginTx.Text.Length != 0 && PasswordTx.Text.Length != 0)
            {
                List<UserInfo> userInfos = new List<UserInfo>();
                var temp = users.GetData().Rows;
                for (int i = 0; i < temp.Count; i++)
                {
                    userInfos.Add(new UserInfo(temp[i][3].ToString(), temp[i][4].ToString(), temp[i][5].ToString()
                        ));
                }

                UserInfo contains = userInfos.FirstOrDefault(item => item.login == LoginTx.Text);

                if (contains != null)
                {
                    if (PasswordTx.Text == contains.password)
                    {
                        UserLogin.LoggedInUser = contains.login;
                        switch (contains.role)
                        {
                            case "Клиент":
                                ClientWindow wind = new ClientWindow();
                                wind.Show();
                                Close();
                                break;
                            case "Менеджер":
                                ManagerWindow managerWindow = new ManagerWindow();
                                managerWindow.Show();
                                Close();
                                break;
                            case "Мастер":
                                MasterWindowo windowo = new MasterWindowo();
                                windowo.Show();
                                Close();
                                break;
                            case "Директор":
                                DirectorWindoow windoow = new DirectorWindoow();
                                windoow.Show();
                                Close();
                                break;

                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Такого логина не существует");
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }

            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegWindow window = new RegWindow();
            window.Show();
            Close();
        }
    }
}
