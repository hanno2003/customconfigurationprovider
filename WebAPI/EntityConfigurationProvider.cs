namespace CustomConfigurationProvider;

public class EntityConfigurationProvider : ConfigurationProvider
{
    private readonly string? _connectionString;

    public EntityConfigurationProvider(string? connectionString) =>
        _connectionString = connectionString;

    public override void Load()
    {
        using var dbContext = new TestConfigurationProviderContext();
        Data = dbContext.TestConfigs
            .Where(x => x.Label == "Prod")
            .ToDictionary<TestConfig, string, string>(c => c.Key, c => c.Value, StringComparer.OrdinalIgnoreCase);
    }
}