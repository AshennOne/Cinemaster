namespace API.Entities
{
    public class UserListEntity
    {
        public int TotalItems { get; set; }
        public IEnumerable<UserMovies> UserList { get; set; }
    }
}