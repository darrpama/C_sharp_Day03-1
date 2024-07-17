public class YamlSource : IConfigurationSource
{
    private string filePath;
    
    public YamlSource(string filePath)
    {
        this.filePath = filePath;
    }

    public Dictionary<string, string> LoadParams()
    {
        return new Dictionary<string, string>()
        {
            {"Ababa", "Aboba"}
        };
    }
} 