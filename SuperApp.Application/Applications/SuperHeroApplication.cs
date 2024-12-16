using SuperApp.Application.DTOs;
using SuperApp.Application.Interfaces;
using SuperApp.Infra.Data.Interfaces;

namespace SuperApp.Application.Applications;

public class SuperHeroApplication(ISuperHeroService superHeroService, ICardRepository cardRepository) : ISuperHeroApplication
{
    private readonly ISuperHeroService _superHeroService = superHeroService;

    public async Task<SuperHeroDto?> GetSuperHeroByIdAsync(int id)
    {
        var hero = await _superHeroService.GetSuperHeroByIdAsync(id);
        if (hero == null)
        {
            return null;
        }

        return new SuperHeroDto()
        {
            Alignment = hero.Biography.FullName,
            Id = hero.Id,
            CodeName = hero.Name,
            RealName = hero.Biography.FullName,
            Image = hero.Image.Url
        };
    }

    public async Task<IEnumerable<SuperHeroDto>> GetSuperHeroListByDeckId(Guid deckId)
    {
        var cards = await cardRepository.GetAllByDeckId(deckId);
        var superHeroList = new List<SuperHeroDto>();

        foreach (var card in cards)
        {
            var result = await GetSuperHeroByIdAsync(card.SuperId);
            if (result != null)
            {
                superHeroList.Add(result);
            }
        }

        return superHeroList.AsEnumerable();
    }

}