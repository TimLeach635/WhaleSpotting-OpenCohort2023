using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WhaleSpotting.Models;

namespace WhaleSpotting.Controllers;

public class AdminController : Controller
{
    private readonly ILogger<AdminController> _logger;

    public AdminController(ILogger<AdminController> logger)
    {
        _logger = logger;
    }
}