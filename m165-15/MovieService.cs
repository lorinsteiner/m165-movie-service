
using System.Collections.Immutable;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;

class MovieService : IMovieService
{

    private static readonly string CONNECTION = "mongodb://localhost:27017";
    private static readonly string DATABASE_NAME = "M165";
    private static readonly string COLLECTION_NAME = "Movies";

    private readonly MongoClient _client;
    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<Movie> _movies;

    public MovieService()
    {
        _client = new MongoClient(CONNECTION);
        _database = _client.GetDatabase(DATABASE_NAME);
        _movies = _database.GetCollection<Movie>(COLLECTION_NAME);
    }

    public long DeleteMovies(Expression<Func<Movie, bool>> filter)
    {
        return _movies.DeleteMany(filter).DeletedCount;
    }

    public List<string> GetCollections()
    {
        return _database.ListCollectionNames().ToList();
    }

    public List<string> GetDatabases()
    {
        return _client.ListDatabaseNames().ToList();
    }

    public Movie? GetMovie(Expression<Func<Movie, bool>> filter)
    {
        return _movies.Find(filter).ToList().FirstOrDefault();
    }

    public List<Movie> GetMovies()
    {
        return _movies.Find(_ => true).ToList();
    }

    public List<Movie> GetMovies(Expression<Func<Movie, bool>> filter)
    {
        return _movies.Find(filter).ToList();
    }

    public string GetMoviesAsJson()
    {
        return _movies.Find(_ => true).ToJson();
    }

    /*public ImmutableSortedDictionary<int?, int> GetNumberOfMoviesPerYear(Expression<Func<Movie, bool>> filter)
    {
        return _movies.AsQueryable()
        .Where(filter)
        .GroupBy(movie => movie.Year)
        .Select(g => new { Year = g.Key, Count = g.Count() })
        .ToImmutableSortedDictionary(g => g.Year, g => g.Count);
    }*/

    public void InsertMovie(Movie movie)
    {
        _movies.InsertOne(movie);
    }

    public void InsertMovies(List<Movie> movies)
    {
        _movies.InsertMany(movies);
    }

    public long UpdateMovies<V>(Expression<Func<Movie, bool>> filter, string field, V newValue)
    {
        UpdateDefinition<Movie> updateDefinition = Builders<Movie>.Update.Combine(
            Builders<Movie>.Update.Set(field, newValue)
        );
        return _movies.UpdateMany(filter, updateDefinition).ModifiedCount;
    }
}