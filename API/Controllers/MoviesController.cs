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
    private readonly IMovieRepository _movieRepository;
    public MoviesController(IMovieRepository movieRepository)
    {
      _movieRepository = movieRepository;

    }
    [HttpPost]
    public async Task<ActionResult> CreateMovie(MovieDto movieDto)
    {
      var ExistingMovie = await _movieRepository.GetMovieByTitle(movieDto.Title);
      if (ExistingMovie != null) return BadRequest("Movie with specified title already exists");
      await _movieRepository.AddMovie(movieDto);
      if (await _movieRepository.SaveAllAsync()) return Ok();
      return BadRequest("Something went wrong");
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
    {
      return Ok(await _movieRepository.GetAllMovies());
    }
    [HttpGet("{title}")]
    public async Task<ActionResult<Movie>> GetMovie(string title)
    {
      var movie = await _movieRepository.GetMovieByTitle(title);
      if (movie == null) return NotFound("Title does not exists");
      return Ok(movie);
    }
    [HttpDelete("{title}")]
    public async Task<ActionResult> DeleteMovie(string title)
    {
      await _movieRepository.DeleteMovie(title);
      await _movieRepository.SaveAllAsync();
      return NoContent();
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> EditMovie([FromBody] MovieDto movieDto, [FromRoute] int id)
    {
      var ExistingMovie = await _movieRepository.GetMovieById(id);
      if (ExistingMovie == null) return NotFound("Movie with specified id does not exists");
      var IsExistingTitle = await _movieRepository.GetMovieByTitle(movieDto.Title) != null;
      if (IsExistingTitle && ExistingMovie.Title != movieDto.Title) return BadRequest("Specified title exists for another movie");
      await _movieRepository.EditMovie(id, movieDto);
      if (await _movieRepository.SaveAllAsync()) return Ok();
      return BadRequest("Nothing edited");
    }
  }
}