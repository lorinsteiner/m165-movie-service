
using System.Linq.Expressions;
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

    public List<string> GetCollections()
    {
        return _database.ListCollectionNames().ToList();
    }

    public List<string> GetDatabases()
    {
        return _client.ListDatabaseNames().ToList();
    }

    public List<Movie> GetMovies()
    {
        return _movies.Find(_ => true).ToList();
    }

    public List<Movie> GetMovies(Expression<Func<Movie, bool>> filter)
    {
        return _movies.Find(filter).ToList();
    }
}