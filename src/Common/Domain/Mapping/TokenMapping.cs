// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Mapping
{
    public static class TokenMapping
    {
        /// <summary>
        /// Map to token model
        /// </summary>
        /// <param name="tokenEntity">Token entity</param>
        /// <returns>Token model</returns>
        public static TokenModel MapToTokenModel(this Token tokenEntity)
        {
            var model = new TokenModel
            {
                BranchId = tokenEntity.BranchId,
                TokenId = tokenEntity.TokenId,
                ExpirationDate = tokenEntity.ExpirationDate,
                Type = tokenEntity.Type,
                DateCreated = tokenEntity.DateCreated,
                DateChanged = tokenEntity.DateChanged,
                CreatedBy = tokenEntity.CreatedBy,
            };

            return model;
        }

        /// <summary>
        /// Map to token entity
        /// </summary>
        /// <param name="tokenModel">Token model</param>
        /// <returns>Token entity</returns>
        public static Token MapToTokenEntity(this TokenModel tokenModel)
        {
            var entity = new Token
            {
                BranchId = tokenModel.BranchId,
                TokenId = tokenModel.TokenId,
                ExpirationDate = tokenModel.ExpirationDate,
                Type = tokenModel.Type,
                DateCreated = tokenModel.DateCreated,
                DateChanged = tokenModel.DateChanged,
                CreatedBy = tokenModel.CreatedBy,
            };

            return entity;
        }

        /// <summary>
        /// Map to token entity
        /// </summary>
        /// <param name="tokenModel">Token model</param>
        /// <returns>Token entity</returns>
        public static Token MapToTokenEntity(this Token tokenEntity, TokenModel tokenModel)
        {
            tokenEntity.BranchId = tokenModel.BranchId;
            tokenEntity.TokenId = tokenModel.TokenId;
            tokenEntity.ExpirationDate = tokenModel.ExpirationDate;
            tokenEntity.Type = tokenModel.Type;
            tokenEntity.DateCreated = tokenModel.DateCreated;
            tokenEntity.DateChanged = tokenModel.DateChanged;
            tokenEntity.CreatedBy = tokenModel.CreatedBy;
            return tokenEntity;
        }
    }
}
