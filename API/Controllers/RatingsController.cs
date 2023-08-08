
using API.Entities;
using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [Authorize]
  public class RatingsController : BaseApiController
  {
    private readonly IUnitOfWork _unitOfWork;
    public RatingsController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;

    }
    [HttpGet("user")]
    public async Task<ActionResult<IEnumerable<Rating>>> GetRatingsForUser()
    {
      var user = await GetUser();
      IEnumerable<Rating> ratings = await _unitOfWork.RatingRepository.GetAllRatingsAsync(user);
      return Ok(ratings);
    }
    [HttpGet("movie")]
    public async Task<ActionResult<IEnumerable<Rating>>> GetRatingsForMovie([FromQuery] string title)
    {
      var movie = await _unitOfWork.MovieRepository.GetMovieByTitle(title);
      if (movie == null) return NotFound("movie doesn't exists");
      var ratings = await _unitOfWork.RatingRepository.GetAllRatingsAsync(movie);
      return Ok(ratings);
    }
    [HttpPost("id")]
    public async Task<ActionResult> CreateRating(int id, [FromQuery] int grade)
    {
      var user = await GetUser();
      var movie = await _unitOfWork.MovieRepository.GetMovieById(id);
      if(movie == null) return NotFound("movie doesn't exists");
      await _unitOfWork.RatingRepository.CreateRatingAsync(new Rating
      {
        User = user,
        Movie = movie,
        Grade = grade
      });
      if (await _unitOfWork.MovieRepository.SaveAllAsync()) return Ok();
      return BadRequest();
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<Rating>> EditRating(int id, [FromQuery] int grade)
    {
      var user = await GetUser();
      var rating = user.Ratings.FirstOrDefault(c => c.Id == id);
      if (rating == null) return NotFound("rating doesn't exists");
      await _unitOfWork.RatingRepository.EditRatingAsync(id, grade);
      if (await _unitOfWork.MovieRepository.SaveAllAsync()) return Ok();
      return BadRequest();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteRating(int id)
    {
      var user = await GetUser();
      var rating = user.Comments.FirstOrDefault(c => c.Id == id);
      if (rating == null) return NotFound("rating doesn't exists");
      await _unitOfWork.RatingRepository.DeleteRatingAsync(id);
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