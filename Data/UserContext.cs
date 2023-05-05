using Microsoft.EntityFrameworkCore;

namespace marketplaceapp.Models {

  public class UserContext2 : DbContext {
 

    public UserContext2(DbContextOptions<UserContext2> options) : base(options)
    {
    }
    
    public DbSet<User> Users {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>(entity => {
        entity.HasIndex(e => e.Username).IsUnique();
      });
    }
  }
}

