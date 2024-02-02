using System.Collections;

namespace Common.Utilities
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
    }
}
