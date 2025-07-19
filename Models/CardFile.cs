namespace PokemonCardConverter.Models;

public class CardFile
{
    public string FullPath { get; set; }
    public string[] PathParts { get; set; }
    public string ExpansionPathName { get; set; }
    public string SetIdentifierPathName { get; set; }
    
}