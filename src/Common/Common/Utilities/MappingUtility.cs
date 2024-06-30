// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Common.Utilities
{
	public static class MappingUtility
	{
		/// <summary>
		/// Mapping model to dictionary
		/// </summary>
		/// <typeparam name="T">Model input type</typeparam>
		/// <param name="model">Model input</param>
		/// <returns>A dictionary</returns>
		public static Dictionary<string, string> MapToDictionary<T>(this T model)
		{
			var result = new Dictionary<string, string>();
			if (model == null) return result;

			var props = model.GetType().GetProperties();
			foreach (var prop in props)
			{
				var key = prop.Name;
				var value = prop.GetValue(model).ToStringOrEmpty();
				result.Add(key, value);
			}

			return result;
		}

		/// <summary>
		/// Mapping model to hashtable
		/// </summary>
		/// <typeparam name="T">Model input type</typeparam>
		/// <param name="model">Model input</param>
		/// <returns>A hashtable</returns>
		public static Hashtable MapToHashtable<T>(this T model)
		{
			var result = new Hashtable();
			if (model == null) return result;

			var props = model.GetType().GetProperties();
			foreach (var prop in props)
			{
				var key = prop.Name;
				var value = prop.GetValue(model).ToStringOrEmpty();
				result.Add(key, value);
			}

			return result;
		}
	}
}
