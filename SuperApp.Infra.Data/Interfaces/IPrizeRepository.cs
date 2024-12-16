using SuperApp.Domain.Entities;

namespace SuperApp.Infra.Data.Interfaces;

public interface IPrizeRepository
{
    Task<IEnumerable<Prize>> GetAll();
    Task<Prize?> GetById(Guid id);
    Task<Prize?> GetLastPrize();
    Task<Prize?> Create(Prize prize);
    Task<Prize?> Update(Prize prize);
    Task Delete(Prize prize);
}