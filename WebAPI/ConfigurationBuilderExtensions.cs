namespace CustomConfigurationProvider;

public static class ConfigurationBuilderExtensions
{
    public static IConfigurationBuilder AddEntityConfiguration(
        this IConfigurationBuilder builder)
    {
        var tempConfig = builder.Build();
        var connectionString =
            tempConfig.GetConnectionString("");

        return builder.Add(new EntityConfigurationSource(connectionString));
    }
}