namespace Aruhaz.WpfClient
{
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
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void Shops_Clicked(object sender, RoutedEventArgs e)
        {
            ShopsWindow sw = new ShopsWindow();
            sw.Show();
        }

        private void Manufacturers_Clicked(object sender, RoutedEventArgs e)
        {
            ManufacturersWindow mw = new ManufacturersWindow();
            mw.Show();
        }

        private void Products_Clicked(object sender, RoutedEventArgs e)
        {
            ProductsWindow pw = new ProductsWindow();
            pw.Show();
        }
    }
}
