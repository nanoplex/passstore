using System;
using System.Security.Cryptography;
using System.Text;

public class Hash
{
    public string HashPassword(string password, string salt)
    {
        var combinedPassword = string.Concat(password, salt);
        var sha512 = new SHA512Managed();
        var bytes = UTF8Encoding.UTF8.GetBytes(combinedPassword);
        var hash = sha512.ComputeHash(bytes);

        return Convert.ToBase64String(hash);
    }

    public string GetRandomSalt(Int32 size = 12)
    {
        var random = new RNGCryptoServiceProvider();
        var salt = new Byte[size];
        random.GetBytes(salt);

        return Convert.ToBase64String(salt);
    }
}