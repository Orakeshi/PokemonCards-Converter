using PokemonCardConverter.Enums;

namespace PokemonCardConverter.Models.Cards;

public abstract class Card
{
    /* Standard Card Information */
    public required int Number { get; set; }
    public required string Name { get; set; }
    public StorageType Storage { get; set; }
    
    /* Collected Information */
    public bool? IsCollected { get; set; }
    public CollectionType? CollectionType { get; set; }
    public DateTime? CollectionDate { get; set; }
    
    /* Duplicate Information */
    public Duplicate? Duplicate { get; set; }
}