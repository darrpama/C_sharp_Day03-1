public class YamlSource : IConfigurationSource
{
    private string filePath;
    
    public YamlSource(string filePath)
    {
        this.filePath = filePath;
    }

    public Dictionary<> LoadParams()
    {
        return new Dictionary<string, string>();
    }
} 