
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
            var rating = await  _dbContext.Ratings.FirstOrDefaultAsync(r => r.Id == id);
            rating.Grade = value;
            rating.Created =  DateTime.UtcNow;
           
            return rating;
        }

        public async Task<UserRatingsEntity> GetAllRatingsAsync(User user, int currentPage)
        {
             var ratings =  _dbContext.Ratings.Where(c => c.UserId == user.Id).OrderByDescending(d => d.Created);
             var totalitems = ratings.Count();
             return new UserRatingsEntity{
                Ratings = await ratings.Skip((currentPage-1)*8).Take(8).ToListAsync(),
                TotalItems = totalitems
             };
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