// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Domain.Models
{
	public sealed class OperatorModel : ModelBase<OperatorModel>
	{
		public string BranchId { get; set; } = string.Empty;

		public UserModel Profile { get; set; } = new UserModel();

		public string Permission { get; set; } = string.Empty;
	}
}
