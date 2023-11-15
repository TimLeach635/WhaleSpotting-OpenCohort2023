using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
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
    private readonly UserManager<IdentityUser> _userManager;

    public HomeController
    (
        ILogger<HomeController> logger,
        ApplicationDbContext context,
        UserManager<IdentityUser> userManager
    ) {
        _logger = logger;
        _context = context;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        if (User.Identity!.IsAuthenticated)
        {
            var wsUser = _context.WsUsers!
                .Single(u => u.IdentityUser!.Id == _userManager.GetUserId(User));
            ViewData["WsUserId"] = wsUser.Id;
        }

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
        if (User.Identity!.IsAuthenticated)
        {
            var wsUser = _context.WsUsers!
                .Single(u => u.IdentityUser!.Id == _userManager.GetUserId(User));
            ViewData["WsUserId"] = wsUser.Id;
        }

        var websites = _context.Websites!
            .ToList();

        return View(websites);
    }

    public IActionResult Privacy()
    {
        if (User.Identity!.IsAuthenticated)
        {
            var wsUser = _context.WsUsers!
                .Single(u => u.IdentityUser!.Id == _userManager.GetUserId(User));
            ViewData["WsUserId"] = wsUser.Id;
        }

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        if (User.Identity!.IsAuthenticated)
        {
            var wsUser = _context.WsUsers!
                .Single(u => u.IdentityUser!.Id == _userManager.GetUserId(User));
            ViewData["WsUserId"] = wsUser.Id;
        }

        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
