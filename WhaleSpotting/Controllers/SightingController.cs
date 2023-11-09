﻿using System.Diagnostics;
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
        // dynamic mymodel = new ExpandoObject();
        // mymodel.sightings = _context.Sightings!.ToList();
        // mymodel.photos = _context.Photos!.ToList();

        var sightings = _context.Sightings!
            .Include(s => s.Photos)
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
}
