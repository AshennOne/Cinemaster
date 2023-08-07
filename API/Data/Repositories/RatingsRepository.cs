
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{

    public class RatingsRepository : IRatingRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public RatingsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task CreateRatingAsync(Rating rating)
        {
            await _dbContext.Ratings.AddAsync(rating);
        }

        public async Task DeleteRatingAsync(int id)
        {
            var rating = await  _dbContext.Ratings.FindAsync(id);
            _dbContext.Ratings.Remove(rating);
          
        }

        public async Task<Rating> EditRatingAsync(int id, int value)
        {
            var rating = await  _dbContext.Ratings.FindAsync(id);
            rating.Grade = value;
            
            return rating;
        }

        public async Task<IEnumerable<Rating>> GetAllRatingsAsync(User user)
        {
             return await _dbContext.Ratings.Where(c => c.UserId == user.Id).ToListAsync();
        }

        public async Task<IEnumerable<Rating>> GetAllRatingsAsync(Movie movie)
        {
             return await _dbContext.Ratings.Where(c => c.MovieId == movie.Id).ToListAsync();
        }

        public async Task<Rating> GetRatingAsync(int id)
        {
            return await  _dbContext.Ratings.FindAsync(id);
        }
    }
}