using Morze.Shop.Db_context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Product_creation.xaml
    /// </summary>
    public partial class Product_creation : Window
    {
        public Product_creation()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            textBox_productName.MaxLength = Settings.lengthNchar;
        }
       
        private void Button_Click_CreatingProducttton(object sender, RoutedEventArgs e)
        {
            try
            {
                if ( (textBox_productName.Text.Trim().Length > 0) && (textBox_price.Text.Trim().Length > 0) &&
                     (textBox_amount.Text.Trim().Length > 0) && (textBox_clientID.Text.Trim().Length > 0) )
                {
                    using (var context = new MyDbContext())
                    {
                        var product = new Product()
                        {
                            ProductName = textBox_productName.Text,
                            Price = Convert.ToInt32(textBox_price.Text.Trim()),
                            Amount = Convert.ToInt32(textBox_amount.Text.Trim()),
                            ClientId = Convert.ToInt32(textBox_clientID.Text.Trim())
                        };
                        context.Products.Add(product);
                        context.SaveChanges();
                    }
                    this.Close();
                }
                else 
                { 
                    MessageBox.Show("Вы забыли заполнить поле ввода !", "Validation error",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                    textBox_productName.Text = "";
                    textBox_price.Text = "";
                    textBox_amount.Text = "";
                    textBox_clientID.Text = "";
                }
                
                
            }
            catch (Exception)
            {
                MessageBox.Show("Отсутвует подключение к базе данных", "Connecting to the database",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
            
        }
        private void Button_Click_OutToShop(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


    }
}
