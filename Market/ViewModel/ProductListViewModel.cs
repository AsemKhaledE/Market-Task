using Market.Models;

namespace Market.ViewModel
{
    public class ProductListViewModel
    {
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public ProductListViewModel()
        {

        }

        public ProductListViewModel(Product p)
        {
            ProductName = p.ProductName;
            Quantity = p.Quantity;
            Price = p.Price;
        }
    }
}
