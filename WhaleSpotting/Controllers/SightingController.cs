using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WhaleSpotting.Models;

namespace WhaleSpotting.Controllers;

public class SightingController : Controller
{
    private readonly ILogger<SightingController> _logger;

    public SightingController(ILogger<SightingController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}
