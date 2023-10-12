using System.Diagnostics.CodeAnalysis;

namespace LibraryWebApp.Models.ViewModels;

[ExcludeFromCodeCoverage]
public class BookViewModel
{
    public int? BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublicationYear { get; set; }
}