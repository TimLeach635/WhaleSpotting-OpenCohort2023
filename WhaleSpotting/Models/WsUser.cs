using Microsoft.AspNetCore.Identity;

namespace WhaleSpotting.Models;

public class WsUser
{
    public int Id { get; set; }
    public IdentityUser? IdentityUser { get; set; }
}
