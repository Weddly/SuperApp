using Microsoft.AspNetCore.Mvc;
using SuperApp.Application.DTOs;
using SuperApp.Application.Interfaces;

namespace SuperApp.API.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CardController(ICardApplication cardApplication) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetAllCards()
    {

        var cards = await cardApplication.GetAll();
        return cards.Any()
            ? Ok(cards) : NoContent();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCardById(Guid id)
    {
        var card = await cardApplication.Get(id);
        return card != null
            ? Ok(card) : NotFound();
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateCard(CardDto cardDto)
    {
        var card = await cardApplication.Create(cardDto);
        return card != null
            ? Created("", card) : BadRequest();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateCard(Guid id, [FromBody] CardDto cardDto)
    {
        if (id != cardDto.Id)
        {
            return BadRequest();
        }
        var card = await cardApplication.Update(id, cardDto);
        return card != null
            ? Ok(card) : BadRequest();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCard(Guid id)
    {
        await cardApplication.Delete(id);
        return Ok();
    }
}