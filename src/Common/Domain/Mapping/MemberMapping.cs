// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Domain.Entities;

namespace ErpManager.Domain.Mapping
{
	public static class MemberMapping
	{
		/// <summary>
		/// Map to model
		/// </summary>
		/// <param name="entity">Entity</param>
		/// <returns>Model</returns>
		public static MemberModel MapToModel(this Member entity)
		{
			var model = new MemberModel
			{
				BranchId = entity.BranchId,
				MemberId = entity.MemberId,
				FirstName = entity.FirstName,
				LastName = entity.LastName,
				Avatar = entity.Avatar,
				Email = entity.Email,
				CardNumber = entity.CardNumber,
				PhoneNumber = entity.PhoneNumber,
				BackupPhoneNumber = entity.BackupPhoneNumber,
				Address1 = entity.Address1,
				Address2 = entity.Address2,
				Address3 = entity.Address3,
				Address4 = entity.Address4,
				SubAddress1 = entity.SubAddress1,
				SubAddress2 = entity.SubAddress2,
				SubAddress3 = entity.SubAddress3,
				SubAddress4 = entity.SubAddress4,
				BackupAddress = entity.BackupAddress,
				Status = entity.Status,
				DelFlg = entity.DelFlg,
				Sex = entity.Sex,
				Birthday = entity.Birthday,
				Note = entity.Note,
				DateCreated = entity.DateCreated,
				DateChanged = entity.DateChanged,
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
		public static Member MapToEntity(this MemberModel model)
		{
			var entity = new Member
			{
				BranchId = model.BranchId,
				MemberId = model.MemberId,
				FirstName = model.FirstName,
				LastName = model.LastName,
				Avatar = model.Avatar,
				Email = model.Email,
				CardNumber = model.CardNumber,
				PhoneNumber = model.PhoneNumber,
				BackupPhoneNumber = model.BackupPhoneNumber,
				Address1 = model.Address1,
				Address2 = model.Address2,
				Address3 = model.Address3,
				Address4 = model.Address4,
				SubAddress1 = model.SubAddress1,
				SubAddress2 = model.SubAddress2,
				SubAddress3 = model.SubAddress3,
				SubAddress4 = model.SubAddress4,
				BackupAddress = model.BackupAddress,
				Status = model.Status,
				DelFlg = model.DelFlg,
				Sex = model.Sex,
				Birthday = model.Birthday,
				Note = model.Note,
				DateCreated = model.DateCreated,
				DateChanged = model.DateChanged,
				CreatedBy = model.CreatedBy,
				LastChanged = model.LastChanged,
			};

			return entity;
		}
		/// <summary>
		/// Map to entity
		/// </summary>
		/// <param name="entity">Entity</param>
		/// <param name="model">Model</param>
		/// <returns>Entity</returns>
		public static Member MapToEntity(this Member entity, MemberModel model)
		{
			entity.BranchId = model.BranchId;
			entity.MemberId = model.MemberId;
			entity.FirstName = model.FirstName;
			entity.LastName = model.LastName;
			entity.Avatar = model.Avatar;
			entity.Email = model.Email;
			entity.CardNumber = model.CardNumber;
			entity.PhoneNumber = model.PhoneNumber;
			entity.BackupPhoneNumber = model.BackupPhoneNumber;
			entity.Address1 = model.Address1;
			entity.Address2 = model.Address2;
			entity.Address3 = model.Address3;
			entity.Address4 = model.Address4;
			entity.SubAddress1 = model.SubAddress1;
			entity.SubAddress2 = model.SubAddress2;
			entity.SubAddress3 = model.SubAddress3;
			entity.SubAddress4 = model.SubAddress4;
			entity.BackupAddress = model.BackupAddress;
			entity.Status = model.Status;
			entity.DelFlg = model.DelFlg;
			entity.Sex = model.Sex;
			entity.Birthday = model.Birthday;
			entity.Note = model.Note;
			entity.DateCreated = model.DateCreated;
			entity.DateChanged = model.DateChanged;
			entity.CreatedBy = model.CreatedBy;
			entity.LastChanged = model.LastChanged;
			return entity;
		}
	}
}
