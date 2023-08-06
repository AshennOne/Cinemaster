namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository {get;}
        ICommentRepository CommentRepository{get;}
        IMovieListRepository MovieListRepository {get;}
        IMovieRepository MovieRepository{get;}
        IRatingRepository RatingRepository{get;}
        

    }
}