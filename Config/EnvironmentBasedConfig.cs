namespace Roznama.Config
{
    public class EnvironmentBasedConfig
    {
        // Useful flags you might want to check at runtime
        public string EnvironmentName { get; set; } = "Development";
        public bool UseSqlLogging { get; set; } = false;
        public bool EnableDetailedErrors { get; set; } = false;

        // Add properties as needed (e.g. feature toggles)
    }
}