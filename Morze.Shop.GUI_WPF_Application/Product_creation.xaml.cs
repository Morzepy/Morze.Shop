using Morze.Shop.Db_context;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;


namespace Morze.Shop.GUI_WPF_Application
{
    /// <summary>
    /// Логика взаимодействия для Product_creation.xaml
    /// </summary>
    public partial class Product_creation : Window
    {
        public Product_creation()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            textBox_productName.MaxLength = Settings.lengthNchar;
        }
       
        private void Button_Click_Creating(object sender, RoutedEventArgs e)
        {
            Creating ();
        }
        
        private void Button_Click_OutToShop(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти из окна создания товара", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        //Метод создания товара
        private void Creating()
        {
            //Проверка на пустые поля, которые не заполнил пользователь
            if ((textBox_productName.Text.Trim().Length > 0) && (textBox_price.Text.Trim().Length > 0) &&
                (textBox_amount.Text.Trim().Length > 0) && (textBox_clientID.Text.Trim().Length > 0))
            {
                //Проверка ввел ли пользователь числа в нужные поля
                if (Int32.TryParse(textBox_price.Text, out int price) && Int32.TryParse(textBox_amount.Text, out int amount) &&
                    Int32.TryParse(textBox_clientID.Text, out int ClientID))
                {
                    using (var context = new MyDbContext())
                    {
                        //Проверка в базе данных есть ли клиент с таким ID
                        bool isFoundClientID = context.Clients.Any(client => client.ClientId == ClientID);
                        if (isFoundClientID)
                        {
                            var product = new Product()
                            {
                                ProductName = textBox_productName.Text,
                                Price = price,
                                Amount = amount,
                                ClientId = ClientID
                            };

                            context.Products.Add(product);
                            context.SaveChanges();
                            MessageBox.Show("Товар был создан и записан в базу данных", "Create",
                                             MessageBoxButton.OK, MessageBoxImage.Information);
                            Close();
                        }
                        else MessageBox.Show("Вы ввели в поле с числом другие символы", "NotIsNumber warning",
                                             MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Данного клиента не существует, пожалуйста проверьте таблицу клиентов!", "ClientID not found",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    textBox_clientID.Text = "";
                }
            }
            else MessageBox.Show("Вы забыли заполнить поле ввода !", "Validation warning",
                                 MessageBoxButton.OK, MessageBoxImage.Warning);

        }
    }
}
