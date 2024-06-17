// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Mapping
{
    public static class ProductMapping
    {
        /// <summary>
        /// Map to model
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Model</returns>
        public static ProductModel MapToModel(this Product entity)
        {
            var model = new ProductModel
            {
                BranchId = entity.BranchId,
                ProductId = entity.ProductId,
                Name = entity.Name,
                Images = entity.Images,
                Address1 = entity.Address1,
                Address2 = entity.Address2,
                Address3 = entity.Address3,
                Address4 = entity.Address4,
                Price1 = entity.Price1,
                Price2 = entity.Price2,
                Price3 = entity.Price3,
                DisplayPrice = entity.DisplayPrice,
                Status = entity.Status,
                DelFlg = entity.DelFlg,
                Size1 = entity.Size1,
                Size2 = entity.Size2,
                Size3 = entity.Size3,
                TakeOverId = entity.TakeOverId,
                Description = entity.Description,
                EmbeddedLink = entity.EmbeddedLink,
                RelatedProductId = entity.RelatedProductId,
                DateCreated = entity.DateCreated,
                DateChanged = entity.DateCreated,
                CreatedBy = entity.CreatedBy,
                LastChanged = entity.LastChanged,
            };

            return model;
        }

        /// <summary>
        /// Map to entity
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>Entity</returns>
        public static Product MapToEntity(this ProductModel model)
        {
            var entity = new Product
            {
                BranchId = model.BranchId,
                ProductId = model.ProductId,
                Name = model.Name,
                Images = model.Images,
                Address1 = model.Address1,
                Address2 = model.Address2,
                Address3 = model.Address3,
                Address4 = model.Address4,
                Price1 = model.Price1,
                Price2 = model.Price2,
                Price3 = model.Price3,
                DisplayPrice = model.DisplayPrice,
                Status = model.Status,
                DelFlg = model.DelFlg,
                Size1 = model.Size1,
                Size2 = model.Size2,
                Size3 = model.Size3,
                TakeOverId = model.TakeOverId,
                Description = model.Description,
                EmbeddedLink = model.EmbeddedLink,
                DateCreated = model.DateCreated,
                DateChanged = model.DateCreated,
                CreatedBy = model.CreatedBy,
                LastChanged = model.LastChanged,
            };

            return entity;
        }
        /// <summary>
        /// Map to product
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="model">Model</param>
        /// <returns>Entity</returns>
        public static Product MapToEntity(this Product entity, ProductModel model)
        {
            entity.Name = model.Name;
            entity.Images = model.Images;
            entity.Address1 = model.Address1;
            entity.Address2 = model.Address2;
            entity.Address3 = model.Address3;
            entity.Address4 = model.Address4;
            entity.Price1 = model.Price1;
            entity.Price2 = model.Price2;
            entity.Price3 = model.Price3;
            entity.DisplayPrice = model.DisplayPrice;
            entity.Status = model.Status;
            entity.Size1 = model.Size1;
            entity.Size2 = model.Size2;
            entity.Size3 = model.Size3;
            entity.TakeOverId = model.TakeOverId;
            entity.Description = model.Description;
            entity.EmbeddedLink = model.EmbeddedLink;
            entity.DateChanged = DateTime.Now;
            entity.CreatedBy = model.CreatedBy;
            entity.LastChanged = model.LastChanged;

            return entity;
        }
    }
}
