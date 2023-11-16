using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WhaleSpotting.Models;

namespace WhaleSpotting;

public class SightingViewModel
{
    public Species? Species { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public string? PhotoUrl { get; set; }
}
