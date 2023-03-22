using Market.Models;
using Market.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Market.Data
{
    public class MarketDbContext:DbContext
    {
        public MarketDbContext(DbContextOptions<MarketDbContext> options) : base(options)
        {

        }
        public DbSet<User>? Users { get; set; }
        public DbSet<Invoice>? Invoices { get; set; }
        public DbSet<Product>? Products { get; set; }

    }

}
