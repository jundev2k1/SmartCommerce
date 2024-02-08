// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Common
{
    public static class EnumUtility
    {
        /// <summary>
        /// Get string value
        /// </summary>
        /// <param name="enum">Enum value</param>
        /// <returns>String value</returns>
        public static string GetStringValue<T>(this Enum @enum)
        {
            if (typeof(T) == typeof(int))
            {
                var result = Convert.ToInt32(@enum);
                return result.ToString();
            }

            return @enum.ToStringOrEmpty();
        }

        /// <summary>
        /// Get enum value
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <param name="key">key</param>
        /// <returns>Enum value</returns>
        public static T GetEnumValue<T>(string key) where T : struct, Enum
        {
            try
            {
                var isSuccess = Enum.TryParse(key, true, out T result);
                if (!isSuccess) throw new Exception();

                return result;
            }
            catch
            {
                throw new ArgumentException($"Unable to parse {key} to {typeof(T).Name}");
            }
        }
    }
}
