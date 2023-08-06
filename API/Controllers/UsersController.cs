using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [Authorize]
  public class UsersController : BaseApiController
  {
    private readonly IUserRepository _userRepository;
    public UsersController(IUserRepository userRepository)
    {
      _userRepository = userRepository;

    }
   
    [HttpGet("{username}")]
    public async Task<ActionResult<User>> GetUserByUsername(string username)
    {

      var user = await _userRepository.FindUserByUsernameAsync(username);
      if (user == null) return NotFound("User doesn't exist");
      return Ok(user);
    }
  }
}