namespace PokemonCardConverter.Services;

public abstract class FileService
{
    protected string[] GetFiles(string path, string searchPattern, SearchOption searchOption)
    {
        return Directory.GetFiles(path, searchPattern, searchOption);
    }
}