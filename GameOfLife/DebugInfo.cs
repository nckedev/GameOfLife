namespace GameOfLife;

public class DebugInfo
{
    public static Dictionary<string, string> InternalDict { get; } = new();

    public static void Add(string key, string value)
    {
        InternalDict[key] = value;
    }
}