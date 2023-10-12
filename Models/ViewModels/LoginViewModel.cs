using System.Diagnostics.CodeAnalysis;

namespace LibraryWebApp.Models.ViewModels;

[ExcludeFromCodeCoverage]
public class LoginViewModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}
