using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WhaleSpotting.Data;
using WhaleSpotting.Models;

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
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

        [Route("api/images/lastweek")]
        [HttpGet]
        public IActionResult GetImagesFromLastWeek()
        {
            var lastweek = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-7));

            var sightings = _context.Sightings!
                .Where(sighting => sighting.Date >= lastweek)
                .ToList();

            if (sightings == null || sightings.Count == 0)
            {
                return NotFound("No images found from the last week.");
            }

            return Ok(sightings);
        }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
