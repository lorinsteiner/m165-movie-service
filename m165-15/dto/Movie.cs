using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

class Movie(string title, int year, string summary, List<string> actors)
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("_id")]
    public ObjectId Id { get; set; }
    [BsonElement("title")]
    public string Title { get; set; } = title;
    [BsonElement("year")]
    [BsonIgnoreIfNull]
    public int? Year { get; set; } = year;
    [BsonElement("summary")]
    public string Summary { get; set; } = summary;
    [BsonElement("actors")]
    public List<string> Actors { get; set; } = actors;

}
