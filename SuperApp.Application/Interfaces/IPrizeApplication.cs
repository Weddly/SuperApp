using SuperApp.Application.DTOs;
namespace SuperApp.Application.Interfaces;

public interface IPrizeApplication
{
    Task<IEnumerable<PrizeDto>> GetAll();
    Task<PrizeDto?> Get(Guid id);
    Task<PrizeDto?> Create(PrizeDto prizeDto);
    Task<PrizeDto?> Update(Guid id, PrizeDto prizeDto);
    Task Delete(Guid id);
    Task<PrizeDto?> SetRandomHourlyPrize();
    Task<PrizeDto?> GetLastHourlyPrize();

}