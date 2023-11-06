namespace WhaleSpotting;

public class Photo
{
    public int Id { get; set; }
    public string? Image { get; set; }
    public Sighting? Sighting { get; set; }
}
