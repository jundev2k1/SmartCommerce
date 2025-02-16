// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Common.Utilities
{
	public static class MathUtilitiy
	{
		/// <summary>
		/// Div round up
		/// </summary>
		/// <param name="params">Parameters</param>
		/// <returns>The value has been rounded up</returns>
		public static int DivRoundUp(params int[] @params)
		{
			if (@params.Any() == false) return 0;

			var currentValue = Convert.ToDecimal(@params[0]);
			for (var index = 1; index < @params.Length; index++)
			{
				currentValue = currentValue / Convert.ToDecimal(@params[index]);
			}

			var result = Convert.ToInt32(Math.Round(currentValue));
			return result;
		}

		/// <summary>
		/// Div round down
		/// </summary>
		/// <param name="params">Parameters</param>
		/// <returns>The value has been rounded down</returns>
		public static int DivRoundDown(params int[] @params)
		{
			if (@params.Any() == false) return 0;

			var currentValue = Convert.ToDecimal(@params[0]);
			for (var index = 1; index <= @params.Length; index++)
			{
				currentValue = currentValue / Convert.ToDecimal(@params[index]);
			}

			var result = Convert.ToInt32(Math.Floor(currentValue));
			return result;
		}
	}
}
