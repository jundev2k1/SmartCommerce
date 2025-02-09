// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Services
{
	public sealed class TokenService : ServiceBase, ITokenService
	{
		#region Constructor
		/// <summary>Context singleton</summary>
		private readonly ITokenRepository _tokenRepository;

		/// <summary>
		/// Constructor
		/// </summary>
		public TokenService(ITokenRepository tokenRepository)
		{
			_tokenRepository = tokenRepository;
		}
		#endregion

		#region Queries
		/// <summary>
		/// Get role
		/// </summary>
		/// <param name="branchId">Branch Id</param>
		/// <param name="tokenId">Token id</param>
		/// <returns>Token model</returns>
		public TokenModel? Get(string branchId, string tokenId)
		{
			return _tokenRepository.Get(branchId, tokenId);
		}

		/// <summary>
		/// Is valid token
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="type">Type token</param>
		/// <param name="tokenId">Token code</param>
		/// <returns>Is valid?</returns>
		public bool IsValid(string branchId, TokenTypeEnum type, string tokenId)
		{
			var token = _tokenRepository.Get(branchId, tokenId);
			var result = token != null
				&& token.Type == type
				&& token.ExpirationDate > DateTime.Now;
			return result;
		}
		#endregion

		#region Command
		public string GenerateToken(
			string branchId,
			Dictionary<string, string> claims,
			TokenTypeEnum type,
			int expirationDateCount = 1,
			string createdBy = "")
		{
			var tokenId = TokenManager.Instance.GenerateToken(claims, expirationDateCount);
			var tokenModel = new TokenModel()
			{
				BranchId = branchId,
				TokenId = tokenId,
				Type = type,
				ExpirationDate = DateTime.Now.AddDays(expirationDateCount),
				DateCreated = DateTime.Now,
				CreatedBy = createdBy,
			};
			var isSuccess = Insert(tokenModel);
			return isSuccess ? tokenId : string.Empty;
		}

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Token model</param>
		/// <returns>Inser status</returns>
		public bool Insert(TokenModel model)
		{
			return _tokenRepository.Insert(model);
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Token model</param>
		/// <returns>Update status</returns>
		public bool Update(TokenModel model)
		{
			return _tokenRepository.Update(model);
		}
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="tokenId">Token id</param>
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		public bool Update(string branchId, string tokenId, Action<Token> updateAction)
		{
			return _tokenRepository.Update(branchId, tokenId, updateAction);
		}

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="tokenId">Token id</param>
		/// <returns>Update status</returns>
		public bool Delete(string branchId, string tokenId)
		{
			return _tokenRepository.Delete(branchId, tokenId);
		}

		#endregion
	}
}
