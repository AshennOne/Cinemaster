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
    [HttpGet("user/{page}")]
    public async Task<ActionResult<UserRatingsEntity>> GetRatingsForUser(int page)
    {
      var user = await GetUser();
      UserRatingsEntity ratings = await _unitOfWork.RatingRepository.GetAllRatingsAsync(user,page);
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
    [HttpPost("{id}")]
    public async Task<ActionResult> CreateRating([FromRoute] int id, [FromBody] Rating rating)
    {
      var user = await GetUser();

      var movie = await _unitOfWork.MovieRepository.GetMovieById(id);
      if (movie == null) return NotFound("movie doesn't exists");
      await _unitOfWork.RatingRepository.CreateRatingAsync(new Rating
      {
        UserId = user.Id,
        MovieId = movie.Id,
        Grade = rating.Grade
      });
      if (await _unitOfWork.SaveAllAsync()) return Ok();
      return BadRequest();
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<Rating>> EditRating(int id, [FromBody] Rating rating)
    {
      var user = await GetUser();
      var oldRating = user.Ratings.FirstOrDefault(c => c.MovieId == id);
      if (oldRating == null) {return NotFound("rating doesn't exists");}
      await _unitOfWork.RatingRepository.EditRatingAsync(oldRating.Id, rating.Grade);
      if (await _unitOfWork.SaveAllAsync()) return Ok();
      return BadRequest();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteRating(int id)
    {
      var user = await GetUser();
      var rating = user.Ratings.FirstOrDefault(c => c.Id == id);
      if (rating == null) return NotFound("rating doesn't exists");
      await _unitOfWork.RatingRepository.DeleteRatingAsync(id);
      if (await _unitOfWork.SaveAllAsync()) return NoContent();
      return NoContent();
    }
    private async Task<User> GetUser()
    {
      var username = User.GetUsername();
      return await _unitOfWork.UserRepository.FindUserByUsernameAsync(username);
    }
  }
}