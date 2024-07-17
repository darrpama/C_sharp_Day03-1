public interface IConfigurationSource {
    Dictionary<string, string> LoadParams();
}