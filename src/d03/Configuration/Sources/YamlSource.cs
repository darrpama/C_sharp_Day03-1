using YamlDotNet.Serialization;

public class YamlSource : IConfigurationSource
{
    public int Priority { get; }
    private string filePath;
    
    public YamlSource(string filePath, int priority)
    {
        this.Priority = priority;
        this.filePath = filePath;
    }

    public Dictionary<string, object> LoadParams()
    {
        Dictionary<string, object> result = new Dictionary<string, object>();
        try
        {
            string yamlContent = File.ReadAllText(filePath);
            var yamlSerializer = new DeserializerBuilder().Build();
            result = yamlSerializer.Deserialize<Dictionary<string, object>>(yamlContent);
        }
        catch
        {
            throw new ArgumentException("Invalid data. Check your input and try again.");
        }
        return result;
    }
} 