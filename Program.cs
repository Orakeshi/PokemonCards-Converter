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
        string? path = config["Paths:DefaultCsvPath"];
        
        CsvService<PokemonCardCsv> csvService = new CsvService<PokemonCardCsv>();
        PokemonCardTransformer transformer = new PokemonCardTransformer();
        
        // List<PokemonCardCsv> rawCards = csvService.Read($"{path}/scarlet-violet/EN/MEW/Cards.csv", new PokemonCardMap());
        // List<Card> cards = transformer.TransformCards(rawCards);
        
        var csvFiles = Directory.GetFiles(path, "Cards.csv", SearchOption.AllDirectories);

        foreach (var filePath in csvFiles)
        {
            string relativePath = Path.GetRelativePath(path, filePath);
            string[] pathParts = relativePath.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            string topLevelFolder = pathParts[0];

            Console.WriteLine($"File: {filePath}");
            Console.WriteLine($"Top-level folder: {topLevelFolder}");
            
            List<PokemonCardCsv> rawCards = csvService.Read(filePath, new PokemonCardMap());
            List<Card> cards = transformer.TransformCards(rawCards);
            TestOuptut(cards);
        }

        //TestOuptut(cards);
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