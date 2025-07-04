using CsvHelper.Configuration;

namespace PokemonCardConverter.Interfaces;

public interface ICsvService<T>
{
    List<T> Read(string filePath, ClassMap? map);
}