namespace MeterView.Devices.API.Resources;

public class MeterViewDevicesAPIOptions
{
    public const string SectionName = "MeterView.Devices.API";
    
    public RabbitMqOptions RabbitMq { get; set; } = new RabbitMqOptions();
    public ConnectionStringOptions ConnectionStrings { get; set; } = new ConnectionStringOptions();
    public AuthOptions Auth { get; set; } = new AuthOptions();
    public string JaegerHost { get; set; } = String.Empty;
    
    public class RabbitMqOptions
    {
        public const string SectionName = $"{MeterViewDevicesAPIOptions.SectionName}:RabbitMq";
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
        public const string SectionName = $"{MeterViewDevicesAPIOptions.SectionName}:ConnectionStrings";
        public const string MeterViewDevicesAPIKey = nameof(MeterViewDevicesAPI); 
            
        public string MeterViewDevicesAPI { get; set; } = String.Empty;
    }
    
    
    public class AuthOptions
    {
        public const string SectionName = $"{MeterViewDevicesAPIOptions.SectionName}:Auth";

        public string Audience { get; set; } = String.Empty;
        public string Authority { get; set; } = String.Empty;
        public string AuthorizationUrl { get; set; } = String.Empty;
        public string TokenUrl { get; set; } = String.Empty;
        public string ClientId { get; set; } = String.Empty;
        public string ClientSecret { get; set; } = String.Empty;
    }
}

public static class MeterViewDevicesAPIOptionsExtensions
{
    public static MeterViewDevicesAPIOptions GetMeterViewDevicesAPIOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewDevicesAPIOptions.SectionName)
            .Get<MeterViewDevicesAPIOptions>();
    }
    
    public static MeterViewDevicesAPIOptions.RabbitMqOptions GetRabbitMqOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewDevicesAPIOptions.RabbitMqOptions.SectionName)
            .Get<MeterViewDevicesAPIOptions.RabbitMqOptions>();
    }
    
    public static MeterViewDevicesAPIOptions.ConnectionStringOptions GetConnectionStringOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewDevicesAPIOptions.ConnectionStringOptions.SectionName)
            .Get<MeterViewDevicesAPIOptions.ConnectionStringOptions>();
    }
    
    public static MeterViewDevicesAPIOptions.AuthOptions GetAuthOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewDevicesAPIOptions.AuthOptions.SectionName)
            .Get<MeterViewDevicesAPIOptions.AuthOptions>();
    }

    public static string GetJaegerHostValue(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewDevicesAPIOptions.SectionName)
            .GetSection(nameof(MeterViewDevicesAPIOptions.JaegerHost)).Value;
    }
}