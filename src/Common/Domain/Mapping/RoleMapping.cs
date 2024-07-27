// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Mapping
{
	public static class RoleMapping
	{
		/// <summary>
		/// Map to model
		/// </summary>
		/// <param name="entity">Entity</param>
		/// <returns>Model</returns>
		public static RoleModel MapToModel(this Role entity)
		{
			var model = new RoleModel
			{
				BranchId = entity.BranchId,
				RoleId = entity.RoleId,
				Name = entity.Name,
				Description = entity.Description,
				PageDefault = entity.PageDefault,
				Permission = entity.Permission,
				Priority = entity.Priority,
				Status = entity.Status,
				DateCreated = entity.DateCreated,
				DateChanged = entity.DateChanged,
				CreatedBy = entity.CreatedBy,
			};

			return model;
		}

		/// <summary>
		/// Map search to model
		/// </summary>
		/// <param name="searchDto">Search Dto</param>
		/// <returns>Model</returns>
		public static RoleModel MapSearchToModel(this RoleSearchDto searchDto)
		{
			var model = new RoleModel
			{
				BranchId = searchDto.BranchId,
				RoleId = searchDto.RoleId,
				Name = searchDto.Name,
				Description = searchDto.Description,
				Permission = searchDto.Permission,
				Priority = searchDto.Priority,
				Status = searchDto.Status,
				DateCreated = searchDto.DateCreated,
				DateChanged = searchDto.DateChanged,
				CreatedBy = searchDto.CreatedBy,
			};

			return model;
		}

		/// <summary>
		/// Map to entity
		/// </summary>
		/// <param name="model">Model</param>
		/// <returns>Entity</returns>
		public static Role MapToEntity(this RoleModel model)
		{
			var entity = new Role
			{
				BranchId = model.BranchId,
				RoleId = model.RoleId,
				Name = model.Name,
				Description = model.Description,
				PageDefault = model.PageDefault,
				Permission = model.Permission,
				Priority = model.Priority,
				Status = model.Status,
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
		public static Role MapToEntity(this Role entity, RoleModel model)
		{
			entity.BranchId = model.BranchId;
			entity.RoleId = model.RoleId;
			entity.Name = model.Name;
			entity.Description = model.Description;
			entity.PageDefault = model.PageDefault;
			entity.Permission = model.Permission;
			entity.Priority = model.Priority;
			entity.Status = model.Status;
			entity.DateCreated = model.DateCreated;
			entity.DateChanged = model.DateChanged;
			entity.CreatedBy = model.CreatedBy;

			return entity;
		}
	}
}
