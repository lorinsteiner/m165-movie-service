using System.Collections.Immutable;
using System.Linq.Expressions;

interface IMovieService
{
    List<String> GetDatabases();

    List<String> GetCollections();

    List<Movie> GetMovies();

    Movie? GetMovieEquals<V>(Expression<Func<Movie, V>> field, V value);
    Movie? GetMovie(Expression<Func<Movie, bool>> filter);

    List<Movie> GetMoviesEquals<V>(Expression<Func<Movie, V>> field, V value);
    List<Movie> GetMoviesContainActor(string[] actor);
    List<Movie> GetMovies(Expression<Func<Movie, bool>> filter);

    void InsertMovie(Movie movie);

    void InsertMovies(List<Movie> movies);

    long UpdateMovies<V>(Expression<Func<Movie, bool>> filter, string field, V newValue);

    long DeleteMovies(Expression<Func<Movie, bool>> filter);

    //ImmutableSortedDictionary<int?, int> GetNumberOfMoviesPerYear(Expression<Func<Movie, bool>> filter);

    String GetMoviesAsJson();
}