namespace MeterView.Support.API.Resources;

public class MeterViewSupportAPIOptions
{
    public const string SectionName = "MeterView.Support.API";
    
    public RabbitMqOptions RabbitMq { get; set; } = new RabbitMqOptions();
    public ConnectionStringOptions ConnectionStrings { get; set; } = new ConnectionStringOptions();
    public AuthOptions Auth { get; set; } = new AuthOptions();
    public string JaegerHost { get; set; } = String.Empty;
    
    public class RabbitMqOptions
    {
        public const string SectionName = $"{MeterViewSupportAPIOptions.SectionName}:RabbitMq";
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
        public const string SectionName = $"{MeterViewSupportAPIOptions.SectionName}:ConnectionStrings";
        public const string MeterViewSupportAPIKey = nameof(MeterViewSupportAPI); 
            
        public string MeterViewSupportAPI { get; set; } = String.Empty;
    }
    
    
    public class AuthOptions
    {
        public const string SectionName = $"{MeterViewSupportAPIOptions.SectionName}:Auth";

        public string Audience { get; set; } = String.Empty;
        public string Authority { get; set; } = String.Empty;
        public string AuthorizationUrl { get; set; } = String.Empty;
        public string TokenUrl { get; set; } = String.Empty;
        public string ClientId { get; set; } = String.Empty;
        public string ClientSecret { get; set; } = String.Empty;
    }
}

public static class MeterViewSupportAPIOptionsExtensions
{
    public static MeterViewSupportAPIOptions GetMeterViewSupportAPIOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewSupportAPIOptions.SectionName)
            .Get<MeterViewSupportAPIOptions>();
    }
    
    public static MeterViewSupportAPIOptions.RabbitMqOptions GetRabbitMqOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewSupportAPIOptions.RabbitMqOptions.SectionName)
            .Get<MeterViewSupportAPIOptions.RabbitMqOptions>();
    }
    
    public static MeterViewSupportAPIOptions.ConnectionStringOptions GetConnectionStringOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewSupportAPIOptions.ConnectionStringOptions.SectionName)
            .Get<MeterViewSupportAPIOptions.ConnectionStringOptions>();
    }
    
    public static MeterViewSupportAPIOptions.AuthOptions GetAuthOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewSupportAPIOptions.AuthOptions.SectionName)
            .Get<MeterViewSupportAPIOptions.AuthOptions>();
    }

    public static string GetJaegerHostValue(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewSupportAPIOptions.SectionName)
            .GetSection(nameof(MeterViewSupportAPIOptions.JaegerHost)).Value;
    }
}