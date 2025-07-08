using PokemonCardConverter.Enums;

namespace PokemonCardConverter.Helpers;

public static class EnumParser
{
    public static StorageType StorageTypeParser(string storage)
    {
        return storage switch
        {
            "Binder" => StorageType.Binder,
            "Top Loader" => StorageType.TopLoader,
            "Box" => StorageType.Box,
            "Other" => StorageType.Other,
            _ => StorageType.Other
        };
    }
    
    public static AcquireType AcquireTypeParser(string storage)
    {
        return storage switch
        {
            "Packed" => AcquireType.Packed,
            "Bought" => AcquireType.Bought,
            "Traded" => AcquireType.Traded,
            "Unknown" => AcquireType.Unknown,
            _ => AcquireType.Unknown
        };
    }
    
    public static CardType CardTypeParser(string card)
    {
        return card switch
        {
            "Common" => CardType.Common,
            "Uncommon" => CardType.Uncommon,
            "Rare" => CardType.Rare,
            "Double Rare" => CardType.DoubleRare,
            "Ultra Rare" => CardType.UltraRare,
            "Illustration Rare" => CardType.IllustrationRare,
            "Special Illustration Rare" => CardType.SpecialIllustrationRare,
            "Hyper Rare" => CardType.HyperRare,
            "ACE Rare" => CardType.ACERare,
            "Holo Rare" => CardType.HoloRare,
            "V Rare" => CardType.VRare,
            "Radiant Rare" => CardType.RadiantRare,
            "Full Art" => CardType.FullArt,
            "Secret Rare" => CardType.SecretRare,
            _ => CardType.Common
        };
    }
}