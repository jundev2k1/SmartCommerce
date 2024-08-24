// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Mapping
{
	public static class MailTemplateMapping
	{
		/// <summary>
		/// Map to mail template model
		/// </summary>
		/// <param name="entity">Mail template entity</param>
		/// <returns>Model mail template mail template </returns>
		public static MailTemplateModel MapToModel(this MailTemplate entity)
		{
			var model = new MailTemplateModel
			{
				BranchId = entity.BranchId,
				MailId = entity.MailId,
				Subject = entity.Subject,
				Body = entity.Body,
				From = entity.From,
				To = entity.To,
				Cc = entity.Cc,
				Bcc = entity.Bcc,
				Status = entity.Status,
				DateCreated = entity.DateCreated,
				DateChanged = entity.DateChanged,
			};

			return model;
		}

		/// <summary>
		/// Map to mail template entity
		/// </summary>
		/// <param name="model">Model mail template</param>
		/// <returns>Mail template entity</returns>
		public static MailTemplate MapToEntity(this MailTemplateModel model)
		{
			var entity = new MailTemplate
			{
				BranchId = model.BranchId,
				MailId = model.MailId,
				Subject = model.Subject,
				Body = model.Body,
				From = model.From,
				To = model.To,
				Cc = model.Cc,
				Bcc = model.Bcc,
				Status = model.Status,
				DateCreated = model.DateCreated,
				DateChanged = model.DateChanged,
			};

			return entity;
		}
		/// <summary>
		/// Map to mail template entity
		/// </summary>
		/// <param name="entity">Mail template entity</param>
		/// <param name="model">Model mail template</param>
		/// <returns>Mail template entity</returns>
		public static MailTemplate MapToEntity(this MailTemplate entity, MailTemplateModel model)
		{
			entity.BranchId = model.BranchId;
			entity.MailId = model.MailId;
			entity.Subject = model.Subject;
			entity.Body = model.Body;
			entity.From = model.From;
			entity.To = model.To;
			entity.Cc = model.Cc;
			entity.Bcc = model.Bcc;
			entity.Status = model.Status;
			entity.DateCreated = model.DateCreated;
			entity.DateChanged = model.DateChanged;
			return entity;
		}
	}
}
