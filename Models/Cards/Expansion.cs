namespace PokemonCardConverter.Models.Cards;

public class Expansion
{
    public required string Name { get; set; }
    public required string Language { get; set; }
    public List<Set> Sets { get; set; } = new();
}