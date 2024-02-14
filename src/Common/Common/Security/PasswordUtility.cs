// Copyright (c) 2024 - Jun Dev. All rights reserved

#pragma warning disable SYSLIB0023
using System.Security.Cryptography;
using System.Text;

namespace ErpManager.Common.Security
{
    public static class PasswordUtility
    {
        private static byte[] GenerateRandomIV()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] iv = new byte[16];
                rng.GetBytes(iv);
                return iv;
            }
        }

        /// <summary>
        /// Password encrypt
        /// </summary>
        /// <param name="password">Password</param>
        /// <returns>Password encrypt</returns>
        public static string PasswordEncrypt(string password)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(Constants.CONFIG_SECRET_KEY);
                aesAlg.IV = GenerateRandomIV();

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(password);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        /// <summary>
        /// Password decrypt
        /// </summary>
        /// <param name="encodedPassword">Encoded password</param>
        /// <returns>Raw password</returns>
        public static string PasswordDecrypt(string encodedPassword)
        {
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(Constants.CONFIG_SECRET_KEY);
                aesAlg.IV = GenerateRandomIV();

                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (var msDecrypt = new MemoryStream(Convert.FromBase64String(encodedPassword)))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
