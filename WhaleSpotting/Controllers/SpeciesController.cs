using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WhaleSpotting.Data;
using WhaleSpotting.Models;

namespace WhaleSpotting.Controllers;

[Route("species")]
public class SpeciesController : Controller
{
    private readonly ILogger<SpeciesController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public SpeciesController
    (
        ILogger<SpeciesController> logger, 
        ApplicationDbContext context, 
        UserManager<IdentityUser> userManager
    ) {
        _logger = logger;
        _context = context;
        _userManager = userManager;
    }

    [HttpGet("{id}")]
    public IActionResult UniqueSpecies([FromRoute] int id)
    {
        if (User.Identity!.IsAuthenticated)
        {
            var wsUser = _context.WsUsers!
                .Single(u => u.IdentityUser!.Id == _userManager.GetUserId(User));
            ViewData["WsUserId"] = wsUser.Id;
        }

        var species = _context.Species;
        var uniqueSpecies= species!.Single(s => s.Id == id);

        return View(uniqueSpecies);
    }

    public IActionResult Index()
    {
         if (User.Identity!.IsAuthenticated)
        {
            var wsUser = _context.WsUsers!
                .Single(u => u.IdentityUser!.Id == _userManager.GetUserId(User));
            ViewData["WsUserId"] = wsUser.Id;
        }

        var species = _context.Species!.ToList();
        return View(species);
    }
}
