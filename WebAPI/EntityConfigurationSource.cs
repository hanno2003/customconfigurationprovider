namespace CustomConfigurationProvider;

public class EntityConfigurationSource : IConfigurationSource
{
    private readonly string? _connectionString;

    public EntityConfigurationSource(string? connectionString) =>
        _connectionString = connectionString;
    
    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        return new EntityConfigurationProvider(_connectionString);
    }
}
