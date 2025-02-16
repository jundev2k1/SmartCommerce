// Copyright (c) 2025 - Jun Dev. All rights reserved

using System.Collections.Specialized;
using System.Web;

namespace SmartCommerce.Common.Helpers
{
	public sealed class UrlCreator
	{
		private readonly Uri _uri;
		private readonly NameValueCollection _parameters;

		/// <summary>
		/// URL creator (Use to create URL with parameters)
		/// </summary>
		/// <param name="pathRoot">String as URL</param>
		public UrlCreator(string pathRoot)
		{
			if (Uri.TryCreate(pathRoot, UriKind.Absolute, out var uri) == false)
			{
				throw new ArgumentException("The path used to create the URL is invalid");
			}

			_uri = uri;
			_parameters = HttpUtility.ParseQueryString(uri.Query);
		}

		/// <summary>
		/// Add parameter
		/// </summary>
		/// <param name="key">Request parameter key</param>
		/// <param name="value">Request parameter value</param>
		/// <returns><see cref="UrlCreator" /> object class</returns>
		public UrlCreator AddParam(string key, string value)
		{
			_parameters[key] = value;
			return this;
		}

		/// <summary>
		/// Create URL
		/// </summary>
		/// <returns>String as URL</returns>
		public string CreateUrl()
		{
			var pathRoot = _uri.GetLeftPart(UriPartial.Path);
			var strParameter = _parameters.AllKeys
				.Select(key => $"{Uri.EscapeDataString(key!)}={Uri.EscapeDataString(_parameters[key]!)}")
				.JoinToString(",");
			return $"{pathRoot}?{strParameter}";
		}
	}
}
