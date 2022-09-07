using Morze.Shop.Db_context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            textBox_FirstName.MaxLength = Settings.lengthNchar;
            textBox_LastName.MaxLength = Settings.lengthNchar;
            textBox_login.MaxLength = Settings.lengthNchar;
            passwordBox.MaxLength = Settings.lengthNchar;
            passwordBox2.MaxLength = Settings.lengthNchar;
        }

        private void Button_Click_Sign_Up(object sender, RoutedEventArgs e)
        {


            if ((textBox_FirstName.Text.Trim().Length > 0) && (textBox_LastName.Text.Trim().Length > 0) &&
                 (textBox_login.Text.Trim().Length > 0) && (passwordBox.Password.Trim().Length > 0) &&
                 (passwordBox2.Password.Trim().Length > 0))
            {
                try
                {
                    using (var context = new MyDbContext())
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
                        this.Close();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                MessageBox.Show("Вы забыли заполнить поле ввода !", "Validation error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                textBox_FirstName.Text = "";
                textBox_LastName.Text = "";
                textBox_login.Text = "";
                passwordBox.Password = "";
                passwordBox2.Password = "";
            }
                
        } 
        private void Button_Click_MainWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
