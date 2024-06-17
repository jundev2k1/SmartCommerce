// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Services
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
        #endregion

        #region Command
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
