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
    private readonly IUnitOfWork _unitOfWork;
    public UsersController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;

    }
   
    [HttpGet("{username}")]
    public async Task<ActionResult<User>> GetUserByUsername(string username)
    {

      var user = await _unitOfWork.UserRepository.FindUserByUsernameAsync(username);
      if (user == null) return NotFound("User doesn't exist");
      return Ok(user);
    }
  }
}