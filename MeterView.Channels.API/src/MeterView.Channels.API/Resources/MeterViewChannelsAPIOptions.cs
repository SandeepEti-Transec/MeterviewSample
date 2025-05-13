namespace MeterView.Channels.API.Resources;

public class MeterViewChannelsAPIOptions
{
    public const string SectionName = "MeterView.Channels.API";
    
    public RabbitMqOptions RabbitMq { get; set; } = new RabbitMqOptions();
    public ConnectionStringOptions ConnectionStrings { get; set; } = new ConnectionStringOptions();
    public AuthOptions Auth { get; set; } = new AuthOptions();
    public string JaegerHost { get; set; } = String.Empty;
    
    public class RabbitMqOptions
    {
        public const string SectionName = $"{MeterViewChannelsAPIOptions.SectionName}:RabbitMq";
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
        public const string SectionName = $"{MeterViewChannelsAPIOptions.SectionName}:ConnectionStrings";
        public const string MeterViewChannelsAPIKey = nameof(MeterViewChannelsAPI); 
            
        public string MeterViewChannelsAPI { get; set; } = String.Empty;
    }
    
    
    public class AuthOptions
    {
        public const string SectionName = $"{MeterViewChannelsAPIOptions.SectionName}:Auth";

        public string Audience { get; set; } = String.Empty;
        public string Authority { get; set; } = String.Empty;
        public string AuthorizationUrl { get; set; } = String.Empty;
        public string TokenUrl { get; set; } = String.Empty;
        public string ClientId { get; set; } = String.Empty;
        public string ClientSecret { get; set; } = String.Empty;
    }
}

public static class MeterViewChannelsAPIOptionsExtensions
{
    public static MeterViewChannelsAPIOptions GetMeterViewChannelsAPIOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewChannelsAPIOptions.SectionName)
            .Get<MeterViewChannelsAPIOptions>();
    }
    
    public static MeterViewChannelsAPIOptions.RabbitMqOptions GetRabbitMqOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewChannelsAPIOptions.RabbitMqOptions.SectionName)
            .Get<MeterViewChannelsAPIOptions.RabbitMqOptions>();
    }
    
    public static MeterViewChannelsAPIOptions.ConnectionStringOptions GetConnectionStringOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewChannelsAPIOptions.ConnectionStringOptions.SectionName)
            .Get<MeterViewChannelsAPIOptions.ConnectionStringOptions>();
    }
    
    public static MeterViewChannelsAPIOptions.AuthOptions GetAuthOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewChannelsAPIOptions.AuthOptions.SectionName)
            .Get<MeterViewChannelsAPIOptions.AuthOptions>();
    }

    public static string GetJaegerHostValue(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewChannelsAPIOptions.SectionName)
            .GetSection(nameof(MeterViewChannelsAPIOptions.JaegerHost)).Value;
    }
}