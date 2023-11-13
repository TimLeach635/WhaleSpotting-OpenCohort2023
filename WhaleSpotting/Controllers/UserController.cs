using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhaleSpotting.Data;
using WhaleSpotting.Models;

namespace WhaleSpotting.Controllers;

[Route("users")]
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly ApplicationDbContext _context;
    public UserController(ILogger<UserController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("{id}")]
    public IActionResult UserPage([FromRoute] int id)
    {
        var user = _context.WsUsers!
            .Include(u => u.Sightings)
            .Single(u => u.Id == id);

    
           return View(user); 
        
    }

    [HttpGet("{id}/edit")]
    public IActionResult EditUser(int id)
    {
        var user = _context.WsUsers!.Find(id);
        return View(user);
    }

    [HttpPost("{id}")]
    public IActionResult EditUser
    (
        [FromRoute] int id,
        [FromForm] WsUser modifiedUser
    ) {
        var user = _context.WsUsers!
            .Single(u => u.Id == id);

        if (!string.IsNullOrEmpty(modifiedUser.Name))
        {
            user.Name = modifiedUser.Name;
        }

        if (!string.IsNullOrEmpty(modifiedUser.ProfileImageUrl))
        {
           user.ProfileImageUrl = modifiedUser.ProfileImageUrl; 
        }

        if (!string.IsNullOrEmpty(modifiedUser.Bio))
        {
            user.Bio = modifiedUser.Bio;
        }

        _context.SaveChanges();

        return Ok();
    }
}