// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Common.Utilities
{
	public static class QRCodeUtility
	{
		/// <summary>
		/// Generate QR Code
		/// </summary>
		/// <param name="text">Text</param>
		/// <returns>QR code</returns>
		public static string GenerateQRCode(string text)
		{
			using (var qrGenerator = new QRCodeGenerator())
			{
				var qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
				var qrCode = new PngByteQRCode(qrCodeData);
				var qrCodeImage = qrCode.GetGraphic(20);
				var base64Image = Convert.ToBase64String(qrCodeImage);
				return base64Image;
			}
		}

		/// <summary>
		/// Get Src Image QR Code
		/// </summary>
		/// <param name="text">Input text</param>
		/// <returns>Html src image</returns>
		public static string GetSrcImageQRCode(string text)
		{
			var qrCodeBase64 = QRCodeUtility.GenerateQRCode(text);
			var result = $"data:image/png;base64,{qrCodeBase64}";
			return result;
		}
	}
}
