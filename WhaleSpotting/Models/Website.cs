using System;
using Microsoft.EntityFrameworkCore;


namespace WhaleSpotting;

public class Website
{
   public int Id { get; set; }
    public string? Name { get; set; }
    public string? Url { get; set; }
}
