// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Models
{
	public sealed class MailTemplateModel : ModelBase<MailTemplateModel>
	{
		public string BranchId { get; set; } = string.Empty;

		public string MailId { get; set; } = string.Empty;

		public string Subject { get; set; } = string.Empty;

		public string Body { get; set; } = string.Empty;

		public string To { get; set; } = string.Empty;

		public string From { get; set; } = string.Empty;

		public string Cc { get; set; } = string.Empty;

		public string Bcc { get; set; } = string.Empty;

		public MailTemplateStatusEnum Status { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime DateChanged { get; set; }

		public string LastChanged { get; set; } = string.Empty;
	}
}
