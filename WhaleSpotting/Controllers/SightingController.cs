using System.Diagnostics;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhaleSpotting.Data;
using WhaleSpotting.Models;

namespace WhaleSpotting.Controllers;

[Route("sighting")]
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
        var approvedSightings = _context.Sightings!
            .Where(sighting => sighting.Approved)
            .Include(s => s.User)
            .Include(p => p.Photos)
            .ToList();

        return View(approvedSightings);
    }

    [HttpGet("location")]
    public IActionResult SightingLocation()
    {
        var sightings = _context.Sightings!
            .Include(s => s.Photos)
            .ToList();
        return View(sightings);
    }

    // [HttpPost("")]
    // public IActionResult NewSighting([FromForm] Sighting newSighting)
    // {
    //     _context.Sightings?.Add(newSighting);
    //     _context.SaveChanges();

    //     return Ok();
    // }

    [HttpPost]
    public IActionResult NewSighting([FromForm] Sighting newSighting)
    {

        if (ModelState.IsValid)
        {
            _context.Sightings?.Add(newSighting);
            _context.SaveChanges();


            return RedirectToAction("NewSightingCompletion", new { id = newSighting.Id });
        }


        return View("NewSightingForm", newSighting);
    }

    [HttpGet("new")]
    public IActionResult NewSightingForm()
    {
        return View();
    }

}

