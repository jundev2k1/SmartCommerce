using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Common.Helpers
{
    public class Common
    {
        /// <summary>
        /// Encrypt Password
        /// </summary>
        /// <param name="password">Password</param>
        /// <returns>Encrypted password</returns>
        public static string EncryptPassword(string password)
        {
            try
            {
                var encryptDataByte = new byte[password.Length];
                encryptDataByte = System.Text.Encoding.UTF8.GetBytes(password);
                var result = Convert.ToBase64String(encryptDataByte);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Encode error:\n --------- \n{0}", ex.Message));
            }
        }

        /// <summary>
        /// Decrypt Password
        /// </summary>
        /// <param name="password">Encrypted password</param>
        /// <returns>Decrypted password</returns>
        public static string DecryptPassword(string password)
        {
            var encoder = new System.Text.UTF8Encoding();
            var utf8Decrypt = encoder.GetDecoder();
            var toDecryptData = Convert.FromBase64String(password);
            var charCount = utf8Decrypt.GetCharCount(toDecryptData, 0, toDecryptData.Length);
            var decryptChar = new char[charCount];
            utf8Decrypt.GetChars(toDecryptData, 0, toDecryptData.Length, decryptChar, 0);
            string result = new String(decryptChar);
            return result;
        }
    }
}
