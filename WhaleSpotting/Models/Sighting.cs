namespace WhaleSpotting;

public class Sighting
{
    public int Id { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public DateOnly Date { get; set; }
    public string? Description { get; set; }
}
