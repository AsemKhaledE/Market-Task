using Market.Models;

namespace Market.ViewModel
{
    public class ProductViewModel
    {
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int InvoiceId { get; set; }
        public List<ProductListViewModel> ProductList { get; set; } = new List<ProductListViewModel>();

        public ProductViewModel()
        {

        }

        public ProductViewModel(Product p)
        {
            ProductName = p.ProductName;
            Quantity = p.Quantity;
            InvoiceId = p.InvoiceId;
            Price = p.Price;
        }

        public Product ToEntity()
        {
            return new Product
            {
                ProductName = ProductName,
                Quantity = Quantity,
                InvoiceId = InvoiceId,
                Price = Price
            };
        }
    }
}
