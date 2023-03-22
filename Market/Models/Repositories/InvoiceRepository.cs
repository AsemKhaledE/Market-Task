using Market.Data;
using Market.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Market.Models.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        MarketDbContext _context;
        public InvoiceRepository(MarketDbContext context)
        {
            _context = context;
        }
        public int Add(ProductViewModel product)
        {
            try
            {
                if (product.InvoiceId == 0)
                {
                    _context.Invoices?.Add(new Invoice { UserId = 4 });
                    _context.SaveChanges();
                    int lastInvoiceId = _context.Invoices!.ToList().OrderByDescending(x=> x.InvoiceId).First().InvoiceId;
                    var p = product.ToEntity();
                    p.InvoiceId = lastInvoiceId;
                    _context.Products?.Add(p);
                    _context.SaveChanges();
                    return lastInvoiceId;
                }
                else
                {
                    _context.Products?.Add(product.ToEntity());
                    _context.SaveChanges();
                    return product.InvoiceId;

                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public List<ProductListViewModel> GetProductListByInvoiceId(int invoiceId)
        {
            var products = _context.Products?.Where(p => p.InvoiceId == invoiceId).ToList();
            if (products != null && products.Count > 0)
                return products.Select(p => new ProductListViewModel(p)).ToList();
            else
                return new List<ProductListViewModel>();
        }

        public List<ProductViewModel> List()
        {
            var products = _context.Products!.Include(a => a.Invoice).ToList();
            return products.Select(x=> new ProductViewModel(x)).ToList();
        }

    }
}
