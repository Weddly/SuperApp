using SuperApp.Application.DTOs;
namespace SuperApp.Application.Interfaces;

public interface IDeckApplication
{
    Task<IEnumerable<DeckDto>> GetAll();
    Task<DeckDto?> Get(Guid id);
    Task<DeckDto?> Create(DeckDto deckDto);
    Task<DeckDto?> Update(Guid id, DeckDto deckDto);
    Task Delete(Guid id);
    Task AddPrizeCardToDeck(Guid deckId);
}