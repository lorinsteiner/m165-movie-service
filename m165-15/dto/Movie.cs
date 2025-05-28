using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

class Movie(ObjectId id, string title, int year, string summary, List<string> actors)
{

    [BsonElement("_id")]
    [JsonPropertyName("_id")]
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId? Id { get; set; } = id;
    public string Title { get; set; } = title;
    public int Year { get; set; } = year;
    public string Summary { get; set; } = summary;
    public List<string> Actors { get; set; } = actors;

    public static Movie New(string title, int year, string summary, List<string> actors)
    {
        return new Movie(
            ObjectId.Empty,
            title,
            year,
            summary,
            actors
        );
    }

}