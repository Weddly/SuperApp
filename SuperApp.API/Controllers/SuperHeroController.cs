using Microsoft.AspNetCore.Mvc;
using SuperApp.Application.Interfaces;

namespace SuperApp.API.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SuperHeroController(ISuperHeroApplication superHeroApplication) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetHeroesListByDeckId(Guid id)
    {
        var heroes = await superHeroApplication.GetSuperHeroListByDeckId(id);
        return heroes.Any()
            ? Ok(heroes) : NoContent();
    }
}