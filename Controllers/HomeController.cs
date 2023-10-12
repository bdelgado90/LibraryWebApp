using LibraryWebApp.Models;
using LibraryWebApp.Models.Http;
using LibraryWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.Controllers;

[Authorize]
public class HomeController : SessionController
{
    public HomeController(IHttpClientFactory clientFactory) : base(clientFactory) { }

    public async Task<IActionResult> Index()
    {
        var response = await GetAsync(ApiUrls.ApiBooksUrl);
        if (!response.IsSuccessStatusCode) return NotFound();
        
        var books = await DeserializeResponseAsync<List<BookResponse>>(response);
        return View(books);
    }

    public IActionResult Add()
    {
        return View("Manage", new BookViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Add(BookViewModel model)
    {
        var response = await PostAsync(ApiUrls.ApiBooksUrl, model);
        return response.IsSuccessStatusCode ? RedirectToAction("Index") : BadRequest(Errors.ErrorAddingBook);
    }

    public async Task<IActionResult> Edit(int bookId)
    {
        var response = await GetAsync($"{ApiUrls.ApiBooksUrl}/{bookId}");
        if (!response.IsSuccessStatusCode) return NotFound();
    
        var book = await DeserializeResponseAsync<BookResponse>(response);
        var viewModel = new BookViewModel
        {
            BookId = book.BookId,
            Title = book.Title,
            Author = book.Author,
            PublicationYear = book.PublicationYear
        };
        return View("Manage", viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(BookViewModel model)
    {
        if (!model.BookId.HasValue)
        {
            return BadRequest(Errors.BookIdRequired);
        }

        var response = await PutAsync($"{ApiUrls.ApiBooksUrl}/{model.BookId.Value}", model);
        return response.IsSuccessStatusCode ? RedirectToAction("Index") : BadRequest(Errors.ErrorUpdatingBook);
    }

    public async Task<IActionResult> Delete(int bookId)
    {
        var response = await DeleteAsync($"{ApiUrls.ApiBooksUrl}/{bookId}");
        return response.IsSuccessStatusCode ? RedirectToAction("Index") : BadRequest(Errors.ErrorDeletingBook);
    }
}
