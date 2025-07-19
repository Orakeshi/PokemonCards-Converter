using PokemonCardConverter.Mapping;
using PokemonCardConverter.Models;
using PokemonCardConverter.Services;
using Microsoft.Extensions.Configuration;
using PokemonCardConverter.Models.Cards;


namespace PokemonCardConverter;

class Program
{
    
    static void Main(string[] args)
    {
        IConfigurationRoot config = SetupConfiguration();
        string? csvPath = config["Paths:DefaultCsvPath"];
        string? setPath = config["Paths:SetPath"];
        
        PokemonFileService pokemonFileService = new PokemonFileService(csvPath);
        CsvService<PokemonCardCsv> csvService = new CsvService<PokemonCardCsv>();
        JsonService jsonService = new JsonService();
        
        PokemonCardTransformer cardTransformer = new PokemonCardTransformer();
        PokemonSetTransformer setTransformer = new PokemonSetTransformer();
        
        var rawSets = jsonService.Read<Dictionary<string, List<LanguageSetsDto>>>(setPath);
        List<Expansion> expansions = setTransformer.TransformExpansions(rawSets);

        var cardFiles = pokemonFileService.GetCardFiles();
        
        foreach (var cardFilePath in cardFiles)
        {
            CardFile cardFile = pokemonFileService.CreateCardFile(cardFilePath);

            foreach (var expansion in expansions)
            {
                if (expansion.Name != cardFile.ExpansionPathName) continue;
                
                foreach (var set in expansion.Sets)
                {
                    string setIdentifierPathName = cardFile.SetIdentifierPathName;
                    if (set.Identifier != setIdentifierPathName) continue;
                    
                    List<PokemonCardCsv> rawCards = csvService.Read(cardFile.FullPath, new PokemonCardMap());
                    set.Cards = cardTransformer.TransformCards(rawCards);
                }
            }
        }
    }

    /* Temp Method For Development */
    private static IConfigurationRoot SetupConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.dev.json", optional: true, reloadOnChange: true)
            .Build();
    }
    
    /* Temp Method For Development */
    private static void TestOuptut(List<Card> cards)
    {
        foreach(var card in cards)
        {
            Console.WriteLine($"{card.Number} - {card.Name} ({card.Storage}) ({card.Type}) ({card.IsCollected})");
        }
    }
}