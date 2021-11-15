using System;
using System.Security.Cryptography;

namespace SecurityLayer
{
    public class Encryptation
    {
        //Genera un semilla que se va a combinar con el password
        public static byte[] generateSeed() { 

            var randomNumberGenerator = new RNGCryptoServiceProvider();
            var seed = new byte[32];

            randomNumberGenerator.GetBytes(seed);

            return seed;
        }


        //A partir de el vector con valores criptograficos y la password , este método los combina
        public static byte[] combine(byte[] seed, byte[] password) {
            var ret = new byte[seed.Length + password.Length];

            Buffer.BlockCopy(seed, 0, ret, 0, seed.Length);
            Buffer.BlockCopy(password, 0, ret, seed.Length, password.Length);

            return ret;
        }


        //Calcula el valor del hash a partir del vector combinado con la seed y la password
        public static byte[] HashPasswordWithSeed(byte[] seed ,byte[] toBeHashed) {
            var sha256 = SHA256.Create();

            var combineHash = combine(seed, toBeHashed);

            return sha256.ComputeHash(combineHash);
        }
    }
}
