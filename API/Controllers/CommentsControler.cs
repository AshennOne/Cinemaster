using API.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Authorize]
    public class CommentsControler
    {
        private readonly ICommentRepository _commentRepository;
        public CommentsControler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;

        }
    }
}