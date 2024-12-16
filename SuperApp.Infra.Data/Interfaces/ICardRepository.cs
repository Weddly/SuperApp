using SuperApp.Domain.Entities;

namespace SuperApp.Infra.Data.Interfaces;

public interface ICardRepository
{
    Task<IEnumerable<Card>> GetAll();
    Task<Card?> GetById(Guid id);
    Task<Card?> Create(Card card);
    Task<Card?> Update(Card card);
    Task Delete(Card card);
    Task<IEnumerable<Card>> GetAllByDeckId(Guid deckId);
    Task AddRandomCardToDeck(Guid deckId);
    Task AddPrizeCardToDeck(Guid deckId);
}