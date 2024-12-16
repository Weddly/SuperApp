using Microsoft.AspNetCore.Mvc;
using SuperApp.Application.DTOs;
using SuperApp.Application.Interfaces;

namespace SuperApp.API.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DeckController(IDeckApplication deckApplication) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetAllDecks()
    {

        var decks = await deckApplication.GetAll();
        return decks.Any()
            ? Ok(decks) : NoContent();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetDeckById(Guid id)
    {
        var deck = await deckApplication.Get(id);
        return deck != null
            ? Ok(deck) : NotFound();
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateDeck(DeckDto deckDto)
    {
        var deck = await deckApplication.Create(deckDto);
        return deck != null
            ? Created("", deck) : BadRequest();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateDeck(Guid id, [FromBody] DeckDto deckDto)
    {
        if (id != deckDto.Id)
        {
            return BadRequest();
        }
        var deck = await deckApplication.Update(id, deckDto);
        return deck != null
            ? Ok(deck) : BadRequest();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteDeck(Guid id)
    {
        await deckApplication.Delete(id);
        return Ok();
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> AddPrizeCardToDeck(Guid id)
    {
        await deckApplication.AddPrizeCardToDeck(id);
        return Ok();
    }
}