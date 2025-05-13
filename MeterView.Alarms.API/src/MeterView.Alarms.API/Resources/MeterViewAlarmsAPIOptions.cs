namespace MeterView.Alarms.API.Resources;

public class MeterViewAlarmsAPIOptions
{
    public const string SectionName = "MeterView.Alarms.API";
    
    public RabbitMqOptions RabbitMq { get; set; } = new RabbitMqOptions();
    public ConnectionStringOptions ConnectionStrings { get; set; } = new ConnectionStringOptions();
    public AuthOptions Auth { get; set; } = new AuthOptions();
    public string JaegerHost { get; set; } = String.Empty;
    
    public class RabbitMqOptions
    {
        public const string SectionName = $"{MeterViewAlarmsAPIOptions.SectionName}:RabbitMq";
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
        public const string SectionName = $"{MeterViewAlarmsAPIOptions.SectionName}:ConnectionStrings";
        public const string MeterViewAlarmsAPIKey = nameof(MeterViewAlarmsAPI); 
            
        public string MeterViewAlarmsAPI { get; set; } = String.Empty;
    }
    
    
    public class AuthOptions
    {
        public const string SectionName = $"{MeterViewAlarmsAPIOptions.SectionName}:Auth";

        public string Audience { get; set; } = String.Empty;
        public string Authority { get; set; } = String.Empty;
        public string AuthorizationUrl { get; set; } = String.Empty;
        public string TokenUrl { get; set; } = String.Empty;
        public string ClientId { get; set; } = String.Empty;
        public string ClientSecret { get; set; } = String.Empty;
    }
}

public static class MeterViewAlarmsAPIOptionsExtensions
{
    public static MeterViewAlarmsAPIOptions GetMeterViewAlarmsAPIOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewAlarmsAPIOptions.SectionName)
            .Get<MeterViewAlarmsAPIOptions>();
    }
    
    public static MeterViewAlarmsAPIOptions.RabbitMqOptions GetRabbitMqOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewAlarmsAPIOptions.RabbitMqOptions.SectionName)
            .Get<MeterViewAlarmsAPIOptions.RabbitMqOptions>();
    }
    
    public static MeterViewAlarmsAPIOptions.ConnectionStringOptions GetConnectionStringOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewAlarmsAPIOptions.ConnectionStringOptions.SectionName)
            .Get<MeterViewAlarmsAPIOptions.ConnectionStringOptions>();
    }
    
    public static MeterViewAlarmsAPIOptions.AuthOptions GetAuthOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewAlarmsAPIOptions.AuthOptions.SectionName)
            .Get<MeterViewAlarmsAPIOptions.AuthOptions>();
    }

    public static string GetJaegerHostValue(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewAlarmsAPIOptions.SectionName)
            .GetSection(nameof(MeterViewAlarmsAPIOptions.JaegerHost)).Value;
    }
}