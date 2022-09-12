using Morze.Shop.Db_context;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Morze.Shop.GUI_WPF_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            textBox_login.MaxLength = Settings.lengthNchar;
            passwordBox.MaxLength = Settings.lengthNchar;
        }

        private void Button_Click_Entry(object sender, RoutedEventArgs e)
        {
            Entry();
        }

        private void Button_Click_Registration(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.ShowDialog();
        }

        //Метод Входа в приложения
        private void Entry()
        {
            var Login = textBox_login.Text;
            var Password = passwordBox.Password;

            //Проверка на пустые поля, которые не заполнил пользователь
            if ((textBox_login.Text.Trim().Length > 0) && (passwordBox.Password.Trim().Length > 0))
            {
                bool isClientFound;
                using (var context = new MyDbContext())
                {
                    //Проверка в базе данных наличия пользователя
                    isClientFound = context.Clients.Any(client => client.ClientLogin == Login && client.ClientPassword == Password);
                }
                if (isClientFound)
                {
                    Shop shop = new Shop(Login);
                    shop.Show();
                    Close();
                }
                else MessageBox.Show("Пользователь не был найден в базе данных! Если вы не зарегестрировись попробуйте пройти регестрацию", "Login Error",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);


            }
            else MessageBox.Show("Вы забыли заполнить поле ввода !", "Validation error",
                                MessageBoxButton.OK, MessageBoxImage.Error);

        }

    }
}
