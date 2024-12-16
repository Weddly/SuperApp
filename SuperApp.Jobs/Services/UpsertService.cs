using SuperApp.Domain.Entities;
using SuperApp.Infra.Data.Interfaces;

namespace SuperApp.Jobs.Services;

public class UpsertService (ISuperHeroService superHeroService, IPrizeRepository prizeRepository): IUpsertService
{
    public async Task UpsertDataAsync()
    {
        try
        {
            
            var randomHero = await superHeroService.GetRandomSuperHeroAsync();
            if (randomHero != null)
            {
                var newPrize = new Prize(randomHero.Id);

                await prizeRepository.Create(newPrize);
                
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during upsert: {ex.Message}");
            throw;
        }
    }
}