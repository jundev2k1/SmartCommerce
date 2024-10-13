// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Mapping
{
	public static class CategoryMapping
	{
		/// <summary>
		/// Map to category model
		/// </summary>
		/// <param name="entity">Category entity</param>
		/// <returns>Category model</returns>
		public static CategoryModel MapToModel(this Category entity)
		{
			var model = new CategoryModel
			{
				BranchId = entity.BranchId,
				CategoryId = entity.CategoryId,
				CategoryName = entity.CategoryName,
				Avatar = entity.Avatar,
				Description = entity.Description,
				ParentCategoryId = entity.ParentCategoryId,
				Priority = entity.Priority,
				Status = entity.Status,
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
		/// <returns>Category model</returns>
		public static CategoryModel MapSearchToModel(this CategoryFilterModel filterModel)
		{
			var model = new CategoryModel
			{
				BranchId = filterModel.BranchId,
				CategoryId = filterModel.CategoryId,
				CategoryName = filterModel.CategoryName,
				ParentCategoryId = filterModel.ParentCategoryId,
				Status = filterModel.Status ?? CategoryStatusEnum.Active,
				DelFlg = filterModel.DelFlg,
				CreatedBy = filterModel.CreatedBy,
			};

			return model;
		}

		/// <summary>
		/// Map to category entity
		/// </summary>
		/// <param name="model">Category model</param>
		/// <returns>Category entity</returns>
		public static Category MapToEntity(this CategoryModel model)
		{
			var entity = new Category
			{
				BranchId = model.BranchId,
				CategoryId = model.CategoryId,
				CategoryName = model.CategoryName,
				Avatar = model.Avatar,
				Description = model.Description,
				ParentCategoryId = model.ParentCategoryId,
				Priority = model.Priority,
				Status = model.Status,
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
		/// <param name="entity">Category entity</param>
		/// <param name="model">Category model</param>
		/// <returns>Category entity</returns>
		public static Category MapToEntity(this Category entity, CategoryModel model)
		{
			entity.BranchId = model.BranchId;
			entity.CategoryId = model.CategoryId;
			entity.CategoryName = model.CategoryName;
			entity.Avatar = model.Avatar;
			entity.Description = model.Description;
			entity.ParentCategoryId = model.ParentCategoryId;
			entity.Priority = model.Priority;
			entity.Status = model.Status;
			entity.DelFlg = model.DelFlg;
			entity.DateCreated = model.DateCreated;
			entity.DateChanged = model.DateCreated;
			entity.CreatedBy = model.CreatedBy;
			entity.LastChanged = model.LastChanged;

			return entity;
		}
	}
}
