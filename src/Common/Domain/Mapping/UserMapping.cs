// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Domain.Mapping
{
	public static class UserMapping
	{
		/// <summary>
		/// Map to user model
		/// </summary>
		/// <param name="entity">User entity</param>
		/// <returns>User model</returns>
		public static UserModel MapToModel(this User entity)
		{
			var model = new UserModel
			{
				BranchId = entity.BranchId,
				UserId = entity.UserId,
				UserName = entity.UserName,
				Password = entity.Password,
				Avatar = entity.Avatar,
				FirstName = entity.FirstName,
				LastName = entity.LastName,
				Email = entity.Email,
				PhoneNumber = entity.PhoneNumber,
				Address1 = entity.Address1,
				Address2 = entity.Address2,
				Address3 = entity.Address3,
				Address4 = entity.Address4,
				Status = entity.Status,
				DelFlg = entity.DelFlg,
				Sex = entity.Sex,
				Birthday = entity.Birthday,
				DateCreated = entity.DateCreated,
				DateChanged = entity.DateChanged,
				CreatedBy = entity.CreatedBy,
				LastLogin = entity.LastLogin,
				LastChanged = entity.LastChanged,
				RoleId = entity.RoleId,
			};

			return model;
		}

		/// <summary>
		/// Map filter to user model
		/// </summary>
		/// <param name="filterModel">Filter model</param>
		/// <returns>User model</returns>
		public static UserModel MapSearchToModel(this UserFilterModel filterModel)
		{
			var model = new UserModel
			{
				BranchId = filterModel.BranchId,
				UserId = filterModel.UserId,
				UserName = filterModel.UserName,
				FirstName= filterModel.FirstName,
				LastName= filterModel.LastName,
				Email = filterModel.Email,
				PhoneNumber = filterModel.PhoneNumber,
				Address1 = filterModel.Address1,
				Address2 = filterModel.Address2,
				Address3 = filterModel.Address3,
				Address4 = filterModel.Address4,
				Status = filterModel.Status,
				CreatedBy= filterModel.CreatedBy,
				LastLogin = filterModel.LastLogin,
				DelFlg = filterModel.DelFlg,
				RoleId= filterModel.RoleId,
			};

			return model;
		}

		/// <summary>
		/// Map to user entity
		/// </summary>
		/// <param name="model">User model</param>
		/// <returns>User entity</returns>
		public static User MapToEntity(this UserModel model)
		{
			var entity = new User
			{
				BranchId = model.BranchId,
				UserId = model.UserId,
				UserName = model.UserName,
				Password = model.Password,
				Avatar = model.Avatar,
				FirstName = model.FirstName,
				LastName = model.LastName,
				Email = model.Email,
				PhoneNumber = model.PhoneNumber,
				Address1 = model.Address1,
				Address2 = model.Address2,
				Address3 = model.Address3,
				Address4 = model.Address4,
				Status = model.Status,
				DelFlg = model.DelFlg,
				Sex = model.Sex,
				Birthday = model.Birthday,
				DateCreated = model.DateCreated,
				DateChanged = model.DateChanged,
				CreatedBy = model.CreatedBy,
				LastLogin = model.LastLogin,
				LastChanged = model.LastChanged,
				RoleId = model.RoleId,
			};

			return entity;
		}
		/// <summary>
		/// Map to user entity
		/// </summary>
		/// <param name="entity">User entity</param>
		/// <param name="model">User model</param>
		/// <returns>User entity</returns>
		public static User MapToEntity(this User entity, UserModel model)
		{
			entity.BranchId = model.BranchId;
			entity.UserId = model.UserId;
			entity.UserName = model.UserName;
			entity.Password = model.Password;
			entity.Avatar = model.Avatar;
			entity.FirstName = model.FirstName;
			entity.LastName = model.LastName;
			entity.Email = model.Email;
			entity.PhoneNumber = model.PhoneNumber;
			entity.Address1 = model.Address1;
			entity.Address2 = model.Address2;
			entity.Address3 = model.Address3;
			entity.Address4 = model.Address4;
			entity.Status = model.Status;
			entity.DelFlg = model.DelFlg;
			entity.Sex = model.Sex;
			entity.Birthday = model.Birthday;
			entity.DateCreated = model.DateCreated;
			entity.DateChanged = model.DateChanged;
			entity.CreatedBy = model.CreatedBy;
			entity.LastLogin = model.LastLogin;
			entity.LastChanged = model.LastChanged;
			entity.RoleId = model.RoleId;

			return entity;
		}
	}
}
