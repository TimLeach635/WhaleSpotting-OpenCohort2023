using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
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
    private readonly UserManager<IdentityUser> _userManager;
    public UserController
    (
        ILogger<UserController> logger,
        ApplicationDbContext context,
        UserManager<IdentityUser> userManager
    ) {
        _logger = logger;
        _context = context;
        _userManager = userManager;
    }

    [HttpGet("{id}")]
    public IActionResult UserPage([FromRoute] int id)
    {
        if (User.Identity!.IsAuthenticated)
        {
            var wsUser = _context.WsUsers!
                .Single(u => u.IdentityUser!.Id == _userManager.GetUserId(User));
            ViewData["WsUserId"] = wsUser.Id;
        }

        var user = _context.WsUsers!
            .Include(u => u.Sightings)
            .Single(u => u.Id == id);

        return View(user);  
    }

    [HttpGet("{id}/edit")]
    public IActionResult EditUserForm(int id)
    {
        if (User.Identity!.IsAuthenticated)
        {
            var wsUser = _context.WsUsers!
                .Single(u => u.IdentityUser!.Id == _userManager.GetUserId(User));
            ViewData["WsUserId"] = wsUser.Id;
        }

        var user = _context.WsUsers!.Find(id);
        return View(user);
    }

    [HttpPost("{id}")]
    public IActionResult EditUser
    (
        [FromRoute] int id,
        [FromForm] WsUser modifiedUser
    ) {
        if (User.Identity!.IsAuthenticated)
        {
            var wsUser = _context.WsUsers!
                .Single(u => u.IdentityUser!.Id == _userManager.GetUserId(User));
            ViewData["WsUserId"] = wsUser.Id;
        }

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

        return RedirectToAction("UserPage", new RouteValueDictionary { { "id", id } });
    }
}