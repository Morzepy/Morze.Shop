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

            using (var _context = new MyDbContext())
            {
                //MyClients = _context.Clients.ToList();
                MyProducts = _context.Products.ToList();
            }
            //BD_List.ItemsSource = MyClients;
            BD_List.ItemsSource = MyProducts;
        }
        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_Click_Product_creation(object sender, RoutedEventArgs e)
        {
            Product_creation product_creation = new Product_creation();
            product_creation.ShowDialog();
        }
    }
}
