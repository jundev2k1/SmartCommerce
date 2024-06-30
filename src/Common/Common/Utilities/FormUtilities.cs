// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Common.Utilities
{
	public static class FormUtilities
	{
		/// <summary>
		/// Trim string input
		/// </summary>
		/// <typeparam name="TModel"></typeparam>
		/// <param name="input"></param>
		/// <returns>Model trimmed value</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static TModel TrimStringInput<TModel>(this TModel input) where TModel : class
		{
			if (input == null) throw new ArgumentNullException(nameof(input));

			input.GetType().GetProperties().ToList().ForEach(property =>
			{
				if (property.PropertyType == typeof(string))
				{
					var value = property.GetValue(input).ToStringOrEmpty().Trim();
					property.SetValue(input, value);
				}
			});

			return input;
		}
	}
}
