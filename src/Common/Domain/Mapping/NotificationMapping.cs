// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Domain.Mapping
{
	public static class NotificationMapping
	{
		/// <summary>
		/// Map to notification model
		/// </summary>
		/// <param name="entity">Notification entity</param>
		/// <returns>Notification model</returns>
		public static NotificationModel MapToModel(this Notification entity)
		{
			var model = new NotificationModel
			{
				BranchId = entity.BranchId,
				Id = entity.Id,
				UserId = entity.UserId,
				Title = entity.Title,
				Content = entity.Content,
				Path = entity.Path,
				Type = entity.Type,
				Priority = entity.Priority,
				Status = entity.Status,
				DateCreated = entity.DateCreated,
				CreatedBy = entity.CreatedBy,
			};

			return model;
		}

		/// <summary>
		/// Map to notification entity
		/// </summary>
		/// <param name="model">Notification model</param>
		/// <returns>Notification entity</returns>
		public static Notification MapToEntity(this NotificationModel model)
		{
			var entity = new Notification
			{
				BranchId = model.BranchId,
				Id = model.Id,
				UserId = model.UserId,
				Title = model.Title,
				Content = model.Content,
				Path = model.Path,
				Type = model.Type,
				Priority = model.Priority,
				Status = model.Status,
				DateCreated = model.DateCreated,
				CreatedBy = model.CreatedBy,
			};

			return entity;
		}
		/// <summary>
		/// Map to notification entity
		/// </summary>
		/// <param name="entity">Notification entity</param>
		/// <param name="model">Notification model</param>
		/// <returns>Notification entity</returns>
		public static Notification MapToEntity(this Notification entity, NotificationModel model)
		{
			entity.BranchId = model.BranchId;
			entity.Id = model.Id;
			entity.UserId = model.UserId;
			entity.Title = model.Title;
			entity.Content = model.Content;
			entity.Path = model.Path;
			entity.Type = model.Type;
			entity.Priority = model.Priority;
			entity.Status = model.Status;
			entity.DateCreated = model.DateCreated;
			entity.CreatedBy = model.CreatedBy;
			return entity;
		}
	}
}
