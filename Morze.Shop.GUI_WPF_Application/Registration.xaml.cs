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
            textBox_password.MaxLength = Settings.lengthNchar;
            textBox_password2.MaxLength = Settings.lengthNchar;
        }

        private void Button_Click_Sign_Up(object sender, RoutedEventArgs e)
        {
            using (var context = new MyDbContext())
            {
                var client = new Client()
                {
                   ClientFirstName = "f",
                   ClientLastName = "f",
                   ClientLogin = "f",
                   ClientPassword = "f",
                };
                context.Clients.Add(client);
                context.SaveChanges();
            }
            MessageBox.Show("Пользователь был зарегистрирован", "Проверка регестрации", MessageBoxButton.OK , MessageBoxImage.Information);
            this.Close();
        }
        private void Button_Click_MainWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
