namespace SuperApp.Application.DTOs;

public class CardDto
{
    public Guid DeckId { get; set; }
    public int SuperId { get; set; }
    public Guid Id { get; set; }
    public Boolean IsDeleted { get; set; }
}