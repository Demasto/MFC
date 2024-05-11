namespace WebApi.CustomActionResult;

public static class ApiResults
{
    public static Dictionary<string, object> Bad(string message)
    {
        return new Dictionary<string, object>
        {
            ["succeeded"] = false,
            ["error_message"] = message
        };
    }
    public static Dictionary<string, bool> Bad()
    {
        return new Dictionary<string, bool>
        {
            ["succeeded"] = false,
        };
    }
    public static Dictionary<string, object> Ok(string key, object value)
    {
        return new Dictionary<string, object>
        {
            ["succeeded"] = true,
            [key] = value
        };
    }
    public static Dictionary<string, bool> Ok()
    {
        return new Dictionary<string, bool>
        {
            ["succeeded"] = true,
        };
    }
}