using System.ComponentModel.DataAnnotations;

namespace Market.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public List<Product>? Products { get; set; }

    }
}
