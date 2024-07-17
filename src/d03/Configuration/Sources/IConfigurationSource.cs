public interface IConfigurationSource {
    Dictionary<string, object> LoadParams();
}