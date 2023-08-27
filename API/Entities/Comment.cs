using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Entities
{
  public class Comment
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime CreateTime {get;set;} =  DateTime.Now;
    [JsonIgnore]
    public User User { get; set; }
    [JsonIgnore]
    public Movie Movie { get; set; }
    public int MovieId { get; set; }
    [Required]
    public string Content { get; set; }
  }
}