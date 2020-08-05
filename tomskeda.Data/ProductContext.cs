using Microsoft.EntityFrameworkCore;
using Tomskeda.Core.Entities;

namespace Tomskeda.Date
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
