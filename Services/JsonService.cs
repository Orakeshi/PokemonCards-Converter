using System.Text.Json;
using PokemonCardConverter.Interfaces;

namespace PokemonCardConverter.Services;

public class JsonService : IJsonService
{
    public T Read<T>(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"JSON file not found at path: {filePath}");

        var json = File.ReadAllText(filePath);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        return JsonSerializer.Deserialize<T>(json, options)
               ?? throw new InvalidOperationException("Failed to deserialize JSON.");
    }
}