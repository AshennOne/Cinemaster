using API.Dtos;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AuthController : BaseApiController
{
  private readonly UserManager<User> _userManager;
  private readonly SignInManager<User> _signInManager;
  private readonly IUserRepository _userRepository;
  public AuthController(SignInManager<User> signInManager, UserManager<User> userManager, IUserRepository userRepository)
  {
    _userRepository = userRepository;
    _signInManager = signInManager;
    _userManager = userManager;

  }
  [HttpPost("register")]
  public async Task<ActionResult<AuthorizedUserDto>> Register([FromBody] RegisterDto registerDto)
  {
    var ExistingUser = await _userRepository.FindUserByUsernameAsync(registerDto.Username);
    if (ExistingUser != null) return BadRequest("Username already exists");
    ExistingUser = await _userRepository.FindUserByEmailAsync(registerDto.Email);
    if (ExistingUser != null) return BadRequest("Email already exists");
    if (ModelState.IsValid)
    {
      var newUser = new User
      {
        UserName = registerDto.Username,
        Email = registerDto.Email
      };
      var result = await _userManager.CreateAsync(newUser, registerDto.Password);
      if (result.Succeeded)
      {

        await _signInManager.SignInAsync(newUser, isPersistent: false);
        var UserToReturn = new AuthorizedUserDto
        {
          UserName = newUser.UserName,
          ImgUrl = "",
          Comments = new List<Comment>(),
          Ratings = new List<Rating>(),
          UserToken = ""
        };
        return Ok(UserToReturn);
      }
      return BadRequest(result.Errors);
    }
    return BadRequest("Something went wrong");
  }

  [HttpPost("login")]
  public async Task<ActionResult<AuthorizedUserDto>> LoginUser(LoginDto loginDto)
  {
    var ExistingUser = await _userRepository.FindUserByUsernameAsync(loginDto.Username);
    if (ExistingUser == null) return NotFound("Username not found");
    var isPasswordCorrect = await _userManager.CheckPasswordAsync(ExistingUser, loginDto.Password);
    if (isPasswordCorrect)
    {
      return new AuthorizedUserDto
      {
        UserName = ExistingUser.UserName,
        ImgUrl = ExistingUser.ImgUrl,
        Comments = ExistingUser.Comments,
        Ratings = ExistingUser.Ratings,
        UserToken = ""
      };
    }
    else
    {
      return Unauthorized("Password is incorrect!");
    }

  }
}