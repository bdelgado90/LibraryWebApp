using System.Security.Claims;
using LibraryWebApp.Models;
using LibraryWebApp.Models.Http;
using LibraryWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.Controllers;

[AllowAnonymous]
public class LoginController : SessionController
{
    public LoginController(IHttpClientFactory clientFactory) : base(clientFactory) { }
    
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(LoginViewModel model)
    {
        var response = await PostAsync(ApiUrls.ApiLoginUrl, model);
    
        if (response.IsSuccessStatusCode)
        {
            var jwtResponse = await DeserializeResponseAsync<LoginResponse>(response);
            HttpContext.Session.SetString(SessionVariables.SessionTokenName, jwtResponse.Token);
            
            var claims = new List<Claim> { new (ClaimTypes.Name, model.Username) };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);

            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError(string.Empty, Errors.InvalidLogin);
        return View(model);
    }
}
