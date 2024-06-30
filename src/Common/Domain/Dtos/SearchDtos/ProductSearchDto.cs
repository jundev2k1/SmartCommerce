// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Dtos.SearchDtos
{
	public sealed class ProductSearchDto : SearchDtoBase<ProductSearchDto>
	{
		public string Keywords { get; set; } = string.Empty;

		public string BranchId { get; set; } = string.Empty;

		public string ProductId { get; set; } = string.Empty;

		public string ProductName { get; set; } = string.Empty;

		public string Address1 { get; set; } = string.Empty;

		public string Address2 { get; set; } = string.Empty;

		public string Address3 { get; set; } = string.Empty;

		public string Address4 { get; set; } = string.Empty;

		public DisplayPriceEnum? DisplayPrice { get; set; }

		public decimal? MinPrice1 { get; set; }

		public decimal? MaxPrice1 { get; set; }

		public decimal? MinPrice2 { get; set; }

		public decimal? MaxPrice2 { get; set; }

		public decimal? MinPrice3 { get; set; }

		public decimal? MaxPrice3 { get; set; }

		public decimal? MinSize1 { get; set; }

		public decimal? MaxSize1 { get; set; }

		public decimal? MinSize2 { get; set; }

		public decimal? MaxSize2 { get; set; }

		public decimal? MinSize3 { get; set; }

		public decimal? MaxSize3 { get; set; }

		public string TakeOverId { get; set; } = string.Empty;

		public DateTime? DateCreatedFrom { get; set; }

		public DateTime? DateCreatedTo { get; set; }

		public DateTime? DateChangedFrom { get; set; }

		public DateTime? DateChangedTo { get; set; }

		public string CreatedBy { get; set; } = string.Empty;

		public ProductStatusEnum? Status { get; set; }

		public bool DelFlg { get; set; } = false;
	}
}
