using API.Entities;
using API.Dtos;
namespace API.Interfaces
{
  public interface IMovieRepository
  {
    Task AddMovie(MovieDto movieDto);
    Task<Movie> GetMovieByTitle(string title);
    Task EditMovie(int Id , MovieDto editedMovie);
    Task DeleteMovie(string title);
    Task<IEnumerable<Movie>> GetAllMovies();
    Task<Movie> GetMovieById(int id);
    Task<bool> SaveAllAsync();
  }
}