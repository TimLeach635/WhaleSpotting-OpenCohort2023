namespace WhaleSpotting.ViewModels;

public class NewSightingFormViewModel
{
    public List<Species>? ListOfSpecies { get; set; }
    public SightingViewModel? Sighting { get; set; }
    public int SpeciesId { get; set; }
}
