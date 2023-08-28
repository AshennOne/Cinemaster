using API.Entities;

namespace API.Interfaces
{
    public interface IMovieListRepository
    {
        public Task<UserListEntity> GetMoviePaginatedListAsync(int userId,int currentPage);
         public Task<IEnumerable<Movie>> GetMovieListAsync(int userId);
        public Task AddMovieToListAsync(int userId, int movieId);
        public Task DeleteMovieFromListAsync(int userId, int movieId);

    }
}