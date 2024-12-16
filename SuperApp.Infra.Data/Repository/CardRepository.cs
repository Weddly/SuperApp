using Microsoft.EntityFrameworkCore;
using SuperApp.Domain.Entities;
using SuperApp.Infra.Data.Context;
using SuperApp.Infra.Data.Interfaces;

namespace SuperApp.Infra.Data.Repository;

public class CardRepository(SuperAppContext superAppContext, ISuperHeroService superHeroService, IPrizeRepository prizeRepository) : ICardRepository
{
    public async Task<IEnumerable<Card>> GetAll()
    {
        return await superAppContext.Cards.Where(c => c.IsDeleted == false).ToListAsync();
    }

    public async Task<Card?> GetById(Guid id)
    {
        return await superAppContext.Cards.Where(c => c.Id == id && !c.IsDeleted)  // Add your filter here
            .FirstOrDefaultAsync();
    }
    public async Task<Card?> Create(Card card)
    {
        var result = await superAppContext.Cards.AddAsync(card);
        await superAppContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Card?> Update(Card card)
    {
        var result = superAppContext.Cards.Update(card);
        await superAppContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task Delete(Card card)
    {
        card.IsDeleted = true;
        await superAppContext.SaveChangesAsync();
    }

    public async Task AddRandomCardToDeck(Guid deckId)
    {
        var randomSuperHero = await superHeroService.GetRandomSuperHeroAsync();

        if (randomSuperHero != null)
        {
            var card = new Card(deckId, randomSuperHero.Id);
            await Create(card);
        }

    }

    public async Task AddPrizeCardToDeck(Guid deckId)
    {
        var lastPrize = await prizeRepository.GetLastPrize();



        if (lastPrize != null)
        {
            var card = new Card(deckId, lastPrize.SuperId);
            await Create(card);
        }

    }

    public async Task<IEnumerable<Card>> GetAllByDeckId(Guid deckId)
    {
        return await superAppContext.Cards.Where(c => c.IsDeleted == false && c.DeckId == deckId).ToListAsync();
    }
}