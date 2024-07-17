public class JsonSource : IConfigurationSource
{
    private string filePath;
    
    public JsonSource(string filePath)
    {
        this.filePath = filePath;
    }

    public Dictionary<> LoadParams()
    {
        return new Dictionary<string, string>();
    }
}