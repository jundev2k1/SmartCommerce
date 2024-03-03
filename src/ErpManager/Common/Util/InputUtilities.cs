using LinqKit;

namespace ErpManager.ERP.Common.Util
{
    public static class InputUtilities
    {
        /// <summary>
        /// Trim string input
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="input"></param>
        /// <returns>Model trimmed value</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TModel TrimStringInput<TModel>(this TModel input) where TModel : class
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            input.GetType().GetProperties()?.ForEach(property =>
            {
                if (property.PropertyType == typeof(string))
                {
                    var value = property.GetValue(input).ToStringOrEmpty().Trim();
                    property.SetValue(input, value);
                }
            });

            return input;
        }
    }
}
