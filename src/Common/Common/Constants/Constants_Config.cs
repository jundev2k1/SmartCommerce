// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Common
{
    public static partial class Constants
    {
        /// <summary>Application: Domain</summary>
        public const string APPLICATION_PROTOCOL_HTTP = "http://";
        /// <summary>Application: Domain</summary>
        public const string APPLICATION_PROTOCOL_HTTPS = "https://";
        /// <summary>Application: Domain</summary>
        public const string APPLICATION_DOMAIN = "localhost";
        /// <summary>Application: Domain</summary>
        public const string APPLICATION_PORT = "7189";
        /// <summary>Application: Name</summary>
        public const string APPLICATION_NAME = "ERP Manager";

        /// <summary>Config: global options</summary>
        public const bool CONFIG_GLOBAL_OPTIONS = true;
        /// <summary>Config: default sidebar options</summary>
        public const bool CONFIG_DEFAULT_SIDEBAR_OPTIONS = false;
        /// <summary>Config: secret key</summary>
        public const string CONFIG_SECRET_KEY = "240695";
        /// <summary>Config: charset options</summary>
        public const string CONFIG_CHARSET_OPTIONS = "utf-8";
        /// <summary>Config: default branch id</summary>
        public const string CONFIG_DEFAULT_BRANCH_ID = "0";
        /// <summary>Config: default language options</summary>
        public const string CONFIG_DEFAULT_LANGUAGE_OPTIONS = "en";
        /// <summary>Config: language options</summary>
        public static string CONFIG_LANGUAGE_OPTIONS = "vi";
        /// <summary>Config: currency unit</summary>
        public static string CONFIG_CURRENCY_IN_USE = "VND";

        /// <summary>Authentication expires cookies (days)</summary>
        public const int AUTH_EXPIRES_COOKIE = 30;
        /// <summary>Authentication expires session (minutes)</summary>
        public const int AUTH_EXPIRES_SESSION = 30;
        /// <summary>Authentication login count expires (minutes)</summary>
        public const int AUTH_LOGIN_COUNT_EXPIRES = 5;
        /// <summary>Authentication limit login count</summary>
        public const int AUTH_LOGIN_COUNT_LIMIT = 3;

        /// <summary>Default page size</summary>
        public const int DEFAULT_PAGE_SIZE = 20;
    }
}
