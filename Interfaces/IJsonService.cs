namespace PokemonCardConverter.Interfaces;

public interface IJsonService<T>
{
    T Read(string filePath);
}