try {
    var jsonPriority = int.Parse(args[1]);
    var jsonSource = new JsonSource(args[0], jsonPriority);

    var yamlPriority = int.Parse(args[3]);
    var yamlSource = new YamlSource(args[2], yamlPriority);

    var config = new Configuration(new List<IConfigurationSource> {jsonSource, yamlSource});
    Console.WriteLine("Configuration:");
    foreach (var param in config.Params) {
        Console.WriteLine($"{param.Key}: {param.Value}");
    }
}
catch (Exception e)
{
    Console.WriteLine(e.ToString());
}