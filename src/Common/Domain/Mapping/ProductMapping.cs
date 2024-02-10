// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Domain.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace ErpManager.Domain.Mapping
{
    public static class ProductMapping
    {
        /// <summary>
        /// Map to product model
        /// </summary>
        /// <param name="productEntity">Product entity</param>
        /// <returns>Product model</returns>
        public static ProductModel MapToProductModel(this Product productEntity)
        {
            var model = new ProductModel
            {
                BranchId = productEntity.BranchId,
                ProductId = productEntity.ProductId,
                Name = productEntity.Name,
                Images = productEntity.Images,
                Address1 = productEntity.Address1,
                Address2 = productEntity.Address2,
                Address3 = productEntity.Address3,
                Address4 = productEntity.Address4,
                Price1 = productEntity.Price1,
                Price2 = productEntity.Price2,
                Price3 = productEntity.Price3,
                DisplayPrice = productEntity.DisplayPrice,
                Status = productEntity.Status,
                DelFlg = productEntity.DelFlg,
                Size1 = productEntity.Size1,
                Size2 = productEntity.Size2,
                Size3 = productEntity.Size3,
                TakeOverId = productEntity.TakeOverId,
                DateCreated = productEntity.DateCreated,
                DateChanged = productEntity.DateCreated,
                CreatedBy = productEntity.CreatedBy,
                LastChanged = productEntity.LastChanged,
            };

            return model;
        }

        /// <summary>
        /// Map to product entity
        /// </summary>
        /// <param name="productModel">Product model</param>
        /// <returns>Product entity</returns>
        public static Product MapToProductEntity(this ProductModel productModel)
        {
            var entity = new Product
            {
                BranchId = productModel.BranchId,
                ProductId = productModel.ProductId,
                Name = productModel.Name,
                Images = productModel.Images,
                Address1 = productModel.Address1,
                Address2 = productModel.Address2,
                Address3 = productModel.Address3,
                Address4 = productModel.Address4,
                Price1 = productModel.Price1,
                Price2 = productModel.Price2,
                Price3 = productModel.Price3,
                DisplayPrice = productModel.DisplayPrice,
                Status = productModel.Status,
                DelFlg = productModel.DelFlg,
                Size1 = productModel.Size1,
                Size2 = productModel.Size2,
                Size3 = productModel.Size3,
                TakeOverId = productModel.TakeOverId,
                DateCreated = productModel.DateCreated,
                DateChanged = productModel.DateCreated,
                CreatedBy = productModel.CreatedBy,
                LastChanged = productModel.LastChanged,
            };

            return entity;
        }
    }
}
