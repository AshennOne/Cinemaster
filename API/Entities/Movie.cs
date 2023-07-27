namespace API.Entities
{
  public class Movie
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public DateTime Premiere { get; set; }
    public string Description { get; set; }
    public string imgUrl { get; set; }
    public int Duration { get; set; }
    public List<Comment> Comments { get; set; } = new List<Comment>();
    public List<Rating> Ratings { get; set; } = new List<Rating>();
  }
}