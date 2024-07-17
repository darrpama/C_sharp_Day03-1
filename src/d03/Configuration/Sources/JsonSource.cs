public class JsonSource : IConfigurationSource
{
    private string filePath;
    
    public JsonSource(string filePath)
    {
        this.filePath = filePath;
    }

    public Dictionary<string, string> LoadParams()
    {
        return new Dictionary<string, string>()
        {
            {"Aboba", "Ababa"}
        };
    }
}