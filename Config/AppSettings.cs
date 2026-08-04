namespace Roznama.Config
{
    public class AppSettings
    {
        public ConnectionStringsConnection ConnectionStrings { get; set; } = new();
        public JwtSettings Jwt { get; set; } = new();
        public GlobalUrls GlobalUrls { get; set; } = new();
        public string[] AllowedOrigins { get; set; } = Array.Empty<string>();
    }

    public class ConnectionStringsConnection
    {
        public string DefaultConnection { get; set; } = string.Empty;
    }

    public class JwtSettings
    {
        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int TokenExpiryMinutes { get; set; } = 240;
    }

    public class GlobalUrls
    {
        public string Frontend { get; set; } = string.Empty;
        public string Backend { get; set; } = string.Empty;
    }
}