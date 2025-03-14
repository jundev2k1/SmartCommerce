// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Services
{
	public interface ITokenService
	{
		/// <summary>
		/// Get token
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="TokenId">Token id</param>
		/// <returns>Token model</returns>
		Task<TokenModel?> Get(string branchId, string TokenId);

		/// <summary>
		/// Is valid token
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="type">Type token</param>
		/// <param name="tokenId">Token code</param>
		/// <returns>Is valid?</returns>
		Task<bool> IsValid(string branchId, TokenTypeEnum type, string tokenId);

		/// <summary>
		/// Generate token
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="claims">Claims</param>
		/// <param name="type">Type</param>
		/// <param name="expirationDateCount">Expiration date count</param>
		/// <param name="createdBy">Created by</param>
		/// <returns>Token id</returns>
		Task<string> GenerateToken(
			string branchId,
			Dictionary<string, string> claims,
			TokenTypeEnum type,
			int expirationDateCount = 1,
			string createdBy = "");

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="model">Token model</param>
		/// <returns>Insert status</returns>
		Task<bool> Insert(TokenModel model);

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Token model</param>
		/// <returns>Update status</returns>
		Task<bool> Update(TokenModel model);
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="memberId">Member id</param>
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		Task<bool> Update(string branchId, string memberId, Action<Token> updateAction);

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="tokenId">Token id</param>
		/// <returns>Delete status</returns>
		Task<bool> Delete(string branchId, string tokenId);
	}
}
