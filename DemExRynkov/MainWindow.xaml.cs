using ClientApp;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Navigation;

namespace ClientApp
{
    public partial class MainWindow : Window
    {
        public List<Products> products { get; set; }
        public List<Promotions> promotions { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            products = new List<Products>
            {
                new Products { Name = "Product 1", Price = 10.99 },
                new Products { Name = "Product 2", Price = 20.99 },
                new Products { Name = "Product 3", Price = 30.99 }
            };
            promotions = new List<Promotions>
            {
                new Promotions { Name = "Promotion 1", Description = "Description 1", EventTime = "2023-12-01" },
                new Promotions { Name = "Promotion 2", Description = "Description 2", EventTime = "2023-12-02" },
                new Promotions { Name = "Promotion 3", Description = "Description 3", EventTime = "2023-12-03" }
            };
            MainFrame.Navigate(new HomePage(products, promotions));
        }
    }
    public class Products
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
    public class Promotions
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string EventTime { get; set; }
    }
}
