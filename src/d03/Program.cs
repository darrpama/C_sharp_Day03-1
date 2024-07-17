var jsonSource = new JsonSource("../consfig.json");
var yamlSource = new YamlSource("../consfig.json");

var config = new Configuration(new List<IConfigurationSource> {jsonSource, yamlSource});
foreach (var param in config.Params) {
    Console.WriteLine($"{param.Key} : {param.Value}");
}