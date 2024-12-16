using SuperApp.Application.DTOs;
using SuperApp.Application.Interfaces;
using SuperApp.Domain.Entities;
using SuperApp.Infra.Data.Interfaces;

namespace SuperApp.Application.Applications;

public class CardApplication(ICardRepository cardRepository) : ICardApplication
{
    private readonly ICardRepository _cardRepository = cardRepository;
    public async Task<IEnumerable<CardDto>> GetAll()
    {
        var cards = await _cardRepository.GetAll();
        return cards.Select(card => new CardDto
        {
            DeckId = card.DeckId,
            SuperId = card.SuperId,
            IsDeleted = card.IsDeleted,
            Id = card.Id
        }).ToList();
    }

    public async Task<CardDto?> Get(Guid id)
    {
        var card = await _cardRepository.GetById(id);
        if (card == null)
        {
            return null;
        }

        return new CardDto
        {
            DeckId = card.DeckId,
            SuperId = card.SuperId,
            IsDeleted = card.IsDeleted,
            Id = card.Id
        };
    }

    public async Task<CardDto?> Create(CardDto cardDto)
    {
        var newCard = new Card(cardDto.DeckId, cardDto.SuperId);

        var savedCard = await _cardRepository.Create(newCard);

        if (savedCard == null)
        {
            return null;
        }

        return new CardDto
        {
            DeckId = savedCard.DeckId,
            SuperId = savedCard.SuperId,
            IsDeleted = savedCard.IsDeleted,
            Id = savedCard.Id
        };
    }

    public async Task<CardDto?> Update(Guid id, CardDto cardDto)
    {
        var card = await _cardRepository.GetById(id);

        if (card == null)
        {
            return null;
        }

        card.UpdateDetails(card.DeckId, card.SuperId);

        var updatedCard = await _cardRepository.Update(card);

        if (updatedCard == null)
        {
            return null;
        }

        return new CardDto
        {
            DeckId = updatedCard.DeckId,
            SuperId = updatedCard.SuperId,
            IsDeleted = updatedCard.IsDeleted,
            Id = updatedCard.Id
        };
    }

    public async Task Delete(Guid id)
    {
        var card = await _cardRepository.GetById(id);

        if (card != null)
        {
            await _cardRepository.Delete(card);
        }
    }
}