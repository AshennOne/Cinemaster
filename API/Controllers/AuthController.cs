using System.Security.Claims;
using API.Dtos;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AuthController : BaseApiController
{
  private readonly UserManager<User> _userManager;
  private readonly IUserRepository _userRepository;
  private readonly ITokenService _tokenService;

  public AuthController(UserManager<User> userManager, IUserRepository userRepository, ITokenService tokenService)
  {
    _tokenService = tokenService;
    _userRepository = userRepository;
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
        UserName = registerDto.Username.ToLower(),
        Email = registerDto.Email
      };
      var result = await _userManager.CreateAsync(newUser, registerDto.Password);
      if (result.Succeeded)
      {
        await _userManager.AddToRoleAsync(newUser, "User");
        var token = _tokenService.GenerateToken(newUser,(await _userManager.GetRolesAsync(newUser))[0]);

        var UserToReturn = new AuthorizedUserDto
        {
          UserName = newUser.UserName,
          ImgUrl = "",
          Comments = new List<Comment>(),
          Ratings = new List<Rating>(),
          Movies = new List<UserMovies>(),
          Token = token,
          Role = "User"
        };
        return Ok(UserToReturn);
      }
      return BadRequest("Registration error, try again");
    }
    return BadRequest("Something went wrong");
  }
  
  [HttpPost("login")]
  public async Task<ActionResult<AuthorizedUserDto>> LoginUser(LoginDto loginDto)
  {
    var ExistingUser = await _userRepository.FindUserByUsernameAsync(loginDto.Username.ToLower());
    if (ExistingUser == null) return NotFound("Username not found");
    var isPasswordCorrect = await _userManager.CheckPasswordAsync(ExistingUser, loginDto.Password);
    if (isPasswordCorrect)
    {
      var token = _tokenService.GenerateToken(ExistingUser, (await _userManager.GetRolesAsync(ExistingUser))[0]);
      return Ok(new AuthorizedUserDto
      {
        UserName = ExistingUser.UserName,
        ImgUrl = ExistingUser.ImgUrl,
        Comments = ExistingUser.Comments,
        Ratings = ExistingUser.Ratings,
        Movies = ExistingUser.LikedMovies,
        Token = token,
        Role = (await _userManager.GetRolesAsync(ExistingUser))[0]
      });
    }
    else
    {
      return Unauthorized("Password is incorrect!");
    }

  }
}