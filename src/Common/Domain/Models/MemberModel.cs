// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Domain.Models
{
	public sealed class MemberModel : ModelBase
	{
		public string BranchId { get; set; } = string.Empty;

		public string MemberId { get; set; } = string.Empty;

		public string FirstName { get; set; } = string.Empty;

		public string LastName { get; set; } = string.Empty;

		public string FullName => $"{FirstName} {LastName}".Trim();

		public string Avatar { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;

		public string CardNumber { get; set; } = string.Empty;

		public string PhoneNumber { get; set; } = string.Empty;

		public string BackupPhoneNumber { get; set; } = string.Empty;

		public string Address1 { get; set; } = string.Empty;

		public string Address2 { get; set; } = string.Empty;

		public string Address3 { get; set; } = string.Empty;

		public string Address4 { get; set; } = string.Empty;

		public string SubAddress1 { get; set; } = string.Empty;

		public string SubAddress2 { get; set; } = string.Empty;

		public string SubAddress3 { get; set; } = string.Empty;

		public string SubAddress4 { get; set; } = string.Empty;

		public string BackupAddress { get; set; } = string.Empty;

		public MemberStatusEnum Status { get; set; }

		public bool DelFlg { get; set; }

		public MemberSexEnum Sex { get; set; }

		public DateTime Birthday { get; set; }

		public string Note { get; set; } = string.Empty;

		public DateTime DateCreated { get; set; }

		public DateTime? DateChanged { get; set; }

		public string CreatedBy { get; set; } = string.Empty;

		public string LastChanged { get; set; } = string.Empty;
	}
}
