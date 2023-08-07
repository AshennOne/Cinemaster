using API.Dtos;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [Authorize]
  public class MoviesController : BaseApiController
  {
    private readonly IUnitOfWork _unitOfWork;

    public MoviesController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;


    }
    [HttpPost]
    public async Task<ActionResult> CreateMovie(MovieDto movieDto)
    {
      var ExistingMovie = await _unitOfWork.MovieRepository.GetMovieByTitle(movieDto.Title);
      if (ExistingMovie != null) return BadRequest("Movie with specified title already exists");
      await _unitOfWork.MovieRepository.AddMovie(movieDto);
      if (await _unitOfWork.MovieRepository.SaveAllAsync()) return Ok();
      return BadRequest("Something went wrong");
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
    {
      return Ok(await _unitOfWork.MovieRepository.GetAllMovies());
    }
    [HttpGet("{title}")]
    public async Task<ActionResult<Movie>> GetMovie(string title)
    {
      var movie = await _unitOfWork.MovieRepository.GetMovieByTitle(title);
      if (movie == null) return NotFound("Title does not exists");
      return Ok(movie);
    }
    [HttpDelete("{title}")]
    public async Task<ActionResult> DeleteMovie(string title)
    {
      await _unitOfWork.MovieRepository.DeleteMovie(title);
      await _unitOfWork.MovieRepository.SaveAllAsync();
      return NoContent();
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> EditMovie([FromBody] MovieDto movieDto, [FromRoute] int id)
    {
      var ExistingMovie = await _unitOfWork.MovieRepository.GetMovieById(id);
      if (ExistingMovie == null) return NotFound("Movie with specified id does not exists");
      var IsExistingTitle = await _unitOfWork.MovieRepository.GetMovieByTitle(movieDto.Title) != null;
      if (IsExistingTitle && ExistingMovie.Title != movieDto.Title) return BadRequest("Specified title exists for another movie");
      await _unitOfWork.MovieRepository.EditMovie(id, movieDto);
      if (await _unitOfWork.MovieRepository.SaveAllAsync()) return Ok();
      return BadRequest("Nothing edited");
    }
  }
}