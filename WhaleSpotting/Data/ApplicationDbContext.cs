﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WhaleSpotting.Models;

namespace WhaleSpotting.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Sighting>? Sightings { get; set; }
    public DbSet<Photo>? Photos { get; set; }
    public DbSet<Species>? Species { get; set; }
    public DbSet<Website>? Websites { get; set; }
    public DbSet<WsUser>? WsUsers { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}