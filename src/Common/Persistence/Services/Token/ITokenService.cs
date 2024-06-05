// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Services
{
    public interface ITokenService
    {
        /// <summary>
        /// Get token
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="TokenId">Token id</param>
        /// <returns>Token model</returns>
        public TokenModel? GetToken(string branchId, string TokenId);

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="model">Token model</param>
        /// <returns>Insert status</returns>
        public bool Insert(TokenModel model);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model">Token model</param>
        /// <returns>Update status</returns>
        public bool Update(TokenModel model);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="tokenId">Token id</param>
        /// <returns>Delete status</returns>
        public bool Delete(string branchId, string tokenId);
    }
}
