namespace SuperApp.Application.DTOs;

public class SuperHeroDto
{
    public int Id { get; set; }
    public required string CodeName { get; set; }
    public required string RealName { get; set; }
    public required string Alignment { get; set; }
    public required string Image { get; set; }
}