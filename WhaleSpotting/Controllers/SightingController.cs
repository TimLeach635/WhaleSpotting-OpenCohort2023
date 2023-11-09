using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhaleSpotting.Data;
using WhaleSpotting.Models;

namespace WhaleSpotting.Controllers;

public class SightingController : Controller
{
    private readonly ILogger<SightingController> _logger;
    private readonly ApplicationDbContext _context;

    public SightingController(ILogger<SightingController> logger,
        ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var sightings = _context.Sightings!
            .Include(s => s.User)
            .ToList();

        return View(sightings);
    }

    public IActionResult SightingLocation()
    {
        var sightings = _context.Sightings!
            .ToList();

        return View(sightings);
    }
    [HttpPost("")]
    public IActionResult NewSighting([FromForm] Sighting newSighting)
    {
        _context.Sightings?.Add(newSighting);
        _context.SaveChanges();

        return Ok();
    }
    [HttpGet("new")]
    public IActionResult NewSightingForm()
    {
        return View();
    }

}

