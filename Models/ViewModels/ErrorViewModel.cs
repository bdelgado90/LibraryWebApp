using System.Diagnostics.CodeAnalysis;

namespace LibraryWebApp.Models.ViewModels;

[ExcludeFromCodeCoverage]
public class ErrorViewModel
{
    public string? RequestId { get; set; }
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
