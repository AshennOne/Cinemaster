using API.Entities;

namespace API.Interfaces
{
  public interface IUserRepository
  {
    Task<User> FindUserByUsernameAsync(string username);
    Task<User> FindUserByEmailAsync(string email);
    Task<User> FindUserByIdAsync(int id);
    Task<IEnumerable<User>> GetAll();
  }
}