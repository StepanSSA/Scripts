

public static class OidcOptions
{
    public static string ClientId { get;} = "educDesktopClient";
    public static string Scope { get;} = "openid profile EducWebAPI";
    public static string ClientSecret { get;} = "secretpassword";
    public static string Authority { get;} = "https://localhost:7086";
}
