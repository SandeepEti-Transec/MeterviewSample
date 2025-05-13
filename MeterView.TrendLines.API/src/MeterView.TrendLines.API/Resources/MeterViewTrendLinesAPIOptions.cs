namespace MeterView.TrendLines.API.Resources;

public class MeterViewTrendLinesAPIOptions
{
    public const string SectionName = "MeterView.TrendLines.API";
    
    public RabbitMqOptions RabbitMq { get; set; } = new RabbitMqOptions();
    public ConnectionStringOptions ConnectionStrings { get; set; } = new ConnectionStringOptions();
    public AuthOptions Auth { get; set; } = new AuthOptions();
    public string JaegerHost { get; set; } = String.Empty;
    
    public class RabbitMqOptions
    {
        public const string SectionName = $"{MeterViewTrendLinesAPIOptions.SectionName}:RabbitMq";
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
        public const string SectionName = $"{MeterViewTrendLinesAPIOptions.SectionName}:ConnectionStrings";
        public const string MeterViewTrendLinesAPIKey = nameof(MeterViewTrendLinesAPI); 
            
        public string MeterViewTrendLinesAPI { get; set; } = String.Empty;
    }
    
    
    public class AuthOptions
    {
        public const string SectionName = $"{MeterViewTrendLinesAPIOptions.SectionName}:Auth";

        public string Audience { get; set; } = String.Empty;
        public string Authority { get; set; } = String.Empty;
        public string AuthorizationUrl { get; set; } = String.Empty;
        public string TokenUrl { get; set; } = String.Empty;
        public string ClientId { get; set; } = String.Empty;
        public string ClientSecret { get; set; } = String.Empty;
    }
}

public static class MeterViewTrendLinesAPIOptionsExtensions
{
    public static MeterViewTrendLinesAPIOptions GetMeterViewTrendLinesAPIOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewTrendLinesAPIOptions.SectionName)
            .Get<MeterViewTrendLinesAPIOptions>();
    }
    
    public static MeterViewTrendLinesAPIOptions.RabbitMqOptions GetRabbitMqOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewTrendLinesAPIOptions.RabbitMqOptions.SectionName)
            .Get<MeterViewTrendLinesAPIOptions.RabbitMqOptions>();
    }
    
    public static MeterViewTrendLinesAPIOptions.ConnectionStringOptions GetConnectionStringOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewTrendLinesAPIOptions.ConnectionStringOptions.SectionName)
            .Get<MeterViewTrendLinesAPIOptions.ConnectionStringOptions>();
    }
    
    public static MeterViewTrendLinesAPIOptions.AuthOptions GetAuthOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewTrendLinesAPIOptions.AuthOptions.SectionName)
            .Get<MeterViewTrendLinesAPIOptions.AuthOptions>();
    }

    public static string GetJaegerHostValue(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewTrendLinesAPIOptions.SectionName)
            .GetSection(nameof(MeterViewTrendLinesAPIOptions.JaegerHost)).Value;
    }
}