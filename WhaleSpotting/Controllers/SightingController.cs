﻿using System.Diagnostics;
using System.Dynamic;
using Microsoft.AspNetCore.Authorization;
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

    public SightingController(ILogger<SightingController> logger,
        ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [AllowAnonymous]
    public IActionResult Index()
    {
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
        try
        {
            var newSighting = new Sighting();
            newSighting.User = new WsUser();
            newSighting.Latitude = newSightingViewModel.Sighting!.Latitude;
            newSighting.Longitude = newSightingViewModel.Sighting!.Longitude;
            newSighting.Description = newSightingViewModel.Sighting!.Description;
            newSighting.Species = newSightingViewModel.Sighting!.Species;
            newSighting.Date = DateOnly.FromDateTime(newSightingViewModel.Sighting!.Date);
            newSighting.Photos = newSightingViewModel.Sighting!.Photos;

            var speciesId = newSightingViewModel.SpeciesId;
            Species selectedSpecies = _context.Species!
                .Where(speciesCheck => speciesCheck.Id == speciesId)
                .First();
            newSighting.Species = selectedSpecies;

            var userId = newSighting.User!.Id;
            newSighting.User = new WsUser { Id = userId }; 

            _context.Sightings?.Add(newSighting);
            _context.SaveChanges();
            
            return RedirectToAction("SightingSubmitted");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "An error occurred while adding the sighting.");

        TempData["ErrorMessage"] = "An error occurred while adding the sighting.";
    }

    var species = _context.Species!.ToList();
    var viewModel = new NewSightingFormViewModel
    {
        ListOfSpecies = species,
        Sighting = new SightingViewModel(),
    };

    ViewData["ConfirmationMessage"] = TempData["ConfirmationMessage"];
    ViewData["ErrorMessage"] = TempData["ErrorMessage"];

    return View("NewSightingForm", viewModel);
}

    [HttpGet("new")]
    public IActionResult NewSightingForm()
    {
        var species = _context.Species!.ToList();
        var sighting = new SightingViewModel();
        var viewModel = new NewSightingFormViewModel
        {
            ListOfSpecies = species,
            Sighting = sighting,
        };
        return View(viewModel);
    }

    [HttpGet("submitted")]
    public IActionResult SightingSubmitted()
    {
        return View();
    }

}
