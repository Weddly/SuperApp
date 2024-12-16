using SuperApp.Application.DTOs;
namespace SuperApp.Application.Interfaces;

public interface ICardApplication
{
    Task<IEnumerable<CardDto>> GetAll();
    Task<CardDto?> Get(Guid id);
    Task<CardDto?> Create(CardDto cardDto);
    Task<CardDto?> Update(Guid id, CardDto cardDto);
    Task Delete(Guid id);
}