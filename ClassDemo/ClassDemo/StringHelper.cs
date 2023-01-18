namespace ClassDemo;

public static class StringHelper
{
    public static string AppendEllipses(this string text)
    {
        return $"{text}...";
    }
}
