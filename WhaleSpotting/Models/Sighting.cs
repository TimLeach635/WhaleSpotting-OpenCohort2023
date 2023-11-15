using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WhaleSpotting.Models;

namespace WhaleSpotting;

public class Sighting
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public WsUser User { get; set; }
    public Species? Species { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public DateOnly Date { get; set; }
    public string? Description { get; set; }
    public List<Photo>? Photos { get; set; }
    public Boolean Approved { get; set; }
}
