// Copyright (c) 2024 - Jun Dev. All rights reserved

using System.Text;

namespace ErpManager.Common
{
    public static class StringUtilitiy
    {
        /// <summary>
        /// Convert object to string or string empty
        /// </summary>
        /// <param name="input">Data input</param>
        /// <returns>A string or string empty</returns>
        public static string ToStringOrEmpty(this object? input)
        {
            return input?.ToString() ?? string.Empty;
        }

        /// <summary>
        /// Remove text sign
        /// </summary>
        /// <param name="inputText">Input text</param>
        /// <returns>Removed sign text</returns>
        public static string? RemoveTextSign(this string inputText)
        {
            if (inputText == null) return string.Empty;

            var result = new StringBuilder();
            foreach (char charText in inputText)
            {
                var textContain = Constants.CONST_DATA_VIETNAMESE_TEXT.FirstOrDefault(vt => vt.Contains(charText));
                result.Append(textContain?[0] ?? charText);
            }

            return result.ToString();
        }
    }
}
