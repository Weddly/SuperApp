namespace SuperApp.Application.DTOs;

public class DeckDto
{
    public required string Name { get; set; }
    public required string Owner { get; set; }
    public Guid Id { get; set; }
    public Boolean IsDeleted { get; set; }
}