namespace SuperApp.Domain.Entities;

public class Card: EntityBase
{
    public Card(Guid deckId, int superId)
    {
        DeckId = deckId;
        SuperId = superId;
    }
    public void UpdateDetails(Guid deckId, int superId)
    {
        DeckId = deckId;
        SuperId = superId;
    }

    public Guid DeckId { get; private set; }
    public int SuperId { get; private set; }
}