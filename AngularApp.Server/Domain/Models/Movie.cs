using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AngularApp.Server.Domain.Models
{
    [BsonIgnoreExtraElements]
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("title")]
        public string Title { get; set; } = string.Empty;

        [BsonElement("director")]
        public string Director { get; set; } = string.Empty;

        [BsonElement("release_year")]
        public int ReleaseYear { get; set; }

        [BsonElement("genre")]
        //[BsonRepresentation(BsonType.Array)]
        public List<string> Genre { get; set; }
        [BsonElement("actors")]
        //[BsonRepresentation(BsonType.Array)]
        public List<string> Actors { get; set; }

        [BsonElement("country")]
        public string Country { get; set; } = string.Empty;

        [BsonElement("duration_minutes")]
        [BsonIgnore]
        public int DurationMinutes { get; set; }

        [BsonElement("is_released")]
        public bool IsReleased { get; set; }

        [BsonElement("rating")]
        public double? Rating { get; set; }

        [BsonElement("slug")]
        public string Slug { get; set; } = string.Empty;

        [BsonElement("image")]
        public string Image { get; set; } = string.Empty;

        [BsonElement("description")]
        public string Description { get; set; } = string.Empty;

        [BsonElement("watched")]
        public bool Watched { get; set; }
    }
}

