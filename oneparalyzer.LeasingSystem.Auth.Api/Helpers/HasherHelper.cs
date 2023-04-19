using System.Security.Cryptography;
using System.Text;

namespace oneparalyzer.LeasingSystem.Auth.Api.Helpers;

public static class HasherHelper
{
    public static string CreateHash(string value)
    {
        var md5 = MD5.Create();
        byte[] bytes = Encoding.UTF8.GetBytes(value);
        byte[] hash = md5.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}
