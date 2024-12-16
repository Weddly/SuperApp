using Microsoft.EntityFrameworkCore;
using SuperApp.Domain.Entities;
using SuperApp.Infra.Data.Context;
using SuperApp.Infra.Data.Interfaces;

namespace SuperApp.Infra.Data.Repository;

public class DeckRepository(SuperAppContext superAppContext): IDeckRepository
{
    private readonly SuperAppContext _context = superAppContext;
    public async Task<IEnumerable<Deck>> GetAll()
    {
        return await _context.Decks.Where(d => d.IsDeleted == false).ToListAsync();
    }

    public async Task<Deck?> GetById(Guid id)
    {
        return await _context.Decks.Where(d => d.Id == id && !d.IsDeleted)  // Add your filter here
            .FirstOrDefaultAsync();
    }
    public async Task<Deck?> Create(Deck deck)
    {
        var result = await _context.Decks.AddAsync(deck);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Deck?> Update(Deck deck)
    {
        var result = _context.Decks.Update(deck);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task Delete(Deck deck)
    {
        deck.IsDeleted = true;
        await _context.SaveChangesAsync();
    }
}