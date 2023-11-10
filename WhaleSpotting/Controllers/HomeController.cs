using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhaleSpotting.Data;
using WhaleSpotting.Models;
using WhaleSpotting.ViewModels;

namespace WhaleSpotting.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var lastweek = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-7));

        var lastWeekPhotos = _context.Photos!
            .Include(p => p.Sighting)
            .Where(p => p.Sighting != null && p.Sighting.Date >= lastweek)
            .ToList();

        var viewModel = new HomeViewModel
        {
            LastWeekPhotos = lastWeekPhotos,
        };

        return View(viewModel);
    }

    public IActionResult GetInvolved()
    {
        var websites = _context.Websites!
            .ToList();

        return View(websites);
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
