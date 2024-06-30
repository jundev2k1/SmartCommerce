// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Common.Utilities
{
	public static class MessageUtilitiy
	{
		/// <summary>
		/// Get message replacer
		/// </summary>
		/// <param name="message">Message</param>
		/// <param name="replacers">Replacers</param>
		/// <returns>A string message</returns>
		public static string GetMessageReplacer(string message, Hashtable? replacers = null)
		{
			var result = message;
			if (replacers == null) return result;

			foreach (DictionaryEntry replacer in replacers)
			{
				var replacerKey = (string)replacer.Key;
				var replacerValue = replacer.Value.ToStringOrEmpty();

				result = result.Replace(replacerKey, replacerValue);
			}
			return result;
		}

		/// <summary>
		/// Get message replacer
		/// </summary>
		/// <param name="message">Message</param>
		/// <param name="replacers">Replacers</param>
		/// <returns>A string message</returns>
		public static string GetMessageReplacer(string message, string[] replacers)
		{
			var result = message;
			if (replacers == null) return result;

			for (var index = 0; index < replacers.Length; index++)
			{
				var replaceKey = $"[{index}]";
				result = result.Replace(replaceKey, replacers[index]);
			}

			return result;
		}

		/// <summary>
		/// Get message validate
		/// </summary>
		/// <param name="message">Message</param>
		/// <returns>Message validate</returns>
		public static (string, string[]) GetMessageValidate(string message = "")
		{
			var messageElements = message.Split(",");
			var messageKey = messageElements[0];
			var messageValue = (messageElements.Length > 1)
				? messageElements.Skip(1).ToArray()
				: Array.Empty<string>();

			return (messageKey, messageValue);
		}
	}
}
