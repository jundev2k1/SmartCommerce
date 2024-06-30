// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Common.Util
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
	}
}
