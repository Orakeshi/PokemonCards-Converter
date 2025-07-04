namespace PokemonCardConverter.Models;

public class PokemonCardCsv
{
    public string Number { get; set; } = "";
    public string Name { get; set; } = "";
    public string Type { get; set; } = "";
    public string Storage { get; set; } = "";

    public string Collected { get; set; } = "";
    public string AcquireType { get; set; } = "";
    public string CollectionDate { get; set; } = "";
    public string DuplicateAmount { get; set; } = "";

    public string RHCollected { get; set; } = "";
    public string RHAcquireType { get; set; } = "";
    public string RHCollectionDate { get; set; } = "";
    public string RHDuplicateAmount { get; set; } = "";
}