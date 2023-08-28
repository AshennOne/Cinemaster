namespace API.Entities
{
    public class UserRatingsEntity
    {
        public int TotalItems{get;set;}
        public IEnumerable<Rating> Ratings {get;set;}
    }
}