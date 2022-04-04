namespace BlazorApp1.Static;

internal static class APIEndpoint
{
    #if DEBUG
        internal const string ServerBaseUrl = "https://localhost:5003";
    #else
        internal const string ServerBaseUrl = "https://appname.azurewebsite.net";
    #endif

    internal readonly static string s_categories = $"{ServerBaseUrl}/api/categories";
}