using CsvHelper.Configuration;
using PokemonCardConverter.Models;

namespace PokemonCardConverter.Mapping;

public class PokemonCardMap : ClassMap<PokemonCardCsv>
{
    public PokemonCardMap()
    {
        Map(m => m.Number).Name("Card Number");
        Map(m => m.Storage).Name("Storage");
        Map(m => m.Name).Name("Card Name");
        Map(m => m.Type).Name("Card Type");

        Map(m => m.Collected).Name("Collected");
        Map(m => m.AcquireType).Name("Acquire Type");
        Map(m => m.CollectionDate).Name("Collected Date");
        Map(m => m.DuplicateAmount).Name("Duplicate");

        Map(m => m.RHCollected).Name("RH Collected");
        Map(m => m.RHAcquireType).Name("RH Acquire Type");
        Map(m => m.RHCollectionDate).Name("RH Collected Date");
        Map(m => m.RHDuplicateAmount).Name("RH Duplicate");
    }
}