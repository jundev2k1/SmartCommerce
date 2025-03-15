// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace SmartCommerce.Common.Utilities
{
	public static class BooleanUtilitiy
	{
		public static bool IsNullOrEmpty(this string input)
		{
			return string.IsNullOrEmpty(input);
		}

		public static bool IsNotNullOrEmpty(this string input)
		{
			return string.IsNullOrEmpty(input) == false;
		}

		public static bool HasNullOrEmpty(this string[] inputs)
		{
			return inputs.Any(input => input.IsNullOrEmpty());
		}

		public static bool IsNullOrWhiteSpace(this string input)
		{
			return string.IsNullOrEmpty(input);
		}
	}
}
