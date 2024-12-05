using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Collections.Generic;

namespace AdminApp
{
    public partial class PromotionsPage : Page
    {
        private List<Promotions> promotions;
        private DatabaseHelper _dbHelper;

        public PromotionsPage()
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper("MyDatabaseConnection");
            LoadData();
        }
        private void LoadData()
        {
            string query = "SELECT * FROM promotions";
            var dataTable = _dbHelper.ExecuteQuery(query);
            promotionsDataGrid.ItemsSource = dataTable.DefaultView;
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
        private void DeleteSelected_Click(object sender, RoutedEventArgs e)
        {
            if (promotionsDataGrid.SelectedItem != null)
            {
                Promotions selectedPromotion = (Promotions)promotionsDataGrid.SelectedItem;
                promotions.Remove(selectedPromotion);
                promotionsDataGrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Please select a promotion to delete.");
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
