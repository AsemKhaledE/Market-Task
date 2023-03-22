using System.ComponentModel.DataAnnotations;

namespace Market.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Invoice? Invoice { get; set; }
        public int InvoiceId { get; set; }
    }
}
