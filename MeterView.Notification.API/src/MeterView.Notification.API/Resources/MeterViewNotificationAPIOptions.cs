namespace MeterView.Notification.API.Resources;

public class MeterViewNotificationAPIOptions
{
    public const string SectionName = "MeterView.Notification.API";
    
    public RabbitMqOptions RabbitMq { get; set; } = new RabbitMqOptions();
    public ConnectionStringOptions ConnectionStrings { get; set; } = new ConnectionStringOptions();
    public AuthOptions Auth { get; set; } = new AuthOptions();
    public string JaegerHost { get; set; } = String.Empty;
    
    public class RabbitMqOptions
    {
        public const string SectionName = $"{MeterViewNotificationAPIOptions.SectionName}:RabbitMq";
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
        public const string SectionName = $"{MeterViewNotificationAPIOptions.SectionName}:ConnectionStrings";
        public const string MeterViewNotificationAPIKey = nameof(MeterViewNotificationAPI); 
            
        public string MeterViewNotificationAPI { get; set; } = String.Empty;
    }
    
    
    public class AuthOptions
    {
        public const string SectionName = $"{MeterViewNotificationAPIOptions.SectionName}:Auth";

        public string Audience { get; set; } = String.Empty;
        public string Authority { get; set; } = String.Empty;
        public string AuthorizationUrl { get; set; } = String.Empty;
        public string TokenUrl { get; set; } = String.Empty;
        public string ClientId { get; set; } = String.Empty;
        public string ClientSecret { get; set; } = String.Empty;
    }
}

public static class MeterViewNotificationAPIOptionsExtensions
{
    public static MeterViewNotificationAPIOptions GetMeterViewNotificationAPIOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewNotificationAPIOptions.SectionName)
            .Get<MeterViewNotificationAPIOptions>();
    }
    
    public static MeterViewNotificationAPIOptions.RabbitMqOptions GetRabbitMqOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewNotificationAPIOptions.RabbitMqOptions.SectionName)
            .Get<MeterViewNotificationAPIOptions.RabbitMqOptions>();
    }
    
    public static MeterViewNotificationAPIOptions.ConnectionStringOptions GetConnectionStringOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewNotificationAPIOptions.ConnectionStringOptions.SectionName)
            .Get<MeterViewNotificationAPIOptions.ConnectionStringOptions>();
    }
    
    public static MeterViewNotificationAPIOptions.AuthOptions GetAuthOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewNotificationAPIOptions.AuthOptions.SectionName)
            .Get<MeterViewNotificationAPIOptions.AuthOptions>();
    }

    public static string GetJaegerHostValue(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewNotificationAPIOptions.SectionName)
            .GetSection(nameof(MeterViewNotificationAPIOptions.JaegerHost)).Value;
    }
}