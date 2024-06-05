// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Repositories
{
    public interface ITokenRepository
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="branchID">Branch id</param>
        /// <param name="tokenId">Token id</param>
        /// <returns>Token model</returns>
        public TokenModel? Get(string branchID, string tokenId);

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
        /// <param name="branchID">Branch id</param>
        /// <param name="tokenId">Token id</param>
        /// <returns>Delete status</returns>
        public bool Delete(string branchID, string tokenId);
    }
}
