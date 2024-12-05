using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AdminApp
{
    public partial class HomePage : Page
    {
        private List<Products> products;
        private List<Promotions> promotions;

        public HomePage(List<Products> products, List<Promotions> promotions)
        {
            InitializeComponent();
            this.products = products;
            this.promotions = promotions;
        }
        private void ManageProducts_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductsPage());
        }

        private void ManagePromotions_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PromotionsPage());
        }
    }
}
