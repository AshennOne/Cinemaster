using API.Dtos;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class MovieListRepository : IMovieListRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public MovieListRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task AddMovieToListAsync(int userId, int movieId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            var movie = await _dbContext.Movies.FindAsync(movieId);
            user.LikedMovies.Add(new UserMovies
            {
                User = user,
                Movie = movie

            });
        }

        public async Task DeleteMovieFromListAsync(int userId, int movieId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            var movie = await _dbContext.Movies.FindAsync(movieId);
            var likedMovie = new UserMovies
            {
                User = user,
                
                Movie = movie,
               
            };
            _dbContext.UserMovies.Remove(likedMovie);


        }

        public async Task<IEnumerable<Movie>> GetMovieListAsync(int userId)
        {
            return await _dbContext.UserMovies.Where(m => m.UserId == userId).Select(um => um.Movie).ToListAsync();

        }
        public async Task<bool> SaveAllAsync()
        {
            return (await _dbContext.SaveChangesAsync()) > 0;
        }
    }


}