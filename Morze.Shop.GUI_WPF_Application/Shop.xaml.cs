using Morze.Shop.Db_context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Entity;
using System.Data;

namespace Morze.Shop.GUI_WPF_Application
{
    /// <summary>
    /// Логика взаимодействия для Shop.xaml
    /// </summary>
    public partial class Shop : Window
    {       
        public List<Client> MyClients { get; set; }
        public List<Product> MyProducts { get; set; }
        public Shop(string login) 
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            label_login.Content = login;
        }

        private void Button_Click_Refresh(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            Delete();
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            Serch();
        }

        private void Button_Click_Product_creation(object sender, RoutedEventArgs e)
        {
            Product_creation product_creation = new Product_creation();
            product_creation.ShowDialog();
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти из приложения", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        //Метод загрузки базы данных
        private void Refresh()
        {

            switch (ComboBox_Table.SelectedIndex)
            {
                case 0: //Проверка на выбор в ComboBox поля Товары

                using (var context = new MyDbContext())
                {
                    context.Products.Load();
                    BD_dataGrid_Product.ItemsSource = context.Products.Local.ToBindingList();
                }

                BD_dataGrid_Product.Visibility = Visibility.Visible;
                BD_dataGrid_Client.Visibility = Visibility.Hidden;
                break;

                case 1: //Проверка на выбор в combobox поля клиент

                using (var context = new MyDbContext())
                {
                    context.Clients.Load();
                    BD_dataGrid_Client.ItemsSource = context.Clients.Local.ToBindingList();
                }

                BD_dataGrid_Client.Visibility = Visibility.Visible;
                BD_dataGrid_Product.Visibility = Visibility.Hidden;
                break;

                default: //Если поле не выбрано

                    MessageBox.Show("Выберите таблицу из списка ниже", "Warning",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                   break;
            }
 
        }

        //Метод удаления строки из таблицы 
        private void Delete()
        {
            switch (ComboBox_Table.SelectedIndex)
            {
                case 0: //Проверка на выбор в ComboBox поля Товары

                    using (var context = new MyDbContext())
                    {
                        Product selectedProduct = BD_dataGrid_Product.SelectedItem as Product;
                        if (selectedProduct != null)
                        {
                            if (MessageBox.Show("Удалить выделеную запись?", "Question", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                            {
                                Product product = context.Products.Find(selectedProduct.ProductID);
                                context.Products.Remove(product);
                                context.SaveChanges();
                                Refresh();
                            }
                        }
                    }
                    break;

                case 1: //проверка на выбор в combobox поля клиент

                    using (var context = new MyDbContext())
                    {
                        Client selectedClient = BD_dataGrid_Client.SelectedItem as Client;
                        if (selectedClient != null)
                        {
                            if (MessageBox.Show("Удалить выделеную запись?", "Question", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                            {
                                Client client = context.Clients.Find(selectedClient.ClientId);
                                context.Clients.Remove(client);
                                context.SaveChanges();
                                Refresh();
                            }
                        }
                    }
                    break;

                default: //Если поле не выбрано

                    MessageBox.Show("Выберите таблицу из списка ниже", "Warning",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
            }
        }

        //Метод поиска данных по таблице
        private void Serch()
        {
            if (textBox_Search.Text.Trim().Length > 0)
            {
                bool success = int.TryParse(textBox_Search.Text, out int number_search);
                switch (ComboBox_Table.SelectedIndex)
                {
                    case 0: //Проверка на выбор в ComboBox поля Товары

                        if (success)
                        {
                            using (var _context = new MyDbContext())
                            {
                                MyProducts = _context.Products.Where(p => p.ProductID == number_search ||
                                                                          p.Price == number_search  ||
                                                                          p.Amount == number_search ||
                                                                          p.ClientId == number_search).ToList();
                            }
                                                                         
                        }
                        else
                        {
                            using (var _context = new MyDbContext())
                            {
                                MyProducts = _context.Products.Where(p => p.ProductName == textBox_Search.Text).ToList();
                            }
                        }
                        BD_dataGrid_Product.ItemsSource = MyProducts;

                        BD_dataGrid_Product.Visibility = Visibility.Visible;
                        BD_dataGrid_Client.Visibility = Visibility.Hidden;
                        break;

                    case 1: //проверка на выбор в combobox поля клиент
                        
                        if (success)
                        {
                            using (var context = new MyDbContext())
                            {
                                MyClients = context.Clients.Where(c => c.ClientId == number_search).ToList();
                            }
                        }
                        else 
                        {
                            using (var context = new MyDbContext())
                            {
                                MyClients = context.Clients.Where(c => c.ClientFirstName == textBox_Search.Text ||
                                                                       c.ClientLastName == textBox_Search.Text).ToList();
                            }
                        }
                        BD_dataGrid_Client.ItemsSource = MyClients;

                        BD_dataGrid_Client.Visibility = Visibility.Visible;
                        BD_dataGrid_Product.Visibility = Visibility.Hidden;
                        break;

                    default: //Если поле не выбрано

                        MessageBox.Show("Выберите таблицу из списка ниже", "Warning",
                                        MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;
                }
            }
            else
            {

                MessageBox.Show("Вы забыли заполнить поле ввода !", "Validation error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //MyClients = MyClients.FindAll(x => x.ClientFirstName.Contains(textBox_Search.Text));
            //BD_List.ItemsSource = MyClients;
        }
    }
}
