
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
namespace API.Entities
{

  public class Rating
  {
    public int Id { get; set; }
    [JsonIgnore]
    public User User { get; set; }
    public DateTime Created{get;set;} =  DateTime.UtcNow;
    public int UserId { get; set; }
    [JsonIgnore]
    public Movie Movie { get; set; }
    public int MovieId { get; set; }
    [Range(1, 5)]
    public int Grade { get; set; }
  }
}