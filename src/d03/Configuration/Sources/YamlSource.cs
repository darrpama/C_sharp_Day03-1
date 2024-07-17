public class YamlSource : IConfigurationSource
{
    private string filePath;
    
    public YamlSource(string filePath)
    {
        this.filePath = filePath;
    }

    public Dictionary<string, object> LoadParams()
    {
        return new Dictionary<string, object>()
        {
            {"Ababa", "Aboba"}
        };
    }
} 