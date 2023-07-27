using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{

  public class Rating
  {
    public int Id { get; set; }

    public User User { get; set; }
    public int UserId { get; set; }

    public Movie Movie { get; set; }
    public int MovieId { get; set; }
    public int Grade { get; set; }
  }
}