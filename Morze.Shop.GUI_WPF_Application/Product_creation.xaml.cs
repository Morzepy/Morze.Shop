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
        private void Button_Click_OutToShop(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
