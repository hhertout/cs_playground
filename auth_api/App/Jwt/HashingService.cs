using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace auth_api.App.Jwt;

public class HashingService
{
    private const int IterationCount = 100000;
    
    public string Hash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(128 / 8); 
        var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: IterationCount,
            numBytesRequested: 256 / 8));

        return hashed;
    }
}