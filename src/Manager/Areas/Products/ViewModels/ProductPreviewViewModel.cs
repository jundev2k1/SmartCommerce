// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.Areas.Products.ViewModels
{
	public sealed class ProductPreviewViewModel
	{
		/// <summary>Product detail</summary>
		public ProductModel Product { get; set; } = new ProductModel();

		/// <summary>Take over user</summary>
		public UserModel? AgentDetail { get; set; }

		/// <summary>Related product list</summary>
		public ProductModel[] RelatedProducts { get; set; } = Array.Empty<ProductModel>();

		/// <summary>QR Code</summary>
		public string QRCode { get; set; } = string.Empty;

		/// <summary>Can share QR Code</summary>
		public bool CanShareQRCode { get; set; }
	}
}
