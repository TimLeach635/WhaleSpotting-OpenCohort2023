using WhaleSpotting.Models;

namespace WhaleSpotting;

public class Sighting
{
    public int Id { get; set; }
    public WsUser? User { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public DateOnly Date { get; set; }
    public string? Description { get; set; }
    public List<Photo>? Photos { get; set; }
    public Boolean Approved { get; set; }
}
