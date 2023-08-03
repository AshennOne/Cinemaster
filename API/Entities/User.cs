using Microsoft.AspNetCore.Identity;
namespace API.Entities
{
  public class User : IdentityUser<int>
  {

    public string ImgUrl { get; set; } = null;
    public List<Comment> Comments { get; set; } = new List<Comment>();
    public List<Rating> Ratings { get; set; } = new List<Rating>();
  
  }
}