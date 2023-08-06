using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace API.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CommentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task CreateCommentAsync(Comment comment)
        {
            await _dbContext.Comments.AddAsync(comment);
        }

        public async Task DeleteCommentAsync(int id)
        {
            var comment = await _dbContext.Comments.FindAsync(id);
            _dbContext.Comments.Remove(comment);
        }

        public async Task<Comment> EditCommentAsync(int id, string content)
        {
            var oldComment = await _dbContext.Comments.FindAsync(id);
            oldComment.Content = content;
            return oldComment;

        }

        public async Task<IEnumerable<Comment>> GetAllCommentsAsync(User user)
        {
            return await _dbContext.Comments.Where(c => c.UserId == user.Id).ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsAsync(Movie movie)
        {
            return await _dbContext.Comments.Where(c => c.MovieId == movie.Id).ToListAsync();
        }

        public async Task<Comment> GetCommentAsync(int id)
        {
            return await _dbContext.Comments.FindAsync(id);
        }
        public async Task<bool> SaveAllAsync()
        {
            return (await _dbContext.SaveChangesAsync()) > 0;
        }
    }
}