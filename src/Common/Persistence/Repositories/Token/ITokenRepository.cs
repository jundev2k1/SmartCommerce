// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Repositories
{
	public interface ITokenRepository
	{
		/// <summary>
		/// Get
		/// </summary>
		/// <param name="branchID">Branch id</param>
		/// <param name="tokenId">Token id</param>
		/// <returns>Token model</returns>
		Task<TokenModel?> Get(string branchID, string tokenId);

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
		/// <param name="tokenId">Token id</param>
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		Task<bool> Update(string branchId, string tokenId, Action<Token> updateAction);

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchID">Branch id</param>
		/// <param name="tokenId">Token id</param>
		/// <returns>Delete status</returns>
		Task<bool> Delete(string branchID, string tokenId);
	}
}
