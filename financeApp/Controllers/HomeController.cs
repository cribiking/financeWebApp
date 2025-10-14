using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using financeApp.Models;

namespace financeApp.Controllers;

/*
Take control of the backend of our app, takes requests from users, querys the necessary data from
the database, ans then return the prper anwer with the correponding view to the user
*/

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
