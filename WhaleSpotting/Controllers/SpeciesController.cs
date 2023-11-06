using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WhaleSpotting.Models;

namespace WhaleSpotting.Controllers;

public class SpeciesController : Controller
{
    private readonly ILogger<SpeciesController> _logger;

    public SpeciesController(ILogger<SpeciesController> logger)
    {
        _logger = logger;
    }
}
