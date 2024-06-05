// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Repositories
{
    public sealed class TokenRepository : RepositoryBase, ITokenRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">Context</param>
        public TokenRepository(DBContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="tokenId">Token id</param>
        /// <returns>Token model</returns>
        public TokenModel? Get(string branchId, string tokenId)
        {
            var result = _dbContext.Tokens.FirstOrDefault(token =>
                token.BranchId == branchId
                && token.TokenId == tokenId);

            return result?.MapToTokenModel();
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="model">Token model</param>
        /// <returns>Status insert</returns>
        public bool Insert(TokenModel model)
        {
            var token = Get(model.BranchId, model.TokenId);
            if (token != null) return false;

            var result = BeginTransaction(() =>
            {
                var insertModel = model.MapToTokenEntity();
                _dbContext.Add(insertModel);
                _dbContext.SaveChanges();
            });
            return result;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model">Token model</param>
        /// <returns>Status update</returns>
        public bool Update(TokenModel model)
        {
            var result = BeginTransaction(() =>
            {
                var token = _dbContext.Tokens.FirstOrDefault(item =>
                    item.BranchId == model.BranchId
                    && item.TokenId == model.TokenId);
                if (token == null) throw new Exception();

                var updateModel = token.MapToTokenEntity(model);
                _dbContext.Update(updateModel);
                _dbContext.SaveChanges();
            });

            return result;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="branchID">Branch id</param>
        /// <param name="tokenId">Role id</param>
        /// <returns>Delete status</returns>
        public bool Delete(string branchID, string tokenId)
        {
            var role = Get(branchID, tokenId);
            if (role == null) return false;

            var result = BeginTransaction(() =>
            {
                _dbContext.Remove(role);
                _dbContext.SaveChanges();
            });

            return result;
        }
    }
}
