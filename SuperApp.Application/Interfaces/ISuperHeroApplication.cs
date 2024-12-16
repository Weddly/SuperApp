using SuperApp.Application.DTOs;

namespace SuperApp.Application.Interfaces;

public interface ISuperHeroApplication
{
    Task<SuperHeroDto?> GetSuperHeroByIdAsync(int id);
    Task<IEnumerable<SuperHeroDto>> GetSuperHeroListByDeckId(Guid deckId);

}