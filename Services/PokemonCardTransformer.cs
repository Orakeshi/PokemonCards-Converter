using System.Globalization;
using PokemonCardConverter.Enums;
using PokemonCardConverter.Helpers;
using PokemonCardConverter.Models;
using PokemonCardConverter.Models.Cards;

namespace PokemonCardConverter.Services;

public class PokemonCardTransformer
{
    public List<Card> TransformCards(List<PokemonCardCsv> rawCards)
    {
        List<Card> cards = new List<Card>();
        
        foreach (PokemonCardCsv rawCard in rawCards)
        {
            Card card = CreateCard(rawCard);
            cards.Add(card);

            if (rawCard.RHCollected == "-") continue;
            
            Card rhCard = CreateReverseHoloCard(rawCard);
            cards.Add(rhCard);

        }
        
        return cards;
    }

    private Card CreateCard(PokemonCardCsv rawCard)
    {
        Card card = SetupInitialCard(rawCard);

        card.IsCollected = rawCard.Collected.ToUpper() == "TRUE";
        card.AcquireType = EnumParser.AcquireTypeParser(rawCard.AcquireType);
        card.CollectionDate = ParseDate(rawCard.CollectionDate);
        card.DuplicateAmount = int.TryParse(rawCard.DuplicateAmount, out var duplicateNumber) ? duplicateNumber : 0;
        
        return card;
    }

    private Card CreateReverseHoloCard(PokemonCardCsv rawCard)
    {
        Card rhCard = SetupInitialCard(rawCard);

        rhCard.IsReverseHolo = true;
        rhCard.IsCollected = rawCard.RHCollected.ToUpper() == "TRUE";
        rhCard.AcquireType = EnumParser.AcquireTypeParser(rawCard.RHAcquireType);
        rhCard.CollectionDate = ParseDate(rawCard.RHCollectionDate);
        rhCard.DuplicateAmount = int.TryParse(rawCard.RHDuplicateAmount, out var rhDuplicateNumber) ? rhDuplicateNumber : 0;
        
        return rhCard;
    }

    private Card SetupInitialCard(PokemonCardCsv rawCard)
    {
        return new Card
        {
            Number = int.TryParse(rawCard.Number, out var number) ? number : 0,
            Name = rawCard.Name,
            Type = EnumParser.CardTypeParser(rawCard.Type),
            Storage = EnumParser.StorageTypeParser(rawCard.Storage),
            IsReverseHolo = false
        };
    }
    
    private DateTime? ParseDate(string? input)
    {
        return !string.IsNullOrWhiteSpace(input)
            ? DateTime.ParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture)
            : null;
    }
}