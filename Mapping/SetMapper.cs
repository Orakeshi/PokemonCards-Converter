using System.Globalization;
using PokemonCardConverter.Interfaces;
using PokemonCardConverter.Models;
using PokemonCardConverter.Models.Cards;

namespace PokemonCardConverter.Mapping;

public class SetMapper : IMapper<SetDto, Set>
{
    public Set Map(SetDto setDto)
    {
        return new Set
        {
            Name = setDto.Name,
            Identifier = setDto.Identifier,
            TotalCards = setDto.TotalCards,
            ReleaseDate = DateTime.TryParseExact(
                setDto.ReleaseDate,
                "dd-MM-yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var parsedDate)
                ? parsedDate
                : null
        };
    }
}