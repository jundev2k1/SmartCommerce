// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Domain.Extensions.FilterModels
{
	public sealed class MemberFilterModel : FilterModelBase<MemberFilterModel>
	{
		public string Keywords { get; set; } = string.Empty;

		public string BranchId { get; set; } = string.Empty;

		public string MemberId { get; set; } = string.Empty;

		public string FirstName { get; set; } = string.Empty;

		public string LastName { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;

		public string CardNumber { get; set; } = string.Empty;

		public string PhoneNumber { get; set; } = string.Empty;

		public string Address1 { get; set; } = string.Empty;

		public string Address2 { get; set; } = string.Empty;

		public string Address3 { get; set; } = string.Empty;

		public string Address4 { get; set; } = string.Empty;

		public int MinAge { get; set; }

		public int MaxAge { get; set; }

		public UserStatusEnum Status { get; set; }

		public UserSexEnum? Sex { get; set; }

		public DateTime? BirthdayFrom { get; set; }

		public DateTime? BirthdayTo { get; set; }

		public DateTime? LastLogin { get; set; }

		public int? RoleId { get; set; }
	}
}
