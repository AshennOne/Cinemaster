using System.Text.Json;
using API.Entities;
using API.Helpers;
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
    public DbSet<UserMovies> UserMovies { get; set; }
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<User>()
              .Property(u => u.Id)
              .ValueGeneratedOnAdd();
      var moviesJson = File.ReadAllText("data/movies.json");
      var movies = JsonSerializer.Deserialize<List<Movie>>(moviesJson);
      modelBuilder.Entity<UserMovies>()
               .HasKey(um => new { um.UserId, um.MovieId });
      modelBuilder.Entity<UserMovies>()
              .HasOne(um => um.User)
              .WithMany(u => u.LikedMovies)
              .HasForeignKey(um => um.UserId);

      modelBuilder.Entity<UserMovies>()
          .HasOne(um => um.Movie)
          .WithMany(m => m.LikedByUsers)
          .HasForeignKey(um => um.MovieId);
      int seedId = 1;
      foreach (var movie in movies)
      {
        movie.Id = seedId;
        seedId++;
      }

      modelBuilder.Entity<Movie>().HasData(movies);
    }
  }
}