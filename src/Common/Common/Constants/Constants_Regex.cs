// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Common
{
	public static partial class Constants
	{
		/// <summary>Regex for validate: Just string and number</summary>
		public const string REGEX_JUST_STRING_AND_NUMBER = "^[^\\W_]+$";
		/// <summary>Regex for validate: Valid phone number</summary>
		public const string REGEX_VALID_PHONE_NUMBER = "^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$";

		/// <summary>Regex format for check: File name duplicate</summary>
		public const string REGEX_FOR_CHECK_FILENAME_DUPLICATE = @"\((\d+)\)";

		/// <summary>Regex format for get: Route item</summary>
		public const string REGEX_FOR_GET_ROUTE_ITEM = @"\{[^{}]*\}$";

		public const string REGEX_BREAKLINE_FORMAT = @"\r\n|\r|\n";
	}
}
