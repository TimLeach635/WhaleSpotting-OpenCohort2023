using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WhaleSpotting.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Sighting>? Sightings { get; set; }
    public DbSet<Species>? Species { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}