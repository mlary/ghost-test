using System.Security.Cryptography;
using System.Text;

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

    public static string ToHashPassword(this string value)
    {
        var alg = SHA256.Create();
        return Encoding.UTF8.GetString(
            alg.ComputeHash(
                Encoding.UTF8.GetBytes(value)));
    }
}
