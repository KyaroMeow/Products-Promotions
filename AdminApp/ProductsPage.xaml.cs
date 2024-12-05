using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AdminApp
{
    public partial class ProductsPage : Page
    {
        private List<Products> products;
        private DatabaseHelper _dbHelper;
        private DataTable _dataTable;


        public ProductsPage()
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper("MyDatabaseConnection");
            LoadData();
        }
        private void LoadData()
        {
            string query = "SELECT * FROM Products";
            _dataTable = _dbHelper.ExecuteQuery(query);
            productsDataGrid.ItemsSource = _dataTable.DefaultView;
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
            if (productsDataGrid.SelectedItem != null)
            {
                Products selectedProduct = (Products)productsDataGrid.SelectedItem;
                products.Remove(selectedProduct);
                productsDataGrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Please select a product to delete.");
            }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveData();
        }
        private void SaveData()
        {
            var changes = _dataTable.GetChanges();
            if (changes != null)
            {
                foreach (DataRow row in changes.Rows)
                {
                    switch (row.RowState)
                    {
                        case DataRowState.Added:
                            string insertQuery = $"INSERT INTO \"products\" (name, price) VALUES ('{row["name"]}', {row["price"]})";
                            _dbHelper.ExecuteNonQuery(insertQuery);
                            break;
                        case DataRowState.Modified:
                            string updateQuery = $"UPDATE \"products\" SET name = '{row["name"]}', price = {row["price"]} WHERE id = {row["id"]}";
                            _dbHelper.ExecuteNonQuery(updateQuery);
                            break;
                        case DataRowState.Deleted:
                            string deleteQuery = $"DELETE FROM \"products\" WHERE id = {row["id", DataRowVersion.Original]}";
                            _dbHelper.ExecuteNonQuery(deleteQuery);
                            break;
                    }
                }
                _dataTable.AcceptChanges();
            }
        }
    }
}
