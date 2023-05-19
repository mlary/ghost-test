namespace GhostProject.App.Core.Extensions;

public static class StringExtension
{
    public static string ToNormalizedCompanyName(this string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            return value.Replace(" ", "").ToLower();
        }

        return value;
    }
}
