// Copyright (c) 2024 - Jun Dev. All rights reserved

using System.Text;

namespace Common.Utilities
{
    public static class StringUtilitiy
    {
        /// <summary>Vietnamese text </summary>
        private static readonly string[] _vietnameseText = new string[]
        {
            "aáàảãạăắằẳẵặâấầẩẫậ",
            "AÁÀẢÃẠĂẮẰẲẴẶÂẤẦẨẪẬ",
            "dđ",
            "DĐ",
            "eéèẻẽẹêếềểễệ",
            "EÉÈẺẼẸÊẾỀỂỄỆ",
            "iíìỉĩị",
            "IÍÌỈĨỊ",
            "oóòỏõọôốồổỗộơớờởỡợ",
            "OÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢ",
            "uúùủũụưứừửữự",
            "UÚÙỦŨỤƯỨỪỬỮỰ",
            "yýỳỷỹỵ",
            "YÝỲỶỸỴ",
        };

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
                var textContain = _vietnameseText.FirstOrDefault(vt => vt.Contains(charText));
                result.Append(textContain?[0] ?? charText);
            }

            return result.ToString();
        }
    }
}
