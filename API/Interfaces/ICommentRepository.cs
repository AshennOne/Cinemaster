using API.Entities;

namespace API.Interfaces
{
    public interface ICommentRepository
    {
        public Task CreateCommentAsync(Comment comment);
        public Task<Comment> GetCommentAsync(int id);
        public Task<UserCommentsEntity> GetAllCommentsAsync(User user,int page);
        public Task<IEnumerable<Comment>> GetAllCommentsAsync(Movie movie);
        public Task DeleteCommentAsync(int id);
        public Task<Comment> EditCommentAsync(int id, string content);
       
    }
}