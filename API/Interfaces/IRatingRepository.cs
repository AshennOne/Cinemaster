using API.Entities;

namespace API.Interfaces
{
    public interface IRatingRepository
    {
        public Task CreateRatingAsync(Rating rating);
        public Task<Rating> GetRatingAsync(int id);
        public  Task<UserRatingsEntity> GetAllRatingsAsync(User user, int currentPage);
        public  Task<IEnumerable<Rating>> GetAllRatingsAsync(Movie movie);
        public Task DeleteRatingAsync(int id);
        public Task<Rating> EditRatingAsync(int id, int value);

    }
}