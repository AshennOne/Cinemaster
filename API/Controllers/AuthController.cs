using API.Dtos;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AuthController : BaseApiController
{
  private readonly UserManager<User> _userManager;
  private readonly ITokenService _tokenService;
    private readonly IUnitOfWork _unitOfWork;

  public AuthController(UserManager<User> userManager, IUnitOfWork unitOfWork, ITokenService tokenService)
  {
      _unitOfWork = unitOfWork;
    _tokenService = tokenService;
    _userManager = userManager;

  }
  
  [HttpPost("register")]
  public async Task<ActionResult<AuthorizedUserDto>> Register([FromBody] RegisterDto registerDto)
  {
    var ExistingUser = await _unitOfWork.UserRepository.FindUserByUsernameAsync(registerDto.Username);
    if (ExistingUser != null) return BadRequest("Username already exists");
    ExistingUser = await _unitOfWork.UserRepository.FindUserByEmailAsync(registerDto.Email);
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
    var ExistingUser = await _unitOfWork.UserRepository.FindUserByUsernameAsync(loginDto.Username.ToLower());
    if (ExistingUser == null) return NotFound("Username not found");
    var isPasswordCorrect = await _userManager.CheckPasswordAsync(ExistingUser, loginDto.Password);
    if (isPasswordCorrect)
    {
      var token = _tokenService.GenerateToken(ExistingUser, (await _userManager.GetRolesAsync(ExistingUser))[0]);
      return Ok(new AuthorizedUserDto
      {
        UserName = ExistingUser.UserName,
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