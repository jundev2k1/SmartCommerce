// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Mapping
{
	public static class ProductMapping
	{
		/// <summary>
		/// Map to product model
		/// </summary>
		/// <param name="entity">Product entity</param>
		/// <returns>Product model</returns>
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
				ShortDescription = entity.ShortDescription,
				Description = entity.Description,
				EmbeddedLink = entity.EmbeddedLink,
				RelatedProductId = entity.RelatedProductId,
				CategoryId1 = entity.CategoryId1,
				CategoryId2 = entity.CategoryId2,
				CategoryId3 = entity.CategoryId3,
				CategoryId4 = entity.CategoryId4,
				CategoryId5 = entity.CategoryId5,
				CategoryId6 = entity.CategoryId6,
				CategoryId7 = entity.CategoryId7,
				CategoryId8 = entity.CategoryId8,
				CategoryId9 = entity.CategoryId9,
				CategoryId10 = entity.CategoryId10,
				DateCreated = entity.DateCreated,
				DateChanged = entity.DateCreated,
				CreatedBy = entity.CreatedBy,
				LastChanged = entity.LastChanged,
			};

			return model;
		}

		/// <summary>
		/// Map search to product model
		/// </summary>
		/// <param name="filterModel">Filter model</param>
		/// <returns>Product model</returns>
		public static ProductModel MapSearchToModel(this ProductFilterModel filterModel)
		{
			var model = new ProductModel
			{
				BranchId = filterModel.BranchId,
				ProductId = filterModel.ProductId,
				Name = filterModel.ProductName,
				Address1 = filterModel.Address1,
				Address2 = filterModel.Address2,
				Address3 = filterModel.Address3,
				Address4 = filterModel.Address4,
				DisplayPrice = filterModel.DisplayPrice ?? DisplayPriceEnum.Price1,
				Status = filterModel.Status ?? ProductStatusEnum.Normal,
				DelFlg = filterModel.DelFlg,
				TakeOverId = filterModel.TakeOverId,
				CreatedBy = filterModel.CreatedBy,
			};

			return model;
		}

		/// <summary>
		/// Map to product entity
		/// </summary>
		/// <param name="model">Product model</param>
		/// <returns>Product entity</returns>
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
				ShortDescription = model.ShortDescription,
				Description = model.Description,
				EmbeddedLink = model.EmbeddedLink,
				RelatedProductId = model.RelatedProductId,
				CategoryId1 = model.CategoryId1,
				CategoryId2 = model.CategoryId2,
				CategoryId3 = model.CategoryId3,
				CategoryId4 = model.CategoryId4,
				CategoryId5 = model.CategoryId5,
				CategoryId6 = model.CategoryId6,
				CategoryId7 = model.CategoryId7,
				CategoryId8 = model.CategoryId8,
				CategoryId9 = model.CategoryId9,
				CategoryId10 = model.CategoryId10,
				DateCreated = model.DateCreated,
				DateChanged = model.DateCreated,
				CreatedBy = model.CreatedBy,
				LastChanged = model.LastChanged,
			};

			return entity;
		}
		/// <summary>
		/// Map to product entity
		/// </summary>
		/// <param name="entity">Product entity</param>
		/// <param name="model">Product model</param>
		/// <returns>Product entity</returns>
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
			entity.ShortDescription = model.ShortDescription;
			entity.Description = model.Description;
			entity.EmbeddedLink = model.EmbeddedLink;
			entity.RelatedProductId = model.RelatedProductId;
			entity.CategoryId1 = model.CategoryId1;
			entity.CategoryId2 = model.CategoryId2;
			entity.CategoryId3 = model.CategoryId3;
			entity.CategoryId4 = model.CategoryId4;
			entity.CategoryId5 = model.CategoryId5;
			entity.CategoryId6 = model.CategoryId6;
			entity.CategoryId7 = model.CategoryId7;
			entity.CategoryId8 = model.CategoryId8;
			entity.CategoryId9 = model.CategoryId9;
			entity.CategoryId10 = model.CategoryId10;
			entity.DateChanged = model.DateChanged ?? DateTime.Now;
			entity.CreatedBy = model.CreatedBy;
			entity.LastChanged = model.LastChanged;

			return entity;
		}
	}
}
