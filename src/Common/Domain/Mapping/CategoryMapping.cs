// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace SmartCommerce.Domain.Mapping
{
	public static class ProductCategoryMapping
	{
		/// <summary>
		/// Map to category model
		/// </summary>
		/// <param name="entity">ProductCategory entity</param>
		/// <returns>ProductCategory model</returns>
		public static ProductCategoryModel MapToModel(this ProductCategory entity)
		{
			var model = new ProductCategoryModel
            {
				BranchId = entity.BranchId,
				CategoryId = entity.CategoryId,
				Name = entity.Name,
				Avatar = entity.Avatar,
				Description = entity.Description,
				ParentId = entity.ParentId,
				Priority = entity.Priority,
				DelFlg = entity.DelFlg,
				DateCreated = entity.DateCreated,
				DateChanged = entity.DateCreated,
				CreatedBy = entity.CreatedBy,
				LastChanged = entity.LastChanged,
			};

			return model;
		}

		/// <summary>
		/// Map search to category model
		/// </summary>
		/// <param name="filterModel">Filter model</param>
		/// <returns>ProductCategory model</returns>
		public static ProductCategoryModel MapSearchToModel(this ProductCategoryFilterModel filterModel)
		{
			var model = new ProductCategoryModel
			{
				BranchId = filterModel.BranchId,
				CategoryId = filterModel.CategoryId,
				Name = filterModel.Name,
				ParentId = filterModel.ParentId,
				DelFlg = filterModel.DelFlg,
				CreatedBy = filterModel.CreatedBy,
			};

			return model;
		}

		/// <summary>
		/// Map to category entity
		/// </summary>
		/// <param name="model">Product category model</param>
		/// <returns>Product category entity</returns>
		public static ProductCategory MapToEntity(this ProductCategoryModel model)
		{
			var entity = new ProductCategory
			{
				BranchId = model.BranchId,
				CategoryId = model.CategoryId,
				Name = model.Name,
				Avatar = model.Avatar,
				Description = model.Description,
				ParentId = model.ParentId,
				Priority = model.Priority,
				DelFlg = model.DelFlg,
				DateCreated = model.DateCreated,
				DateChanged = model.DateCreated,
				CreatedBy = model.CreatedBy,
				LastChanged = model.LastChanged,
			};

			return entity;
		}
		/// <summary>
		/// Map to category entity
		/// </summary>
		/// <param name="entity">Product category entity</param>
		/// <param name="model">Product category model</param>
		/// <returns>Product category entity</returns>
		public static ProductCategory MapToEntity(this ProductCategory entity, ProductCategoryModel model)
		{
			entity.BranchId = model.BranchId;
			entity.CategoryId = model.CategoryId;
			entity.Name = model.Name;
			entity.Avatar = model.Avatar;
			entity.Description = model.Description;
			entity.ParentId = model.ParentId;
			entity.Priority = model.Priority;
			entity.DelFlg = model.DelFlg;
			entity.DateCreated = model.DateCreated;
			entity.DateChanged = model.DateCreated;
			entity.CreatedBy = model.CreatedBy;
			entity.LastChanged = model.LastChanged;

			return entity;
		}
	}
}
