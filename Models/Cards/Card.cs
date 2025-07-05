using PokemonCardConverter.Enums;

namespace PokemonCardConverter.Models.Cards;

public class Card
{
    /* Standard Card Information */
    public required int Number { get; set; }
    public required string Name { get; set; }
    public required CardType Type { get; set; }
    public StorageType Storage { get; set; }
    
    /* Collected Information */
    public bool IsCollected { get; set; }
    public AcquireType AcquireType { get; set; }
    public DateTime? CollectionDate { get; set; }
    public int? DuplicateAmount { get; set; }
}