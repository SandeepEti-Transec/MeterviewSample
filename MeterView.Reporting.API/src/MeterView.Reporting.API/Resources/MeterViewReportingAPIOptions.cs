namespace MeterView.Reporting.API.Resources;

public class MeterViewReportingAPIOptions
{
    public const string SectionName = "MeterView.Reporting.API";
    
    public RabbitMqOptions RabbitMq { get; set; } = new RabbitMqOptions();
    public ConnectionStringOptions ConnectionStrings { get; set; } = new ConnectionStringOptions();
    public AuthOptions Auth { get; set; } = new AuthOptions();
    public string JaegerHost { get; set; } = String.Empty;
    
    public class RabbitMqOptions
    {
        public const string SectionName = $"{MeterViewReportingAPIOptions.SectionName}:RabbitMq";
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
        public const string SectionName = $"{MeterViewReportingAPIOptions.SectionName}:ConnectionStrings";
        public const string MeterViewReportingAPIKey = nameof(MeterViewReportingAPI); 
            
        public string MeterViewReportingAPI { get; set; } = String.Empty;
    }
    
    
    public class AuthOptions
    {
        public const string SectionName = $"{MeterViewReportingAPIOptions.SectionName}:Auth";

        public string Audience { get; set; } = String.Empty;
        public string Authority { get; set; } = String.Empty;
        public string AuthorizationUrl { get; set; } = String.Empty;
        public string TokenUrl { get; set; } = String.Empty;
        public string ClientId { get; set; } = String.Empty;
        public string ClientSecret { get; set; } = String.Empty;
    }
}

public static class MeterViewReportingAPIOptionsExtensions
{
    public static MeterViewReportingAPIOptions GetMeterViewReportingAPIOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewReportingAPIOptions.SectionName)
            .Get<MeterViewReportingAPIOptions>();
    }
    
    public static MeterViewReportingAPIOptions.RabbitMqOptions GetRabbitMqOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewReportingAPIOptions.RabbitMqOptions.SectionName)
            .Get<MeterViewReportingAPIOptions.RabbitMqOptions>();
    }
    
    public static MeterViewReportingAPIOptions.ConnectionStringOptions GetConnectionStringOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewReportingAPIOptions.ConnectionStringOptions.SectionName)
            .Get<MeterViewReportingAPIOptions.ConnectionStringOptions>();
    }
    
    public static MeterViewReportingAPIOptions.AuthOptions GetAuthOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewReportingAPIOptions.AuthOptions.SectionName)
            .Get<MeterViewReportingAPIOptions.AuthOptions>();
    }

    public static string GetJaegerHostValue(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewReportingAPIOptions.SectionName)
            .GetSection(nameof(MeterViewReportingAPIOptions.JaegerHost)).Value;
    }
}