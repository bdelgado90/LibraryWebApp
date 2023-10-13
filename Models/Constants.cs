using System.Diagnostics.CodeAnalysis;

namespace LibraryWebApp.Models;

[ExcludeFromCodeCoverage]
public class SessionVariables
{
    public const string SessionTokenName = "jwtToken";
}

public class AuthorizationVariables
{
    public const string Bearer = "Bearer";
}

public class ApiUrls
{
    public const string ApiBaseUrl = "https://librarywebapidemo.azurewebsites.net/api";
    public const string ApiBooksUrl = $"{ApiBaseUrl}/books";
    public const string ApiLoginUrl = $"{ApiBaseUrl}/users/login";
}

public class Errors
{
    public const string InvalidLogin = "Invalid login attempt.";
    public const string BookIdRequired = "Book ID is required";
    public const string ErrorAddingBook = "Error adding book.";
    public const string ErrorUpdatingBook = "Error updating book.";
    public const string ErrorDeletingBook = "Error deleting book.";
}

public class ContentTypes
{
    public const string ApplicationJsonType = "application/json";
}
