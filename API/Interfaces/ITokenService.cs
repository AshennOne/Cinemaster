namespace API.Interfaces
{
  public interface ITokenService
    {
        string GenerateToken(string username);
    }
}