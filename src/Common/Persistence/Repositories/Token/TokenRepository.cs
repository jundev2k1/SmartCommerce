// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Repositories
{
    public sealed class TokenRepository : RepositoryBase, ITokenRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">Context</param>
        public TokenRepository(DBContext dbContext, IFileLogger logger) : base(dbContext, logger)
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

            return result?.MapToModel();
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="model">Token model</param>
        /// <returns>Status insert</returns>
        public bool Insert(TokenModel model)
        {
            var result = BeginTransaction(() =>
            {
                var token = _dbContext.Tokens.FirstOrDefault(item =>
                    (item.BranchId == model.BranchId)
                    && (item.TokenId == model.TokenId));
                if (token != null) throw new NotExistInDBException();

                var insertModel = model.MapToEntity();
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

                var updateModel = token.MapToEntity(model);
                _dbContext.Update(updateModel);
                _dbContext.SaveChanges();
            });

            return result;
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="tokenId">Token id</param>
        /// <param name="UpdateAction">Update action</param>
        /// <returns>Update status</returns>
        public bool Update(string branchId, string tokenId, Action<Token> UpdateAction)
        {
            var result = BeginTransaction(() =>
            {
                var token = _dbContext.Tokens.FirstOrDefault(item =>
                    (item.BranchId == branchId)
                    && (item.TokenId == tokenId));
                if (token == null) throw new NotExistInDBException();

                UpdateAction(token);
                _dbContext.SaveChanges();
            });
            return result;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="tokenId">Token id</param>
        /// <returns>Delete status</returns>
        public bool Delete(string branchId, string tokenId)
        {
            var result = BeginTransaction(() =>
            {
                var token = _dbContext.Tokens.FirstOrDefault(item =>
                    item.BranchId == branchId
                    && item.TokenId == tokenId);
                if (token == null) throw new NotExistInDBException();

                _dbContext.Remove(token);
                _dbContext.SaveChanges();
            });

            return result;
        }
    }
}
