// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.Common.Util
{
	public static class ViewUtilities
	{
		public static string GetNextSectionName(List<string> sectionNameCollection, string sectionName = "Section_")
		{
			for (var index = 1; index < 999; index++)
			{
				var newSectionName = $"{sectionName}{index}";
				if (!sectionNameCollection.Contains(newSectionName))
					return newSectionName;
			}

			return string.Empty;
		}

		/// <summary>
		/// Get full request URL
		/// </summary>
		/// <param name="request">Current request</param>
		/// <returns>Full request URL</returns>
		public static string GetFullRequestUrl(HttpRequest request)
		{
			var url = $"{request.Path}{request.QueryString}";
			return url;
		}
	}
}
