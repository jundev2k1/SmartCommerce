// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Mapping
{
    public static class TokenMapping
    {
        /// <summary>
        /// Map to model
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Model</returns>
        public static TokenModel MapToModel(this Token entity)
        {
            var model = new TokenModel
            {
                BranchId = entity.BranchId,
                TokenId = entity.TokenId,
                ExpirationDate = entity.ExpirationDate,
                Type = entity.Type,
                DateCreated = entity.DateCreated,
                DateChanged = entity.DateChanged,
                CreatedBy = entity.CreatedBy,
            };

            return model;
        }

        /// <summary>
        /// Map to entity
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>Entity</returns>
        public static Token MapToEntity(this TokenModel model)
        {
            var entity = new Token
            {
                BranchId = model.BranchId,
                TokenId = model.TokenId,
                ExpirationDate = model.ExpirationDate,
                Type = model.Type,
                DateCreated = model.DateCreated,
                DateChanged = model.DateChanged,
                CreatedBy = model.CreatedBy,
            };

            return entity;
        }
        /// <summary>
        /// Map to entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="model">Model</param>
        /// <returns>Entity</returns>
        public static Token MapToEntity(this Token entity, TokenModel model)
        {
            entity.BranchId = model.BranchId;
            entity.TokenId = model.TokenId;
            entity.ExpirationDate = model.ExpirationDate;
            entity.Type = model.Type;
            entity.DateCreated = model.DateCreated;
            entity.DateChanged = model.DateChanged;
            entity.CreatedBy = model.CreatedBy;

            return entity;
        }
    }
}
