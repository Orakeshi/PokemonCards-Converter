using System.Globalization;
using System.Text.Json;
using PokemonCardConverter.Models;
using PokemonCardConverter.Models.Cards;

namespace PokemonCardConverter.Services;

public class PokemonSetTransformer
{
    public List<Expansion> TransformExpansions(Dictionary<string,List<LanguageSetsDto>> rawExpansions)
    {
        var expansions = new List<Expansion>();

        foreach (var (blockName, languageList) in rawExpansions)
        {
            foreach (var languageGroup in languageList)
            {
                if (languageGroup.EN != null)
                {
                    expansions.Add(new Expansion
                    {
                        Name = blockName,
                        Language = "EN",
                        Sets = languageGroup.EN.Select(dto => new Set
                        {
                            Name = dto.Name,
                            Identifier = dto.Identifier,
                            ReleaseDate = DateTime.ParseExact(dto.ReleaseDate, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                            TotalCards = dto.TotalCards
                        }).ToList()
                    });
                }

                if (languageGroup.JP != null)
                {
                    expansions.Add(new Expansion
                    {
                        Name = blockName,
                        Language = "JP",
                        Sets = languageGroup.JP.Select(dto => new Set
                        {
                            Name = dto.Name,
                            Identifier = dto.Identifier,
                            ReleaseDate = DateTime.ParseExact(dto.ReleaseDate, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                            TotalCards = dto.TotalCards
                        }).ToList()
                    });
                }
            }
        }

        return expansions;
    }
}