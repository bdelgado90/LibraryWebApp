using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace LibraryWebApp.Models.Http;

[ExcludeFromCodeCoverage]
public class LoginResponse
{
    [JsonPropertyName("token")]
    public string Token { get; set; }
}
