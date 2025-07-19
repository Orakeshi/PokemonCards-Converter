namespace PokemonCardConverter.Interfaces;

public interface IJsonService
{
    T Read<T>(string filePath);
}