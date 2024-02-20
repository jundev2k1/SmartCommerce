// Copyright (c) 2024 - Jun Dev. All rights reserved

using System.Text.RegularExpressions;

namespace ErpManager.ERP.Common.Validators
{
    public class ValidatorBase<T> : AbstractValidator<T>
    {
        /// <summary>
        /// Must be valid images
        /// </summary>
        /// <returns>Is valid value</returns>
        protected bool MustBeValidImages(string value)
        {
            return string.IsNullOrEmpty(value) || Regex.IsMatch(value, "^(image1|[^,]+)$");
        }
    }
}
