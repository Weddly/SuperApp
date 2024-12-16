using SuperApp.Domain.Entities;

namespace SuperApp.Infra.Data.Interfaces;

public interface ISuperHeroService
{
    Task<SuperHero?> GetSuperHeroByIdAsync(int id);
    Task<SuperHero?> GetRandomSuperHeroAsync();
}