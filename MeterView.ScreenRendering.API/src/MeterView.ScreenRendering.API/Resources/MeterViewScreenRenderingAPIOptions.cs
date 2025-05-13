namespace MeterView.ScreenRendering.API.Resources;

public class MeterViewScreenRenderingAPIOptions
{
    public const string SectionName = "MeterView.ScreenRendering.API";
    
    public RabbitMqOptions RabbitMq { get; set; } = new RabbitMqOptions();
    public ConnectionStringOptions ConnectionStrings { get; set; } = new ConnectionStringOptions();
    public AuthOptions Auth { get; set; } = new AuthOptions();
    public string JaegerHost { get; set; } = String.Empty;
    
    public class RabbitMqOptions
    {
        public const string SectionName = $"{MeterViewScreenRenderingAPIOptions.SectionName}:RabbitMq";
        public const string HostKey = nameof(Host);
        public const string VirtualHostKey = nameof(VirtualHost);
        public const string UsernameKey = nameof(Username);
        public const string PasswordKey = nameof(Password);
        public const string PortKey = nameof(Port);

        public string Host { get; set; } = String.Empty;
        public string VirtualHost { get; set; } = String.Empty;
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string Port { get; set; } = String.Empty;
    }

    public class ConnectionStringOptions
    {
        public const string SectionName = $"{MeterViewScreenRenderingAPIOptions.SectionName}:ConnectionStrings";
        public const string MeterViewScreenRenderingAPIKey = nameof(MeterViewScreenRenderingAPI); 
            
        public string MeterViewScreenRenderingAPI { get; set; } = String.Empty;
    }
    
    
    public class AuthOptions
    {
        public const string SectionName = $"{MeterViewScreenRenderingAPIOptions.SectionName}:Auth";

        public string Audience { get; set; } = String.Empty;
        public string Authority { get; set; } = String.Empty;
        public string AuthorizationUrl { get; set; } = String.Empty;
        public string TokenUrl { get; set; } = String.Empty;
        public string ClientId { get; set; } = String.Empty;
        public string ClientSecret { get; set; } = String.Empty;
    }
}

public static class MeterViewScreenRenderingAPIOptionsExtensions
{
    public static MeterViewScreenRenderingAPIOptions GetMeterViewScreenRenderingAPIOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewScreenRenderingAPIOptions.SectionName)
            .Get<MeterViewScreenRenderingAPIOptions>();
    }
    
    public static MeterViewScreenRenderingAPIOptions.RabbitMqOptions GetRabbitMqOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewScreenRenderingAPIOptions.RabbitMqOptions.SectionName)
            .Get<MeterViewScreenRenderingAPIOptions.RabbitMqOptions>();
    }
    
    public static MeterViewScreenRenderingAPIOptions.ConnectionStringOptions GetConnectionStringOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewScreenRenderingAPIOptions.ConnectionStringOptions.SectionName)
            .Get<MeterViewScreenRenderingAPIOptions.ConnectionStringOptions>();
    }
    
    public static MeterViewScreenRenderingAPIOptions.AuthOptions GetAuthOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewScreenRenderingAPIOptions.AuthOptions.SectionName)
            .Get<MeterViewScreenRenderingAPIOptions.AuthOptions>();
    }

    public static string GetJaegerHostValue(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewScreenRenderingAPIOptions.SectionName)
            .GetSection(nameof(MeterViewScreenRenderingAPIOptions.JaegerHost)).Value;
    }
}