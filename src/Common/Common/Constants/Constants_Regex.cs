// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Common
{
    public static partial class Constants
    {
        /// <summary>Regex: Just string and number</summary>
        public const string REGEX_JUST_STRING_AND_NUMBER = "^[^\\W_]+$";
        /// <summary>Regex: Valid phone number</summary>
        public const string REGEX_VALID_PHONE_NUMBER = "^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$";
    }
}
