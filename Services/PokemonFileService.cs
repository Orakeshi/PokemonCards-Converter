using PokemonCardConverter.Models;

namespace PokemonCardConverter.Services;

public class PokemonFileService : FileService
{
    public string PokemonFilePath { get; set; }
    
    public PokemonFileService(string pokemonFilePath)
    {
        PokemonFilePath =  pokemonFilePath;
    }
    
    public string[] GetCardFiles()
    {
        return GetFiles(PokemonFilePath, "Cards.csv", SearchOption.AllDirectories);
    }

    public CardFile CreateCardFile(string cardFilePath)
    {
        string relativePath = Path.GetRelativePath(PokemonFilePath, cardFilePath);
        string[] pathParts = relativePath.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

        return new CardFile
        {
            FullPath = cardFilePath,
            PathParts = pathParts,
            ExpansionPathName = pathParts[1],
            SetIdentifierPathName = pathParts[3]
        };
    }
}