using ClientApp;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ClientApp
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
        private void ViewProducts_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductsPage(products));
        }

        private void ViewPromotions_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PromotionsPage(promotions));
        }
    }
}
