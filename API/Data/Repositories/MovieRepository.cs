using API.Dtos;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
  public class MovieRepository : IMovieRepository
  {
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public MovieRepository(ApplicationDbContext context,IMapper mapper)
    {
      _mapper = mapper;
      _context = context;

    }

    public async Task AddMovie(MovieDto movieDto)
    {
      var movie = _mapper.Map<Movie>(movieDto);
      await _context.Movies.AddAsync(movie);
      
    }

    public async Task DeleteMovie(string title)
    {
      var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Title == title);
      _context.Movies.Remove(movie);
    }



    public async Task EditMovie(int Id, MovieDto editedMovieDto)
    {
      var oldMovie = await _context.Movies.Include(m => m.Ratings).Include(m => m.Comments).FirstOrDefaultAsync(m => m.Id == Id);
      oldMovie.Title = editedMovieDto.Title;
      oldMovie.Genre = editedMovieDto.Genre;
      oldMovie.Premiere = editedMovieDto.Premiere;
      oldMovie.Description = editedMovieDto.Description;
      oldMovie.ImgUrl = editedMovieDto.ImgUrl;
      oldMovie.Duration = editedMovieDto.Duration;

    }

    public async Task<MoviePaginationEntity> GetAllMovies(int currentPage)
    {
      int pageSize = 8;
      var totalItems = await _context.Movies.CountAsync();
      var movies = await _context.Movies.Skip((currentPage -1)*pageSize).Take(pageSize).Include(m => m.Ratings).Include(m => m.Comments).ToListAsync();
      return new MoviePaginationEntity{
        Movies = movies,
        TotalItems = totalItems
      };
      
    }

    public async Task<Movie> GetMovieById(int id)
    {
      return await _context.Movies.Include(m => m.Ratings).Include(m => m.Comments).FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Movie> GetMovieByTitle(string title)
    {
      return await _context.Movies.Include(m => m.Ratings).Include(m => m.Comments).FirstOrDefaultAsync(m => m.Title == title);
    }

    public async Task<bool> SaveAllAsync()
    {
      if(await _context.SaveChangesAsync()>0) return true;
      return false;
    }
  }
}