// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Common
{
	public static partial class Constants
	{
		/// <summary>Vietnamese text</summary>
		public static readonly string[] CONST_DATA_VIETNAMESE_TEXT = new string[]
		{
			"aáàảãạăắằẳẵặâấầẩẫậ",
			"AÁÀẢÃẠĂẮẰẲẴẶÂẤẦẨẪẬ",
			"dđ",
			"DĐ",
			"eéèẻẽẹêếềểễệ",
			"EÉÈẺẼẸÊẾỀỂỄỆ",
			"iíìỉĩị",
			"IÍÌỈĨỊ",
			"oóòỏõọôốồổỗộơớờởỡợ",
			"OÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢ",
			"uúùủũụưứừửữự",
			"UÚÙỦŨỤƯỨỪỬỮỰ",
			"yýỳỷỹỵ",
			"YÝỲỶỸỴ",
		};

		/// <summary>Characters that can appear in the OTP code</summary>
		public static readonly string CONST_DATA_OTP_RANDOM_CHARACTER = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

		/// <summary>Valid file extension name for image upload</summary>
		public static readonly string[] CONST_DATA_VALID_IMAGE_EXTENSIONS = new string[] { "jpg", "jpeg", "png" };

		/// <summary>Supported culture</summary>
		public static readonly string[] SupportedCulture = new string[]
		{
			Constants.FLG_GLOBAL_CULTURE_VN,
			Constants.FLG_GLOBAL_CULTURE_ENG
		};

		public static readonly string DATE_FORMAT_SHORT_DATE_TIME = "yyyy-MM-dd HH:mm:ss";
	}
}
