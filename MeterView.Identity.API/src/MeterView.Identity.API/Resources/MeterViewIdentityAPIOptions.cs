namespace MeterView.Identity.API.Resources;

public class MeterViewIdentityAPIOptions
{
    public const string SectionName = "MeterView.Identity.API";
    
    public RabbitMqOptions RabbitMq { get; set; } = new RabbitMqOptions();
    public ConnectionStringOptions ConnectionStrings { get; set; } = new ConnectionStringOptions();
    public AuthOptions Auth { get; set; } = new AuthOptions();
    public string JaegerHost { get; set; } = String.Empty;
    
    public class RabbitMqOptions
    {
        public const string SectionName = $"{MeterViewIdentityAPIOptions.SectionName}:RabbitMq";
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
        public const string SectionName = $"{MeterViewIdentityAPIOptions.SectionName}:ConnectionStrings";
        public const string MeterViewIdentityAPIKey = nameof(MeterViewIdentityAPI); 
            
        public string MeterViewIdentityAPI { get; set; } = String.Empty;
    }
    
    
    public class AuthOptions
    {
        public const string SectionName = $"{MeterViewIdentityAPIOptions.SectionName}:Auth";

        public string Audience { get; set; } = String.Empty;
        public string Authority { get; set; } = String.Empty;
        public string AuthorizationUrl { get; set; } = String.Empty;
        public string TokenUrl { get; set; } = String.Empty;
        public string ClientId { get; set; } = String.Empty;
        public string ClientSecret { get; set; } = String.Empty;
    }
}

public static class MeterViewIdentityAPIOptionsExtensions
{
    public static MeterViewIdentityAPIOptions GetMeterViewIdentityAPIOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewIdentityAPIOptions.SectionName)
            .Get<MeterViewIdentityAPIOptions>();
    }
    
    public static MeterViewIdentityAPIOptions.RabbitMqOptions GetRabbitMqOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewIdentityAPIOptions.RabbitMqOptions.SectionName)
            .Get<MeterViewIdentityAPIOptions.RabbitMqOptions>();
    }
    
    public static MeterViewIdentityAPIOptions.ConnectionStringOptions GetConnectionStringOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewIdentityAPIOptions.ConnectionStringOptions.SectionName)
            .Get<MeterViewIdentityAPIOptions.ConnectionStringOptions>();
    }
    
    public static MeterViewIdentityAPIOptions.AuthOptions GetAuthOptions(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewIdentityAPIOptions.AuthOptions.SectionName)
            .Get<MeterViewIdentityAPIOptions.AuthOptions>();
    }

    public static string GetJaegerHostValue(this IConfiguration configuration)
    {
        return configuration
            .GetSection(MeterViewIdentityAPIOptions.SectionName)
            .GetSection(nameof(MeterViewIdentityAPIOptions.JaegerHost)).Value;
    }
}