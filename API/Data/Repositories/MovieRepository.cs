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

    public async Task<MoviePaginationEntity> GetAllMovies(int currentPage, MovieParams movieParams)
    {
      int pageSize = 8;
      
      var allFilteredMovies = await _context.Movies.Where(m=> m.Premiere >= movieParams.From && m.Premiere <= movieParams.To && m.Duration<= movieParams.MaxDuration && m.Duration>= movieParams.MinDuration ).Include(m => m.Ratings).Include(m => m.Comments).Include(m => m.LikedByUsers).ToListAsync();
       var totalItems =  allFilteredMovies.Count();
       switch(movieParams.SortOrder){
      case SortOrder.PremiereAsc:
        allFilteredMovies = allFilteredMovies.OrderBy(m => m.Premiere).ToList();
        break;
      case SortOrder.PremiereDesc:
        allFilteredMovies = allFilteredMovies.OrderByDescending(m => m.Premiere).ToList();
        break;
      case SortOrder.TitleAsc:
        allFilteredMovies = allFilteredMovies.OrderBy(m => m.Title).ToList();
        break;
       case SortOrder.TitleDesc:
        allFilteredMovies = allFilteredMovies.OrderByDescending(m => m.Title).ToList();
        break;
        case SortOrder.RatingDesc:
        foreach(var movie in allFilteredMovies){
          double sum = 0.0;
          double count = 0.0;
          foreach(var rate in movie.Ratings){
            sum += rate.Grade;
            count++;
          }
          if(movie.Ratings.Count()>0){
            movie.AvgRating = Convert.ToDouble(sum/count);
          }else{
            movie.AvgRating = 0;
          }
          
        }
        allFilteredMovies = allFilteredMovies.OrderByDescending(m => m.AvgRating).ToList();
        break;
    }
     var movies =  allFilteredMovies.Skip((currentPage -1)*pageSize).Take(pageSize);
      
    

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