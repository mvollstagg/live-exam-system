using System.Security.Cryptography;
using System.Text;

namespace LiveExamSystemWebApp.Core.Utilities.Security.Hashing;

public class HashingHelper
{
    public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSlat)
    {
        using var hmac = new HMACSHA512();
        passwordSlat = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSlat)
    {
        using HMACSHA512 hmacshA512 = new(passwordSlat);
        byte[] hash = hmacshA512.ComputeHash(Encoding.UTF8.GetBytes(password));
        for (int index = 0; index < hash.Length; ++index)
        {
            if (hash[index] != passwordHash[index])
                return false;
        }
        return true;
    }

    public static string CreatePasswordHashOld(string password, string secretKey)
    {
        if (password == null) throw new ArgumentNullException(nameof(password));
        if (secretKey == null) throw new ArgumentNullException(nameof(secretKey));
        StringBuilder hash = new StringBuilder();
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
        using (var hmac = new HMACSHA512(secretKeyBytes))
        {
            byte[] hashValue = hmac.ComputeHash(passwordBytes);
            foreach (var value in hashValue)
            {
                hash.Append(value.ToString("x2"));
            }
        }
        return hash.ToString();
    }
    public static bool VerifyPasswordHashOld(string password, string secretKey, string passwordHash)
    {
        if (password == null) throw new ArgumentNullException(nameof(password));
        if (secretKey == null) throw new ArgumentNullException(nameof(secretKey));
        if (passwordHash == null) throw new ArgumentNullException(nameof(passwordHash));
        string hash = CreatePasswordHashOld(password, secretKey);
        for (int i = 0; i < hash.Length; i++)
        {
            if (hash[i] != passwordHash[i])
            {
                return false;
            }
        }
        return true;
    }
}