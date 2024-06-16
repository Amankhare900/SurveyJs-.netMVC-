using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoMVCApp.Models;

namespace DemoMVCApp.Controllers;

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
    public IActionResult LoadSurveyJs()
    {
        
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "APP_DATA", "surveyjs.json");

        string fileContents;
        SurveyJsViewModel model = new();
        try
        {
            fileContents = System.IO.File.ReadAllText(filePath);
            model.JsonData = fileContents;
        }
        catch (IOException ex)
        {
            return Content($"Error reading file: {ex.Message}");
        }
        return View(model);
    }
}
