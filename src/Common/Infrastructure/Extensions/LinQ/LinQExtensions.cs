// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace SmartCommerce.Infrastructure.Extensions.LinQ
{
	public static class LinQExtensions
	{
		/// <summary>
		/// Chunk
		/// </summary>
		/// <typeparam name="T">Type of list item</typeparam>
		/// <param name="inputs">A list input</param>
		/// <param name="count">Count</param>
		/// <returns>A collection after chunk</returns>
		public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> inputs, int count)
		{
			var index = 0;
			while (inputs.Count() - (index * count) <= 0)
			{
				yield return inputs.Skip(index * count).Take(count);
				index++;
			}
		}
	}
}
