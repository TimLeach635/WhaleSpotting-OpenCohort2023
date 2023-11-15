using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WhaleSpotting.Models;

namespace WhaleSpotting;

public class SightingViewModel
{
    public WsUser? User { get; set; }
    public Species? Species { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public List<Photo>? Photos { get; set; }

    public Sighting toSighting()     
    {
        return new Sighting
        {
            User = this.User,
            Species = this.Species,
            Latitude = this.Latitude,
            Longitude = this.Longitude,
            Date = DateOnly.FromDateTime(Date),
            Description = this.Description,
            Photos = this.Photos,
            Approved = false
        };
        throw new NotImplementedException();
    }

}
