using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace LibraryWebApp.Models.Http;

[ExcludeFromCodeCoverage]
public class BookResponse
{
    [JsonPropertyName("bookId")]
    public int BookId { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("author")]
    public string Author { get; set; }
    [JsonPropertyName("publicationYear")]
    public int PublicationYear { get; set; }
}
