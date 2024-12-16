namespace SuperApp.Domain.Entities;

using System.Collections.Generic;

public class PowerStats
{
    public string? Intelligence { get; set; }
    public string? Strength { get; set; }
    public string? Speed { get; set; }
    public string? Durability { get; set; }
    public string? Power { get; set; }
    public string? Combat { get; set; }
}

public class Biography
{
    public string? FullName { get; set; }
    public string? AlterEgos { get; set; }
    public List<string> Aliases { get; set; }
    public string? PlaceOfBirth { get; set; }
    public string? FirstAppearance { get; set; }
    public string? Publisher { get; set; }
    public string? Alignment { get; set; }
}

public class Appearance
{
    public string? Gender { get; set; }
    public string? Race { get; set; }
    public List<string> Height { get; set; }
    public List<string> Weight { get; set; }
    public string? EyeColor { get; set; }
    public string? HairColor { get; set; }
}

public class Work
{
    public string? Occupation { get; set; }
    public string? Base { get; set; }
}

public class Connections
{
    public string? GroupAffiliation { get; set; }
    public string? Relatives { get; set; }
}

public class Image
{
    public string? Url { get; set; }
}

public class SuperHero
{
    public string? Response { get; set; }
    public int Id { get; set; }
    public string? Name { get; set; }
    public PowerStats Powerstats { get; set; }
    public Biography Biography { get; set; }
    public Appearance Appearance { get; set; }
    public Work Work { get; set; }
    public Connections Connections { get; set; }
    public Image Image { get; set; }
}
