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
      var user = await _context.Users.Include(u => u.Comments).Include(u => u.LikedMovies).Include(u => u.Ratings).FirstOrDefaultAsync(u => u.UserName == username);
      return user;
    }

    public async Task<User> FindUserByEmailAsync(string email)
    {
      return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }






  }
}