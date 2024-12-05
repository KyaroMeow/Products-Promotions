using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ClientApp
{
    public partial class ProductsPage : Page
    {
        private List<Products> products;
        public ProductsPage(List<Products> products)
        {
            InitializeComponent();
            this.products = products;
            productsDataGrid.ItemsSource = products;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}
