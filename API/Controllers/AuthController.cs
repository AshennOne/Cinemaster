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
        UserName = registerDto.Username,
        Email = registerDto.Email
      };
      var result = await _userManager.CreateAsync(newUser, registerDto.Password);
      if (result.Succeeded)
      {
        var token = _tokenService.GenerateToken(newUser.UserName);

        var UserToReturn = new AuthorizedUserDto
        {
          UserName = newUser.UserName,
          ImgUrl = "",
          Comments = new List<Comment>(),
          Ratings = new List<Rating>(),
          Token = token
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
      var token = _tokenService.GenerateToken(ExistingUser.UserName);
      return Ok(new AuthorizedUserDto
      {
        UserName = ExistingUser.UserName,
        ImgUrl = ExistingUser.ImgUrl,
        Comments = ExistingUser.Comments,
        Ratings = ExistingUser.Ratings,
        Token = token
      });
    }
    else
    {
      return Unauthorized("Password is incorrect!");
    }

  }
}