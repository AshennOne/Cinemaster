namespace API.Entities
{
    public class MoviePaginationEntity
    {
       public IEnumerable<Movie> Movies {get;set;}
       public int TotalItems{get;set;}
    }
}