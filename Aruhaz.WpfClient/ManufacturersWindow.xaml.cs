namespace Aruhaz.WpfClient
{
    using GalaSoft.MvvmLight.Messaging;
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
    /// Interaction logic for ManufacturersWindow.xaml
    /// </summary>
    public partial class ManufacturersWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManufacturersWindow"/> class.
        /// </summary>
        public ManufacturersWindow()
        {
            this.InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Register<string>(this, "GyartoResult", msg =>
            {
                (this.DataContext as MainManufacturerVM).LoadCmd.Execute(null);
                MessageBox.Show(msg);
            });
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
        }
    }
}
