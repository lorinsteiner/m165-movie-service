using System.Linq.Expressions;

interface IMovieService
{
    List<String> GetDatabases();

    List<String> GetCollections();

    List<Movie> GetMovies();

    Movie? GetMovie(Expression<Func<Movie, bool>> filter);

    List<Movie> GetMovies(Expression<Func<Movie, bool>> filter);

    Movie InsertMovie(Movie movie);

    List<Movie> InsertMovies(List<Movie> movies);

    List<Movie> UpdateMovies(Expression<Func<Movie, bool>> filter, Movie movie);

    List<Movie> DeleteMovies(Expression<Func<Movie, bool>> filter);

    Dictionary<TKey, List<Movie>> GroupMovies(Expression<Func<Movie, TKey>> mapping);
}