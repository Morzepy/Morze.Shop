﻿using Morze.Shop.Db_context;
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

namespace Morze.Shop.GUI_WPF_Application
{
    /// <summary>
    /// Логика взаимодействия для Shop.xaml
    /// </summary>
    public partial class Shop : Window
    {       
        public List<Client> MyClients { get; set; }
        public List<Product> MyProducts { get; set; }
        public Shop()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            label_login.Content = "User";
        }

        private void Button_Click_Refresh(object sender, RoutedEventArgs e)
        {
            switch (ComboBox_Table.SelectedIndex)
            {

                case 0: //Проверка на выбор в ComboBox поля Товары
                    using (var _context = new MyDbContext())
                    {
                        MyProducts = _context.Products.ToList();
                    }
                    BD_List.ItemsSource = MyProducts;
                    break;
                case 1: //Проверка на выбор в ComboBox поля Клиент
                    using (var _context = new MyDbContext())
                    {
                        MyClients = _context.Clients.ToList();
                    }
                    BD_List.ItemsSource = MyClients;
                    break;
                default: //Если поле не выбрано
                    MessageBox.Show("Выберите таблицу из списка ниже", "Warning",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
            }
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            switch (ComboBox_Table.SelectedIndex)
            {

                case 0: //Проверка на выбор в ComboBox поля Товары

                    break;
                case 1: //Проверка на выбор в ComboBox поля Клиент

                    break;
                default: //Если поле не выбрано
                    MessageBox.Show("Выберите таблицу из списка ниже", "Warning",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;

            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            MyClients = MyClients.FindAll(x => x.ClientFirstName.Contains(textBox_Search.Text));
            BD_List.ItemsSource = MyClients;
        }

        private void Button_Click_Product_creation(object sender, RoutedEventArgs e)
        {
            Product_creation product_creation = new Product_creation();
            product_creation.ShowDialog();
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
       

        private void BD_List_AutoGeneratedColumns(object sender, EventArgs e)
        {

        }
    }
}
