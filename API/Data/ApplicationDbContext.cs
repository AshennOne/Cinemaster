using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
  public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>

  {

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Rating> Ratings { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<User>()
              .Property(u => u.Id)
              .ValueGeneratedOnAdd();

    }
  }
}