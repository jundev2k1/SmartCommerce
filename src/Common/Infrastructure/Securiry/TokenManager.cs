// Copyright (c) 2024 - Jun Dev. All rights reserved

using System.Text.Json;

namespace ErpManager.Infrastructure.Securiry
{
	public class TokenManager
	{
		private static TokenManager? _instance { get; set; }
		private static readonly object _lockObject = new object();

		private TokenManager()
		{
		}

		public string GenerateToken(
			Dictionary<string, string> claims,
			int expirationDateCount = 1)
		{
			var expirationDate = DateTime.Now.AddDays(expirationDateCount);
			claims.TryAdd(
				Constants.TOKEN_KEY_EXPIRATION_DATE,
				expirationDate.ToString(Constants.DATE_FORMAT_SHORT_DATE_TIME));
			var strData = JsonSerializer.Serialize(claims);
			var result = Authentication.Instance.PasswordEncrypt(strData);
			return result;
		}

		public Dictionary<string, string>? DecodeToken(string token)
		{
			try
			{
				var claims = Authentication.Instance.PasswordDecrypt(token);
				var result = JsonSerializer.Deserialize<Dictionary<string, string>>(claims);
				return result;
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>Instance</summary>
		public static TokenManager Instance
		{
			get
			{
				if (_instance == null)
				{
					lock (_lockObject)
					{
						if (_instance == null) _instance = new TokenManager();
					}
				}
				return _instance;
			}
		}
	}
}
