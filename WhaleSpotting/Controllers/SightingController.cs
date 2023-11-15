using System.Diagnostics;
using System.Dynamic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhaleSpotting.Data;
using WhaleSpotting.Models;
using WhaleSpotting.ViewModels;

namespace WhaleSpotting.Controllers;

[Route("sighting")]
[Authorize]
public class SightingController : Controller
{
    private readonly ILogger<SightingController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public SightingController
    (
        ILogger<SightingController> logger,
        ApplicationDbContext context,
        UserManager<IdentityUser> userManager
    ) {
        _logger = logger;
        _context = context;
        _userManager = userManager;
    }

    [AllowAnonymous]
    public IActionResult Index()
    {
        if (User.Identity!.IsAuthenticated)
        {
            var wsUser = _context.WsUsers!
                .Single(u => u.IdentityUser!.Id == _userManager.GetUserId(User));
            ViewData["WsUserId"] = wsUser.Id;
        }

        var approvedSightings = _context.Sightings!
            .Where(sighting => sighting.Approved)
            .Include(s => s.User)
            .Include(p => p.Photos)
            .ToList();

        return View(approvedSightings);
    }
    
    [HttpPost("")]
    public IActionResult NewSighting([FromForm] NewSightingFormViewModel newSightingViewModel)
    {
        if (User.Identity!.IsAuthenticated)
        {
            var wsUser = _context.WsUsers!
                .Single(u => u.IdentityUser!.Id == _userManager.GetUserId(User));
            ViewData["WsUserId"] = wsUser.Id;
        }

        var speciesId = newSightingViewModel.SpeciesId;
        Species species = _context.Species!
            .Where(speciesCheck => speciesCheck.Id == speciesId)
            .First();
        newSightingViewModel.Sighting!.Species = species;
        
        _context.Sightings?.Add(newSightingViewModel.Sighting!);
        _context.SaveChanges();

        return Ok();
    }
    
    [HttpGet("new")]
    public IActionResult NewSightingForm()
    {
        if (User.Identity!.IsAuthenticated)
        {
            var wsUser = _context.WsUsers!
                .Single(u => u.IdentityUser!.Id == _userManager.GetUserId(User));
            ViewData["WsUserId"] = wsUser.Id;
        }
        
        var species = _context.Species!.ToList();
        var sighting = new Sighting();
        var viewModel = new NewSightingFormViewModel
        {
            ListOfSpecies = species,
            Sighting = sighting,
        };
        return View(viewModel);
    }

}
