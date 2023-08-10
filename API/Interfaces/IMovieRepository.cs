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
    Task<MoviePaginationEntity> GetAllMovies(int currentPage);
    Task<Movie> GetMovieById(int id);
    Task<bool> SaveAllAsync();
  }
}