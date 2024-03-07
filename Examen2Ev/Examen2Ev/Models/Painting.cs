using System.Text.Json.Serialization;

namespace Examen2Ev.Models;

public class Painting
{
    public string Title { get; set; }
    public int Year { get; set; }
    [JsonPropertyName("genre_id")] public int GenreId { get; set; }
    public string Genre { get; set; }
    public string File { get; set; }
}

public class ArtistDetail
{
    public List<Painting> Images { get; set; }
}
