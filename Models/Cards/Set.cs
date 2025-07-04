namespace PokemonCardConverter.Models.Cards;

public class Set
{
    public required string Name { get; set; }
    public required string Identifier { get; set; }
    public required Expansion Expansion { get; set; }
    
    public DateTime? ReleaseDate { get; set; }
    public int? TotalCards { get; set; }
}