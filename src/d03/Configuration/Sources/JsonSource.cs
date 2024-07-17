using System.Text.Json;

public class JsonSource : IConfigurationSource
{
    private string filePath;
    
    public JsonSource(string filePath)
    {
        this.filePath = filePath;
    }

    public Dictionary<string, object> LoadParams()
    {
        Dictionary<string, object> result = new Dictionary<string, object>();
        try
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                result = JsonSerializer.Deserialize<Dictionary<string, object>>(fs);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        return result;
    }
}