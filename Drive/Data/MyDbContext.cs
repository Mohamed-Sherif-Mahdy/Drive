using Drive.Modles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Drive.Data
{
  public class MyDbContext : IdentityDbContext<User>
  {
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {

    }
    //create a two roles in data base 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
      modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "User", NormalizedName = "USER" });
    }
    public DbSet<Modles.File> Files { get; set; }
    public DbSet<User> Users { get; set; }


  }
}
