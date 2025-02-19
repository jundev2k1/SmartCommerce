// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Common.Utilities
{
	public static class CollectionUtilitiy
	{
		/// <summary>
		/// Join to string
		/// </summary>
		/// <param name="input">A collection of input items</param>
		/// <param name="separateCharacter">Separate character</param>
		/// <returns>A string with distinct characters between items</returns>
		public static string JoinToString<T>(
			this IEnumerable<T> input,
			string separateCharacter)
		{
			return string.Join(separateCharacter, input.Cast<T>());
		}
	}
}
