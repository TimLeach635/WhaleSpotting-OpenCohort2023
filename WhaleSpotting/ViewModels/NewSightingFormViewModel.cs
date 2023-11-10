namespace WhaleSpotting.ViewModels;

public class NewSightingFormViewModel
{
    public List<Species>? ListOfSpecies { get; set; }
    public WhaleSpotting.Sighting? Sighting { get; set; }
    public int SpeciesId { get; set; }
}
