using SuperApp.Application.DTOs;
using SuperApp.Application.Interfaces;
using SuperApp.Domain.Entities;
using SuperApp.Infra.Data.Interfaces;

namespace SuperApp.Application.Applications;

public class PrizeApplication(IPrizeRepository prizeRepository, ISuperHeroService superHeroService) : IPrizeApplication
{
    private readonly IPrizeRepository _prizeRepository = prizeRepository;
    public async Task<IEnumerable<PrizeDto>> GetAll()
    {
        var prizes = await _prizeRepository.GetAll();
        return prizes.Select(prize => new PrizeDto
        {
            SuperId = prize.SuperId,
            IsDeleted = prize.IsDeleted,
            Id = prize.Id
        }).ToList();
    }

    public async Task<PrizeDto?> Get(Guid id)
    {
        var prize = await _prizeRepository.GetById(id);
        if (prize == null)
        {
            return null;
        }

        return new PrizeDto
        {
            SuperId = prize.SuperId,
            IsDeleted = prize.IsDeleted,
            Id = prize.Id
        };
    }
    
    public async Task<PrizeDto?> GetLastHourlyPrize()
    {
        var prize = await _prizeRepository.GetLastPrize();
        
        if (prize == null)
        {
            return null;
        }

        return new PrizeDto
        {
            SuperId = prize.SuperId,
            IsDeleted = prize.IsDeleted,
            Id = prize.Id
        };
    }
    
    public async Task<PrizeDto?> SetRandomHourlyPrize()
    {
        var randomHero = await superHeroService.GetRandomSuperHeroAsync();

        if (randomHero == null)
        {
            return null;
        }

        var newPrize = new PrizeDto { SuperId = randomHero.Id };

        var result = await Create(newPrize);
        
        return result;
    }

    public async Task<PrizeDto?> Create(PrizeDto prizeDto)
    {
        var newPrize = new Prize(prizeDto.SuperId);

        var savedPrize = await _prizeRepository.Create(newPrize);

        if (savedPrize == null)
        {
            return null;
        }

        return new PrizeDto
        {
            SuperId = savedPrize.SuperId,
            IsDeleted = savedPrize.IsDeleted,
            Id = savedPrize.Id
        };
    }

    public async Task<PrizeDto?> Update(Guid id, PrizeDto prizeDto)
    {
        var prize = await _prizeRepository.GetById(id);

        if (prize == null)
        {
            return null;
        }

        prize.UpdateDetails(prize.SuperId);

        var updatedPrize = await _prizeRepository.Update(prize);

        if (updatedPrize == null)
        {
            return null;
        }

        return new PrizeDto
        {
            SuperId = updatedPrize.SuperId,
            IsDeleted = updatedPrize.IsDeleted,
            Id = updatedPrize.Id
        };
    }

    public async Task Delete(Guid id)
    {
        var prize = await _prizeRepository.GetById(id);

        if (prize != null)
        {
            await _prizeRepository.Delete(prize);
        }
    }
}