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
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        newUsersTableAdapter users = new newUsersTableAdapter();
        public RegWindow()
        {
            InitializeComponent();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginReg.Text.Length != 0 && PasswordReg.Text.Length != 0)
            {
                List<UserInfo> usersList = new List<UserInfo>();
                var temp = users.GetData().Rows;
                for (int i = 0; i < temp.Count; i++)
                {
                    usersList.Add(new UserInfo(temp[i][3].ToString(), temp[i][4].ToString(), temp[i][5].ToString()
                            ));
                }
                UserInfo contains = usersList.FirstOrDefault(item => item.login == LoginReg.Text);

                if(contains == null)
                {
                    string password = PasswordReg.Text;
                    if(password.Length > 20 || password.Length < 5)
                    {
                        MessageBox.Show("Пароль должен содержать от 5 до 20 символо");
                    }
                    else
                    {
                        if (password.Contains(LoginReg.Text))
                        {
                            MessageBox.Show("Пароль не должен содержать логин");
                        }
                        else
                        {
                            if(password.Any(char.IsUpper) && password.Any(char.IsLower))
                            {
                                users.InsertQuery(null, null, null, LoginReg.Text, password, "Клиент");
                                MessageBox.Show("Вы зарегистрированы");
                                Auth window = new Auth();
                                window.Show();
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Пароль должен содержать заглавные и строчные буквы");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь с таким логином уже существует");
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }

    
    }
}
