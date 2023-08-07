using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
namespace API.Entities
{
  public class User : IdentityUser<int>
  {

    public string ImgUrl { get; set; } = null;
    [JsonIgnore]
    public List<Comment> Comments { get; set; } = new List<Comment>();
    [JsonIgnore]
    public List<Rating> Ratings { get; set; } = new List<Rating>();
    [JsonIgnore]
    public List<UserMovies> LikedMovies{get;set;} = new List<UserMovies>();
  }
}