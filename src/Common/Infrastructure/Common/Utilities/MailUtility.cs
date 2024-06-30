// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Infrastructure.Common.Utilities
{
	public static class MailUtility
	{
		/// <summary>
		/// Get tag replace pattern
		/// </summary>
		/// <param name="tagName">Tag name</param>
		/// <returns>Tag name for text replacement</returns>
		public static string GetTagReplacePattern(string tagName)
		{
			var result = string.Format(@"<({0})(\s+[^>]*)*>(.*?)<\/\1>", tagName);
			return result;
		}

		/// <summary>
		/// Replace tag by value
		/// </summary>
		/// <param name="mailTemplate">Mail template</param>
		/// <param name="input">A tuple include key and value of input</param>
		/// <returns>Html content has been replaced</returns>
		public static string ReplaceTag(string mailTemplate, (string, string) input)
		{
			var (key, value) = input;
			var replaceTagPattern = GetTagReplacePattern(key);
			var result = Regex.Replace(mailTemplate, replaceTagPattern, value);
			return result;
		}

		/// <summary>
		/// Handle substitutions to replace paragraph tags
		/// </summary>
		/// <param name="mailTemplate">Mail template</param>
		/// <param name="paragraphContent">Paragraph content</param>
		/// <returns>Html content has been replaced</returns>
		public static string ReplaceParagraphTag(string mailTemplate, string paragraphContent)
		{
			// Get paragraph tag for text replacement
			var document = new HtmlDocument();
			document.LoadHtml(mailTemplate);
			var bodyContents = document.DocumentNode
				.Descendants(Constants.MAILDATA_KEY_MAIL_PARAGRAPH)
				.FirstOrDefault();
			var replacePattern = GetTagReplacePattern(Constants.MAILTAG_MAIL_PARAGRAPH_ITEM);

			// Handle replace for multiple-line input data
			if (bodyContents != null)
			{
				var builder = new StringBuilder();
				var contents = paragraphContent.SplitBreakLine();
				foreach (var content in contents)
				{
					var cloneNode = bodyContents.Clone();
					var htmlReplaced = ReplaceTag(cloneNode.InnerHtml, (Constants.MAILTAG_MAIL_PARAGRAPH_ITEM, content));
					builder.Append(htmlReplaced);
				}
				var innerContent = document.DocumentNode.InnerHtml;
				document.DocumentNode.InnerHtml = innerContent.Replace(
					bodyContents.OuterHtml,
					builder.ToString());
				return document.DocumentNode.OuterHtml;
			}

			// Handle replace for single-line input data
			var htmlContent = document.DocumentNode.OuterHtml;
			var replaceResult = ReplaceTag(htmlContent, (Constants.MAILTAG_MAIL_PARAGRAPH_ITEM, paragraphContent));
			return replaceResult;
		}

		/// <summary>
		/// Handle substitutions to replace loop tags
		/// </summary>
		/// <param name="mailTemplate">Mail template</param>
		/// <param name="inputList">Input collection</param>
		/// <returns>Html content has been replaced</returns>
		public static string ReplaceLoopTag(string mailTemplate, List<Hashtable> inputList)
		{
			// Get loop tag for text replacement
			var document = new HtmlDocument();
			document.LoadHtml(mailTemplate);
			var loopTemplate = document.DocumentNode
				.Descendants(Constants.MAILTAG_MAIL_LOOP)
				.FirstOrDefault();
			if (loopTemplate == null) return mailTemplate;

			// Create loop data list
			var templateBuilder = new StringBuilder();
			for (var index = 0; index < inputList.Count; index++)
			{
				var cloneTemplate = loopTemplate.Clone();
				// Handle replace tag by input value
				foreach (DictionaryEntry inputItem in inputList[index])
				{
					var tagReplace = GetTagReplacePattern(inputItem.Key.ToStringOrEmpty());
					var value = inputItem.Value.ToStringOrEmpty();
					cloneTemplate.InnerHtml = Regex.Replace(cloneTemplate.InnerHtml, tagReplace, value);
				}

				// Handle remove ignore item when index is the last item (included inner content)
				if (index == (inputList.Count - 1))
				{
					var ignorePattern = GetTagReplacePattern(Constants.MAILTAG_MAIL_LOOP_LAST_ITEM_IGNORE);
					cloneTemplate.InnerHtml = Regex.Replace(cloneTemplate.InnerHtml, ignorePattern, string.Empty);
				}
				// Handle remove ignore tag when index is not the last item (just remove tag)
				else
				{
					var beginIgnorePattern = $"<{Constants.MAILTAG_MAIL_LOOP_LAST_ITEM_IGNORE}\\b[^>]*>";
					cloneTemplate.InnerHtml = Regex.Replace(
						cloneTemplate.InnerHtml,
						beginIgnorePattern,
						string.Empty);
					var endIgnorePattern = $"<\\/{Constants.MAILTAG_MAIL_LOOP_LAST_ITEM_IGNORE}>";
					cloneTemplate.InnerHtml = Regex.Replace(
						cloneTemplate.InnerHtml,
						endIgnorePattern,
						string.Empty);
				}

				// Append item each iteration
				templateBuilder.Append(cloneTemplate.InnerHtml);
			}

			// Replace loop tag to loop data list
			var loopPattern = GetTagReplacePattern(Constants.MAILTAG_MAIL_LOOP);
			var result = Regex.Replace(
				document.DocumentNode.OuterHtml,
				loopPattern,
				templateBuilder.ToString());
			return result;
		}

		public static string ReplaceBodyMail(string mailTemplate, Hashtable mailInfo)
		{
			var document = new HtmlDocument();
			document.LoadHtml(mailTemplate);
			foreach (DictionaryEntry mailItem in mailInfo)
			{
				var mailItemKey = mailItem.Key.ToStringOrEmpty();
				var mailItemValue = mailItem.Value;

				// Replace loop content in body mail
				if (mailItemKey == Constants.MAILTAG_MAIL_LOOP)
				{
					if (mailItemValue is List<Hashtable> loopItems)
						document.DocumentNode.InnerHtml = ReplaceLoopTag(
							document.DocumentNode.InnerHtml,
							loopItems);

					continue;
				}

				// Check type value
				if (mailItemValue is string strMailContent == false) continue;

				// Replace paragraph mail information
				if (mailItemKey == Constants.MAILDATA_KEY_MAIL_PARAGRAPH)
				{
					document.DocumentNode.InnerHtml = ReplaceParagraphTag(
						document.DocumentNode.InnerHtml,
						strMailContent);
					continue;
				}

				document.DocumentNode.InnerHtml = ReplaceTag(
					document.DocumentNode.InnerHtml,
					(mailItemKey, strMailContent));
			}

			return document.DocumentNode.OuterHtml;
		}
	}
}
