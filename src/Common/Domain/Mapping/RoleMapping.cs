﻿// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Domain.Mapping
{
	public static class RoleMapping
	{
		/// <summary>
		/// Map to role model
		/// </summary>
		/// <param name="entity">Role entity</param>
		/// <returns>Role model</returns>
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
		/// Map to role entity
		/// </summary>
		/// <param name="model">Role model</param>
		/// <returns>Role entity</returns>
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
		/// Map to role entity
		/// </summary>
		/// <param name="entity">Role entity</param>
		/// <param name="model">Role model</param>
		/// <returns>Role entity</returns>
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
