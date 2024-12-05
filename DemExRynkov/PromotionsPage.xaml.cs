using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ClientApp
{
    public partial class PromotionsPage : Page
    {
        private List<Promotions> promotions;

        public PromotionsPage(List<Promotions> promotions)
        {
            InitializeComponent();
            this.promotions = promotions;
            promotionsDataGrid.ItemsSource = promotions;
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
