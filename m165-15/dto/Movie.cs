using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

class Movie(string title, int year, string summary, List<string> actors)
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("_id")]
    public ObjectId Id { get; set; }
    public string Title { get; set; } = title;
    public int? Year { get; set; } = year;
    public string Summary { get; set; } = summary;
    public List<string> Actors { get; set; } = actors;

}
