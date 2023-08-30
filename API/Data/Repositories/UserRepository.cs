using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context)
    {
      _context = context;

    }


    public async Task<User> FindUserByUsernameAsync(string username)
    {
      User user = await _context.Users.Include(u => u.Comments).Include(u => u.LikedMovies).Include(u => u.Ratings).FirstOrDefaultAsync(u => u.UserName == username);
      return user;
    }

    public async Task<User> FindUserByEmailAsync(string email)
    {
      return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> FindUserByIdAsync(int id)
    {
      return await _context.Users.Select(u => new User
      {
        Id = u.Id,
        UserName = u.UserName,
        ImgUrl = u.ImgUrl,
        LikedMovies = u.LikedMovies,
        Comments = u.Comments,
        Ratings = u.Ratings
      }).FirstOrDefaultAsync(u => u.Id == id);
    }
  }
}