using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WhaleSpotting.Models;
using WhaleSpotting.Data;

namespace WhaleSpotting.Controllers;

public class AdminController : Controller
{
    private readonly ILogger<AdminController> _logger;
     private readonly ApplicationDbContext _context;

    public AdminController(ILogger<AdminController> logger,
         ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

     public IActionResult Index()
    {
        var unapprovedSightings = _context.Sightings!
            .Where(sighting => !sighting.Approved)
            .ToList();

        return View(unapprovedSightings);
    }
    [HttpPost]
    public IActionResult ApproveSightings(List<int> selectedSightingIds)
    {
        if (selectedSightingIds != null && selectedSightingIds.Any())
        {
            var selectedSightings = _context.Sightings!
                .Where(s => selectedSightingIds.Contains(s.Id))
                .ToList();

            foreach (var sighting in selectedSightings)
            {
                sighting.Approved = true;
            }

            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }
}
