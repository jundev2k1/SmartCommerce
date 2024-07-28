using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ErpManager.Manager.Common.Mapping
{
	public static class CommonMapping
	{
		public static Dictionary<string, string> MapToDictionary(this IEnumerable<LocalizedString> localizedList)
		{
			return localizedList
				.Select(item => new KeyValuePair<string, string>(item.Name, item.Value))
				.ToDictionary(kp => kp.Key, kp => kp.Value);
		}
	}
}
