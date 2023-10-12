using System.Net.Http.Headers;
using LibraryWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.Controllers;

public abstract class SessionController : Controller
{
    private readonly IHttpClientFactory clientFactory;

    protected SessionController(IHttpClientFactory clientFactory)
    {
        this.clientFactory = clientFactory;
    }

    private HttpClient CreateAuthorizedClient()
    {
        var client = clientFactory.CreateClient();
        var token = HttpContext.Session.GetString(SessionVariables.SessionTokenName);
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthorizationVariables.Bearer, token);
        return client;
    }

    protected async Task<HttpResponseMessage> GetAsync(string endpoint)
    {
        var client = CreateAuthorizedClient();
        return await client.GetAsync(endpoint);
    }

    protected async Task<HttpResponseMessage> PostAsync<T>(string endpoint, T content)
    {
        var client = CreateAuthorizedClient();
        return await client.PostAsJsonAsync(endpoint, content);
    }

    protected async Task<HttpResponseMessage> PutAsync<T>(string endpoint, T content)
    {
        var client = CreateAuthorizedClient();
        return await client.PutAsJsonAsync(endpoint, content);
    }

    protected async Task<HttpResponseMessage> DeleteAsync(string endpoint)
    {
        var client = CreateAuthorizedClient();
        return await client.DeleteAsync(endpoint);
    }

    protected async Task<T> DeserializeResponseAsync<T>(HttpResponseMessage response)
    {
        return await response.Content.ReadFromJsonAsync<T>();
    }
}
