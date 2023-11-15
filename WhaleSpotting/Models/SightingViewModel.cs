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

    public static implicit operator SightingViewModel(Sighting v)
    {
        return new SightingViewModel
        {
            Date = new DateTime(v.Date.Year, v.Date.Month, v.Date.Day),
            Description = v.Description,
            Photos = v.Photos,
        };
        throw new NotImplementedException();
    }
}
