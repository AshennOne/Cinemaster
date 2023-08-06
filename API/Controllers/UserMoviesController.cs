using System.Security.Claims;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Extensions;
namespace API.Controllers
{
    [Authorize]
    public class UserMoviesController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserMoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;


        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetLikedMovies()
        {
            var user =await GetCurrentUser();
            var list = await _unitOfWork.MovieListRepository.GetMovieListAsync(user.Id);
            return Ok(list);
        }

        [HttpPost("{movieId}")]
        public async Task<ActionResult> AddLikedMovie(int movieId)
        {
            var user = await GetCurrentUser();
            await _unitOfWork.MovieListRepository.AddMovieToListAsync(user.Id, movieId);
            if (await _unitOfWork.MovieRepository.SaveAllAsync())
            {
                return Ok();
            };
            return BadRequest("Error occured, adding to your list went wrong");
        }
        [HttpDelete("{movieId}")]
        public async Task<ActionResult> DeleteLikedMovie(int movieId)
        { 
            var user = await GetCurrentUser();
            await _unitOfWork.MovieListRepository.DeleteMovieFromListAsync(user.Id, movieId);
            if(await _unitOfWork.MovieRepository.SaveAllAsync())  return NoContent();
           return BadRequest("Unable to delete");
        }
        private async Task<User> GetCurrentUser()
        {
            var username = User.GetUsername();
            return await _unitOfWork.UserRepository.FindUserByUsernameAsync(username);
        }
    }
}