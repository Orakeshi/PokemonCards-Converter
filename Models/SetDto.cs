using System.Text.Json.Serialization;

namespace PokemonCardConverter.Models;

public class SetDto
{
    public string Name { get; set; } = string.Empty;
    public string Identifier { get; set; } = string.Empty;

    [JsonPropertyName("release-date")]
    public string ReleaseDate { get; set; } = string.Empty;

    [JsonPropertyName("total-cards")]
    public int TotalCards { get; set; }

}