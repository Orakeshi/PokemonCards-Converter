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
        PokemonCardTransformer transformer = new PokemonCardTransformer();
        
        List<PokemonCardCsv> rawCards = csvService.Read("/Users/tommy/Documents/Dev/Personal/Coding/Projects/Pokemon/Pokemon Cards/PokemonCards-Converter/Data/Cards.csv", new PokemonCardMap());
        var cards = transformer.TransformCards(rawCards);
        
        foreach(var card in cards)
        {
            
            Console.WriteLine($"{card.Number} - {card.Name} ({card.Storage}) ({card.Type})");
        }
        
        
    }
}