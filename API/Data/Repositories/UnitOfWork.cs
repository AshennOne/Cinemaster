using API.Dtos;
using API.Entities;
using API.Interfaces;
using AutoMapper;

namespace API.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
        public UnitOfWork(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

        public IUserRepository UserRepository => new UserRepository(_context);

        public ICommentRepository CommentRepository => new CommentRepository(_context);

        public IMovieListRepository MovieListRepository => new MovieListRepository(_context);

        public IMovieRepository MovieRepository => new MovieRepository(_context, _mapper);

        public IRatingRepository RatingRepository => new RatingsRepository(_context);
    }
}