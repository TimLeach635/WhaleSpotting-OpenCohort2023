using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhaleSpotting.Data;
using WhaleSpotting.Models;
using Microsoft.Extensions.Logging;

namespace WhaleSpotting.Controllers
{
    public class SpeciesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SpeciesController> _logger;

        public SpeciesController(ApplicationDbContext context, ILogger<SpeciesController> logger)
        {
            _context = context;
            _logger = logger;
        }

       public IActionResult Species()
        {
            var species = _context.Species!
                .ToList();

            return View(species);
        }

    }
}
