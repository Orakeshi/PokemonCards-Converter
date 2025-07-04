using System.Globalization;
using PokemonCardConverter.Enums;
using PokemonCardConverter.Helpers;
using PokemonCardConverter.Mapping;
using PokemonCardConverter.Models;
using PokemonCardConverter.Models.Cards;
using PokemonCardConverter.Services;

namespace PokemonCardConverter;

class Program
{
    static void Main(string[] args)
    {
        CsvService<PokemonCardCsv> csvService = new CsvService<PokemonCardCsv>();
        
        var rawCards = csvService.Read("/Users/tommy/Documents/Dev/Personal/Coding/Projects/Pokemon/Pokemon Cards/PokemonCards-Converter/Data/Cards.csv", new PokemonCardMap());
        List<Card> cards = new List<Card>();
        
        foreach (PokemonCardCsv rawCard in rawCards)
        {
            Card card = new Card
            {
                Number = int.TryParse(rawCard.Number, out var number) ? number : 0,
                Name = rawCard.Name,
                Type = EnumParser.CardTypeParser(rawCard.Type),
                Storage = EnumParser.StorageTypeParser(rawCard.Storage),
                
                IsCollected = rawCard.Collected.ToUpper() == "TRUE",
                AcquireType = EnumParser.AcquireTypeParser(rawCard.AcquireType),
                CollectionDate = !string.IsNullOrWhiteSpace(rawCard.CollectionDate)
                    ? DateTime.ParseExact(rawCard.CollectionDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    : null,
                DuplicateAmount = int.TryParse(rawCard.DuplicateAmount, out var duplicateNumber) ? duplicateNumber : 0,
            };

            cards.Add(card);

            if (rawCard.RHCollected.ToUpper() == "TRUE")
            {
                Card rhCard = new Card
                {
                    Number = card.Number,
                    Name = card.Name,
                    Type = CardType.ReverseHolo,
                    Storage = card.Storage,
                
                    IsCollected = true,
                    AcquireType = EnumParser.AcquireTypeParser(rawCard.RHAcquireType),
                    CollectionDate = !string.IsNullOrWhiteSpace(rawCard.RHCollectionDate)
                        ? DateTime.ParseExact(rawCard.RHCollectionDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        : null,
                    DuplicateAmount = int.TryParse(rawCard.RHDuplicateAmount, out var rhDuplicateNumber) ? rhDuplicateNumber : 0,
                };
                
                cards.Add(rhCard);
            }
            
        }
        
        foreach(var card in cards)
        {
            
            Console.WriteLine($"{card.Number} - {card.Name} ({card.Storage}) ({card.Type})");
        }
        
        
    }
}