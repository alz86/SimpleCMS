namespace DecisionTree.Plugins.SimpleCMS;

public static class SimpleCMSDbProperties
{
    public static string DbTablePrefix { get; set; } = "SimpleCMS";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "Default";

}
