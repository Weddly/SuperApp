using Microsoft.AspNetCore.Mvc;
using SuperApp.Application.DTOs;
using SuperApp.Application.Interfaces;

namespace SuperApp.API.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PrizeController(IPrizeApplication prizeApplication) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetAllPrizes()
    {

        var cards = await prizeApplication.GetAll();
        return cards.Any()
            ? Ok(cards) : NoContent();
    }
    
    [HttpGet("")]
    public async Task<IActionResult> SetHourlyPrize()
    {
        var card = await prizeApplication.SetRandomHourlyPrize();
        return card != null
            ? Ok(card) : NotFound();
    }
    
    [HttpGet("")]
    public async Task<IActionResult> GetHourlyPrize()
    {
        var card = await prizeApplication.GetLastHourlyPrize();
        return card != null
            ? Ok(card) : NotFound();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetPrizeById(Guid id)
    {
        var card = await prizeApplication.Get(id);
        return card != null
            ? Ok(card) : NotFound();
    }

    [HttpPost("")]
    public async Task<IActionResult> CreatePrize(PrizeDto prizeDto)
    {
        var card = await prizeApplication.Create(prizeDto);
        return card != null
            ? Created("", card) : BadRequest();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdatePrize(Guid id, [FromBody] PrizeDto prizeDto)
    {
        if (id != prizeDto.Id)
        {
            return BadRequest();
        }
        var card = await prizeApplication.Update(id, prizeDto);
        return card != null
            ? Ok(card) : BadRequest();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeletePrize(Guid id)
    {
        await prizeApplication.Delete(id);
        return Ok();
    }
}