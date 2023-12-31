using API.Entities;

namespace API.Dtos
{
  public class AuthorizedUserDto
  {
    public string UserName { get; set; }
    public List<Comment> Comments { get; set; }
    public List<Rating> Ratings { get; set; }
    public List<UserMovies> Movies{get;set;}
    public string Token { get; set; }
    public string Role{get;set;}
  }
}