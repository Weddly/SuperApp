using SuperApp.Domain.Entities;

namespace SuperApp.Infra.Data.Interfaces;

public interface IDeckRepository
{
    Task<IEnumerable<Deck>> GetAll();
    Task<Deck?> GetById(Guid id);
    Task<Deck?> Create(Deck deck);
    Task<Deck?> Update(Deck deck);
    Task Delete(Deck deck);
}