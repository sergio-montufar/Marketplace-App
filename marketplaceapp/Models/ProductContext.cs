using Microsoft.EntityFrameworkCore;

namespace marketplaceapp.Models {
  public class ProductContext : DbContext {
    public ProductContext(DbContextOptions<ProductContext> options) : base(options) {}

    public DbSet<Product> Products {get; set;} = null!; 
  }
}