using SuperApp.Application.DTOs;
using SuperApp.Application.Interfaces;
using SuperApp.Domain.Entities;
using SuperApp.Infra.Data.Interfaces;

namespace SuperApp.Application.Applications;

public class DeckApplication(IDeckRepository deckRepository, ICardRepository cardRepository) : IDeckApplication
{
    private readonly IDeckRepository _deckRepository = deckRepository;
    private readonly ICardRepository _cardRepository = cardRepository;
    private const int InitalCardNumber = 5;

    public async Task<IEnumerable<DeckDto>> GetAll()
    {
        var decks = await _deckRepository.GetAll();
        return decks.Select(deck => new DeckDto
        {
            Name = deck.Name,
            Owner = deck.Owner,
            IsDeleted = deck.IsDeleted,
            Id = deck.Id
        }).ToList();
    }

    public async Task<DeckDto?> Get(Guid id)
    {
        var deck = await _deckRepository.GetById(id);
        if (deck == null)
        {
            return null;
        }

        return new DeckDto
        {
            Name = deck.Name,
            Owner = deck.Owner,
            IsDeleted = deck.IsDeleted,
            Id = deck.Id
        };
    }

    public async Task<DeckDto?> Create(DeckDto deckDto)
    {
        var newDeck = new Deck(deckDto.Name, deckDto.Owner);

        var savedDeck = await _deckRepository.Create(newDeck);

        if (savedDeck == null)
        {
            return null;
        }


        for (int i = 1; i <= InitalCardNumber; i++)
        {
            await _cardRepository.AddRandomCardToDeck(savedDeck.Id);
        }

        return new DeckDto()
        {
            Name = savedDeck.Name,
            Owner = savedDeck.Owner,
            IsDeleted = savedDeck.IsDeleted,
            Id = savedDeck.Id
        };
    }

    public async Task AddPrizeCardToDeck(Guid deckId)
    {
        await _cardRepository.AddPrizeCardToDeck(deckId);
    }

    public async Task<DeckDto?> Update(Guid id, DeckDto deckDto)
    {
        var deck = await _deckRepository.GetById(id);

        if (deck == null)
        {
            return null;
        }

        deck.UpdateDetails(deckDto.Name, deckDto.Owner);

        var updatedDeck = await _deckRepository.Update(deck);

        if (updatedDeck == null)
        {
            return null;
        }

        return new DeckDto()
        {
            Name = updatedDeck.Name,
            Owner = updatedDeck.Owner,
            IsDeleted = updatedDeck.IsDeleted,
            Id = updatedDeck.Id
        };
    }

    public async Task Delete(Guid id)
    {
        var deck = await _deckRepository.GetById(id);

        if (deck != null)
        {
            await _deckRepository.Delete(deck);
        }
    }
}