using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WhaleSpotting.Data;
using WhaleSpotting.Models;

namespace WhaleSpotting.Controllers;

public class SpeciesController : Controller
{
    private readonly ILogger<SpeciesController> _logger;
    private readonly ApplicationDbContext _context;

    public SpeciesController(ILogger<SpeciesController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public IActionResult Index()
    {
        var context = _context.Species!.ToList();
        return View(context);
    }
}
