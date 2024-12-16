using Microsoft.EntityFrameworkCore;
using SuperApp.Domain.Entities;
using SuperApp.Infra.Data.Context;
using SuperApp.Infra.Data.Interfaces;

namespace SuperApp.Infra.Data.Repository;

public class PrizeRepository(SuperAppContext superAppContext): IPrizeRepository
{
    private readonly SuperAppContext _context = superAppContext;
    public async Task<IEnumerable<Prize>> GetAll()
    {
        return await _context.Prizes.Where(p => p.IsDeleted == false).ToListAsync();
    }

    public async Task<Prize?> GetById(Guid id)
    {
        return await _context.Prizes.Where(p => p.Id == id && !p.IsDeleted)
            .FirstOrDefaultAsync();
    }

    public async Task<Prize?> GetLastPrize()
    {
        return await _context.Prizes
            .OrderByDescending(p => p.CreationDate)
            .FirstOrDefaultAsync();
    }

    public async Task<Prize?> Create(Prize prize)
    {
        var result = await _context.Prizes.AddAsync(prize);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Prize?> Update(Prize prize)
    {
        var result = _context.Prizes.Update(prize);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task Delete(Prize prize)
    {
        prize.IsDeleted = true;
        await _context.SaveChangesAsync();
    }
}