namespace MeterView.DeviceAlert.API.Resources;

public class MeterViewDeviceAlertAPIOptions
{
    public const string SectionName = "MeterView.DeviceAlert.API";
    
    public RabbitMqOptions RabbitMq { get; set; } = new RabbitMqOptions();
    public ConnectionStringOptions ConnectionStrings { get; set; } = new ConnectionStringOptions();
    public AuthOptions Auth { get; set; } = new AuthOptions();
    public string JaegerHost { get; set; } = String.Empty;
    
    public class RabbitMqOptions
    {
        public const string SectionName = $"{MeterViewDeviceAlertAPIOptions.SectionName}:RabbitMq";
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
        public const string SectionName = $"{MeterViewDeviceAlertAPIOptions.SectionName}:ConnectionStrings";
        public const string MeterViewDeviceAlertAPIKey = nameof(MeterViewDeviceAlertAPI); 
            
        public string MeterViewDeviceAlertAPI { get; set; } = String.Empty;
    }
    
    
    public class AuthOptions
    {
        public const string SectionName = $"{MeterViewDeviceAlertAPIOptions.SectionName}:Auth";

        public string Audience { get; set; } = String.Empty;
        public string Authority { get; set; } = String.Empty;
        public string AuthorizationUrl { get; set; } = String.Empty;
        public string TokenUrl { get; set; } = String.Empty;
        public string ClientId { get; set; } = String.Empty;
        public string ClientSecret { get; set; } = String.Empty;
    }
}

public static class MeterViewDeviceAlertAPIOptionsExtensions
{
    public static MeterViewDeviceAlertAPIOptions GetMeterViewDeviceAlertAPIOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewDeviceAlertAPIOptions.SectionName)
            .Get<MeterViewDeviceAlertAPIOptions>();
    }
    
    public static MeterViewDeviceAlertAPIOptions.RabbitMqOptions GetRabbitMqOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewDeviceAlertAPIOptions.RabbitMqOptions.SectionName)
            .Get<MeterViewDeviceAlertAPIOptions.RabbitMqOptions>();
    }
    
    public static MeterViewDeviceAlertAPIOptions.ConnectionStringOptions GetConnectionStringOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewDeviceAlertAPIOptions.ConnectionStringOptions.SectionName)
            .Get<MeterViewDeviceAlertAPIOptions.ConnectionStringOptions>();
    }
    
    public static MeterViewDeviceAlertAPIOptions.AuthOptions GetAuthOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewDeviceAlertAPIOptions.AuthOptions.SectionName)
            .Get<MeterViewDeviceAlertAPIOptions.AuthOptions>();
    }

    public static string GetJaegerHostValue(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewDeviceAlertAPIOptions.SectionName)
            .GetSection(nameof(MeterViewDeviceAlertAPIOptions.JaegerHost)).Value;
    }
}