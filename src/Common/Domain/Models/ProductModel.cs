// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Models
{
	public sealed class ProductModel : ModelBase<ProductModel>
	{
		public string BranchId { get; set; } = string.Empty;

		public string ProductId { get; set; } = string.Empty;

		public string Name { get; set; } = string.Empty;

		public string Images { get; set; } = string.Empty;

		public string Address1 { get; set; } = string.Empty;

		public string Address2 { get; set; } = string.Empty;

		public string Address3 { get; set; } = string.Empty;

		public string Address4 { get; set; } = string.Empty;

		public decimal Price1 { get; set; }

		public decimal Price2 { get; set; }

		public decimal Price3 { get; set; }

		public DisplayPriceEnum DisplayPrice { get; set; } = DisplayPriceEnum.Price1;

		public ProductStatusEnum Status { get; set; } = ProductStatusEnum.Normal;

		public bool DelFlg { get; set; }

		public decimal Size1 { get; set; }

		public decimal Size2 { get; set; }

		public decimal Size3 { get; set; }

		public string TakeOverId { get; set; } = string.Empty;

		public string ShortDescription { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

		public string EmbeddedLink { get; set; } = string.Empty;

		public string RelatedProductId { get; set; } = string.Empty;

		public string CategoryId1 { get; set; } = string.Empty;

		public string CategoryId2 { get; set; } = string.Empty;

		public string CategoryId3 { get; set; } = string.Empty;

		public string CategoryId4 { get; set; } = string.Empty;

		public string CategoryId5 { get; set; } = string.Empty;

		public string CategoryId6 { get; set; } = string.Empty;

		public string CategoryId7 { get; set; } = string.Empty;

		public string CategoryId8 { get; set; } = string.Empty;

		public string CategoryId9 { get; set; } = string.Empty;

		public string CategoryId10 { get; set; } = string.Empty;

		public DateTime? DateCreated { get; set; }

		public DateTime? DateChanged { get; set; }

		public string CreatedBy { get; set; } = string.Empty;

		public string LastChanged { get; set; } = string.Empty;
	}
}
