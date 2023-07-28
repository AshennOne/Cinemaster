using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  public class UserController : BaseApiController
  {
    private readonly IUserRepository _userRepository;
    public UserController(IUserRepository userRepository)
    {
      _userRepository = userRepository;

    }
    
    [HttpGet("{username}")]
    public async Task<ActionResult<User>> GetUserById(string username)
    {
      return Ok(await _userRepository.FindUserByUsernameAsync(username));
    }
  }
}