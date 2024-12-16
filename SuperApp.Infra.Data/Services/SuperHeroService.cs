using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SuperApp.Domain.Entities;
using SuperApp.Infra.Data.Interfaces;

namespace SuperApp.Infra.Data.Services;

public class SuperHeroService(HttpClient httpClient, IConfiguration configuration) : ISuperHeroService
{
    private string? _superHeroApiToken;

    public async Task<SuperHero?> GetSuperHeroByIdAsync(int id)
    {
        _superHeroApiToken = configuration["ApiSettings:SuperHeroAccessToken"];
        var response = await httpClient.GetAsync($"https://www.superheroapi.com/api.php/{_superHeroApiToken}/{id}");
        response.EnsureSuccessStatusCode();

        var superheroJson = await response.Content.ReadAsStringAsync();
        var superhero = JsonConvert.DeserializeObject<SuperHero>(superheroJson);

        return superhero;
    }
    
    public async Task<SuperHero?> GetRandomSuperHeroAsync()
    {
        var randomId = GetRandomId();
        var hero = await GetSuperHeroByIdAsync(randomId);
        return hero ?? null;
    }
    
    private static int GetRandomId()
    {
        Random random = new Random();
        return random.Next(1, 732);  // The number of ids in the API
    }
}