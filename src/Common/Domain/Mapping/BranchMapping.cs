// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Mapping
{
	public static class BranchMapping
	{
		/// <summary>
		/// Map to branch model
		/// </summary>
		/// <param name="entity">Branch entity</param>
		/// <returns>Branch model</returns>
		public static BranchModel MapToModel(this Branch entity)
		{
			var model = new BranchModel
			{
				BranchId = entity.BranchId,
				Name = entity.Name,
				Avatar = entity.Avatar,
				Status = entity.Status,
				DateCreated = entity.DateCreated,
				LastChanged = entity.LastChanged,
			};

			return model;
		}

		/// <summary>
		/// Map to branch entity
		/// </summary>
		/// <param name="model">Branch model</param>
		/// <returns>Branch entity</returns>
		public static Branch MapToEntity(this BranchModel model)
		{
			var entity = new Branch
			{
				BranchId = model.BranchId,
				Name = model.Name,
				Avatar = model.Avatar,
				Status = model.Status,
				DateCreated = model.DateCreated,
				LastChanged = model.LastChanged,
			};

			return entity;
		}
		/// <summary>
		/// Map to branch entity
		/// </summary>
		/// <param name="entity">Branch entity</param>
		/// <param name="model">Branch model</param>
		/// <returns>Branch entity</returns>
		public static Branch MapToEntity(this Branch entity, BranchModel model)
		{
			entity.BranchId = model.BranchId;
			entity.Name = model.Name;
			entity.Avatar = model.Avatar;
			entity.Status = model.Status;
			entity.DateCreated = model.DateCreated;
			entity.LastChanged = model.LastChanged;

			return entity;
		}
	}
}
