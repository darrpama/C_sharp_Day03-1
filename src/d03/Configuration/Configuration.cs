using System.Collections;
public class Configuration {
    public Configuration(List<IConfigurationSource> sources)
    {
        Params = new Dictionary<string, object>();
        foreach (var source in sources)
        {
            var loadedParams = source.LoadParams();
            foreach (var param in loadedParams)
            {
                Params[param.Key] = param.Value;
            }
        }
    }

    public Dictionary<string, object> Params { get; private set; }
}