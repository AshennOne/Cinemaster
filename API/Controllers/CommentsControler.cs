using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using API.Extensions;

namespace API.Controllers
{
    [Authorize]
    public class CommentsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        [HttpGet("user")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetCommentsForUser()
        {
            var user = await GetUser();
            IEnumerable<Comment> comments = await _unitOfWork.CommentRepository.GetAllCommentsAsync(user);
            return Ok(comments);
        }
        [HttpGet("movie")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetCommentsForMovie([FromQuery] string title)
        {
            var movie = await _unitOfWork.MovieRepository.GetMovieByTitle(title);
            if (movie == null) return NotFound();
            var comments = await _unitOfWork.CommentRepository.GetAllCommentsAsync(movie);
            return Ok(comments);
        }
        [HttpPost]
        public async Task<ActionResult> CreateComment([FromQuery] string title, [FromBody] Comment comment)
        {
            var user = await GetUser();
            var movie = await _unitOfWork.MovieRepository.GetMovieByTitle(title);
            string content = comment.Content;
            await _unitOfWork.CommentRepository.CreateCommentAsync(new Comment
            {
                User = user,
                Movie = movie,
                Content = content
            });
            if (await _unitOfWork.MovieRepository.SaveAllAsync()) return Ok();
            return BadRequest();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Comment>> EditComment(int id, [FromBody] Comment Newcomment)
        {
            var user = await GetUser();
            var comment = user.Comments.FirstOrDefault(c => c.Id == id);
            if (comment == null) return NotFound();
            await _unitOfWork.CommentRepository.EditCommentAsync(id, Newcomment.Content);
            if (await _unitOfWork.MovieRepository.SaveAllAsync()) return Ok();
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComment(int id)
        {
            var user = await GetUser();
            var comment = user.Comments.FirstOrDefault(c => c.Id == id);
            if (comment == null) return NotFound();
            await _unitOfWork.CommentRepository.DeleteCommentAsync(id);
            if (await _unitOfWork.MovieRepository.SaveAllAsync()) return NoContent();
            return NoContent();
        }
        private async Task<User> GetUser()
        {
            var username = User.GetUsername();
            return await _unitOfWork.UserRepository.FindUserByUsernameAsync(username);
        }
    }
}