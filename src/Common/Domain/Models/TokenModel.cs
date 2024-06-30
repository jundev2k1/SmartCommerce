// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Models
{
	public sealed class TokenModel : ModelBase<TokenModel>
	{
		public string BranchId { get; set; } = string.Empty;

		public string TokenId { get; set; } = string.Empty;

		public DateTime ExpirationDate { get; set; }

		public TokenTypeEnum Type { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime? DateChanged { get; set; }

		public string CreatedBy { get; set; } = string.Empty;
	}
}
