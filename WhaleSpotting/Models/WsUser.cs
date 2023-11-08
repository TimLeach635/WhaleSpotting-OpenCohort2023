using Microsoft.AspNetCore.Identity;

namespace WhaleSpotting.Models;

public class WsUser
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? ProfileImageUrl { get; set; }
    public string? Bio { get; set; }
    public IdentityUser? IdentityUser { get; set; }
    public List<Sighting>? Sightings { get; set; }
}
