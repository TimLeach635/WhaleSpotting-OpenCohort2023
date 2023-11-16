using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WhaleSpotting.Models;
using WhaleSpotting.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace WhaleSpotting.Controllers;

[Authorize(Roles = "Admin")]
[Route("admin")]
public class AdminController : Controller
{
    private readonly ILogger<AdminController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public AdminController
    (
        ILogger<AdminController> logger,
        ApplicationDbContext context,
        UserManager<IdentityUser> userManager
    ) {
        _logger = logger;
        _context = context;
        _userManager = userManager;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        if (User.Identity!.IsAuthenticated)
        {
            var wsUser = _context.WsUsers!
                .Single(u => u.IdentityUser!.Id == _userManager.GetUserId(User));
            ViewData["WsUserId"] = wsUser.Id;
        }

        var unapprovedSightings = _context.Sightings!
            .Where(sighting => !sighting.Approved)
            .Include(s => s.User)
            .Include(p => p.Photos)
            .ToList();

        return View(unapprovedSightings);
    }

    [HttpPost("approve")]
    public IActionResult ApproveSightings(List<int> selectedSightingIds)
    {
        if (User.Identity!.IsAuthenticated)
        {
            var wsUser = _context.WsUsers!
                .Single(u => u.IdentityUser!.Id == _userManager.GetUserId(User));
            ViewData["WsUserId"] = wsUser.Id;
        }
        
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

    [HttpGet("assign")]
    public IActionResult AssignAdmin()
    {
        return View();
    }

    [HttpPost("assign")]
    public async Task<IActionResult> CheckInput([FromForm] string userinput) 
    {
        var users = _context.WsUsers!
            .Include(u => u.IdentityUser)
            .ToList();
        foreach(var user in users)
        {
            if(user.Name == userinput)
            {
                await _userManager.AddToRoleAsync(user.IdentityUser!, "Admin");
            }
        } 
        
        return RedirectToAction("AssignAdmin");
    }

    [HttpDelete("sighting/{sightingId}")]
    public IActionResult DeleteSighting([FromRoute] int sightingId)
    {
        Sighting sighting;
        try
        {
            sighting = _context.Sightings!
                .Include(s => s.Photos)
                .Single(s => s.Id == sightingId);
        }
        catch (InvalidOperationException)
        {
            // This means there is no sighting with the given ID
            return NotFound();
        }

        _context.Sightings!.Remove(sighting);
        _context.SaveChanges();

        return Ok();
    }
}
