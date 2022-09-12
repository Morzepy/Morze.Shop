using Morze.Shop.Db_context;
using System.Linq;
using System.Windows;

namespace Morze.Shop.GUI_WPF_Application
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            textBox_FirstName.MaxLength = Settings.lengthNchar;
            textBox_LastName.MaxLength = Settings.lengthNchar;
            passwordBox.MaxLength = Settings.lengthNchar;
            passwordBox2.MaxLength = Settings.lengthNchar;
        }

        private void Button_Click_Sign_Up(object sender, RoutedEventArgs e)
        {
            Sign_Up();
        } 
        private void Button_Click_MainWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //Метод Регистрации пользователя
        private void Sign_Up()
        {
            //Проверка на пустые поля, которые не заполнил пользователь
            if ((textBox_FirstName.Text.Trim().Length > 0) && (textBox_LastName.Text.Trim().Length > 0) &&
               (textBox_login.Text.Trim().Length > 0) && (passwordBox.Password.Trim().Length > 0) &&
               (passwordBox2.Password.Trim().Length > 0))
            {
                //Проверка совпадает ли проверка пароля
                if (passwordBox.Password == passwordBox2.Password)
                {
                    using (var context = new MyDbContext())
                    {
                        var Login = textBox_login.Text;
                        //Проверка в базе данных если ли пользователь с таким же login
                        bool isLoginFound = context.Clients.Any(client => client.ClientLogin == Login);
                        if (!isLoginFound)
                        {
                            var client = new Client()
                            {
                                ClientFirstName = textBox_FirstName.Text,
                                ClientLastName = textBox_LastName.Text,
                                ClientLogin = textBox_login.Text,
                                ClientPassword = passwordBox.Password
                            };
                            context.Clients.Add(client);
                            context.SaveChanges();
                            MessageBox.Show("Пользователь был зарегистрирован", "Проверка регестрации",
                                            MessageBoxButton.OK, MessageBoxImage.Information);
                            Close();
                        }

                        else
                        {
                            MessageBox.Show("Данный логин уже был зарегестрирован! Введите другой логин!", "Login warning",
                                            MessageBoxButton.OK, MessageBoxImage.Warning);
                            textBox_login.Text = "";
                        }
                    }
                }

                else
                {
                    MessageBox.Show("Подтверждения пароля не совпадает с паролем! Введите правильно пароль !", "Password warning",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    passwordBox2.Password = "";
                }
            }

            else MessageBox.Show("Вы забыли заполнить поле ввода !", "Validation warning",
                                   MessageBoxButton.OK, MessageBoxImage.Warning);
            
        }
    }
}
