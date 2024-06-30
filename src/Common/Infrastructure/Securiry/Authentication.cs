// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Infrastructure.Securiry
{
	public class Authentication
	{
		private static Authentication? _instance { get; set; }
		private static readonly object _lockObject = new object();
		private static (byte[] Key, byte[] KeyIV) _secretKey { get; set; }
		private Authentication()
		{
			if ((_secretKey.Key == default(byte[])) || (_secretKey.KeyIV == default(byte[])))
			{
				GetOrGenerateSecretKey();
			}
		}

		/// <summary>
		/// String to secret key
		/// </summary>
		/// <param name="input"></param>
		/// <returns>Secret key</returns>
		private byte[] StringToSecretKey(string input)
		{
			using (var sha256 = SHA256.Create())
			{
				byte[] inputBytes = Encoding.UTF8.GetBytes(input);
				byte[] hashBytes = sha256.ComputeHash(inputBytes);
				return hashBytes;
			}
		}

		/// <summary>
		/// Generate random IV
		/// </summary>
		/// <returns>Key IV</returns>
		private byte[] GenerateRandomIV()
		{
			using (var aesAlg = Aes.Create())
			{
				aesAlg.GenerateIV();
				return aesAlg.IV;
			}
		}

		/// <summary>
		/// Get or generate secret key
		/// </summary>
		private void GetOrGenerateSecretKey()
		{
			var filePath = $"{Constants.ERP_REFRESH_DIR_PATH}/secret-key.txt";
			if (File.Exists(filePath))
			{
				var texts = File.ReadAllText(filePath).Split();
				var key = Convert.FromBase64String(texts[0]);
				var iv = Convert.FromBase64String(texts[1]);
				_secretKey = (key, iv);
				return;
			}

			var newKey = StringToSecretKey(Constants.CONFIG_SECRET_KEY);
			var newIV = GenerateRandomIV();
			_secretKey = (newKey, newIV);

			// Create key
			var textKey = Convert.ToBase64String(newKey);
			var textIV = Convert.ToBase64String(newIV);
		}

		/// <summary>
		/// Password encrypt
		/// </summary>
		/// <param name="password">Password</param>
		/// <returns>Password encrypt</returns>
		public string PasswordEncrypt(string password)
		{
			using (var aesAlg = Aes.Create())
			{
				aesAlg.Key = _secretKey.Key;
				aesAlg.IV = _secretKey.KeyIV;

				var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

				using (var msEncrypt = new MemoryStream())
				{
					using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
					using (var swEncrypt = new StreamWriter(csEncrypt))
					{
						swEncrypt.Write(password);
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
		public string PasswordDecrypt(string encodedPassword)
		{
			using (var aesAlg = Aes.Create())
			{
				aesAlg.Key = _secretKey.Key;
				aesAlg.IV = _secretKey.KeyIV;

				var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

				using (var msDecrypt = new MemoryStream(Convert.FromBase64String(encodedPassword)))
				using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
				using (var srDecrypt = new StreamReader(csDecrypt))
				{
					return srDecrypt.ReadToEnd();
				}
			}
		}

		/// <summary>
		/// Generate OTP code for 2-step login
		/// </summary>
		/// <returns>OTP code</returns>
		public string GenerateOTPCode()
		{
			var random = new Random();
			var otpCode = new char[6]
				.Select(c => Constants.CONST_DATA_OTP_RANDOM_CHARACTER[
					random.Next(Constants.CONST_DATA_OTP_RANDOM_CHARACTER.Length)])
				.ToArray();
			var result = new string(otpCode);
			return result;
		}

		/// <summary>Instance</summary>
		public static Authentication Instance
		{
			get
			{
				if (_instance == null)
				{
					lock (_lockObject)
					{
						if (_instance == null) _instance = new Authentication();
					}
				}
				return _instance;
			}
		}
	}
}
