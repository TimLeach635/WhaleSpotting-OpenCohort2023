using Microsoft.AspNetCore.Mvc;
using WhaleSpotting.Data;
using WhaleSpotting.Models;

namespace WhaleSpotting.Controllers;

[Route("species")]
public class SpeciesController : Controller
{
    private readonly ILogger<SpeciesController> _logger;
    private readonly ApplicationDbContext _context;

    public SpeciesController(ILogger<SpeciesController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("{slug}")]
    public IActionResult UniqueSpecies([FromRoute] string slug)
    {
        var species = _context.Species;
        var uniqueSpecies= species!.Single(s => s.Slug == slug);

        return View(uniqueSpecies);
    }

    public IActionResult Index()
    {
        var species = _context.Species!.ToList();
        return View(species);
    }
}
