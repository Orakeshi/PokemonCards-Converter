using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using PokemonCardConverter.Interfaces;

namespace PokemonCardConverter.Services;

public class CsvService<T> : ICsvService<T>
{ 
    private readonly CsvConfiguration _config;

    public CsvService()
    {
        _config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            IgnoreBlankLines = true,
            MissingFieldFound = null
        };
        
    }
    
    public List<T> Read(string filePath, ClassMap? map = null)
    {
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, _config);
        
        if (map != null)
        {
            csv.Context.RegisterClassMap(map);
        }

        return csv.GetRecords<T>().ToList();
    }
}