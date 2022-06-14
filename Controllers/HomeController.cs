using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ControleEstacionamentos.Models;

namespace ControleEstacionamentos.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        int? id = HttpContext.Session.GetInt32("Id");
        if(id == null)
        {
            return RedirectToAction("Login", "Funcionario");
        }
        Console.WriteLine(id);
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

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login", "Funcionario");
    }
}
