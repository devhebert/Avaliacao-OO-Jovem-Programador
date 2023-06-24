using System.Text.RegularExpressions;

public class RegexUtils
{
    public static bool IsValidString(string input)
    {
        return Regex.IsMatch(input, @"^[a-zA-Z]+$");
    }

    public static bool IsValidNumber(string input)
    {
        return Regex.IsMatch(input, @"^[0-9.]+$");
    }

    public static bool IsValidChar(string input)
    {
        return Regex.IsMatch(input, @"^[SNsn]$");
    }
}