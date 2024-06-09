// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Common
{
    public static partial class Constants
    {
        // Application: Protocol
        public const string CONST_PROTOCOL_HTTP = "http://";
        public const string CONST_PROTOCOL_HTTPS = "https://";

        // Application: Application setting
        public static string CONFIG_APP_DOMAIN = string.Empty;
        public static string CONFIG_APP_PORT = string.Empty;
        public static string CONFIG_APP_NAME = string.Empty;
        public static string CONFIG_APP_LOG_PATH = string.Empty;
        public static string CONFIG_APP_LOG_PATH_INFO = string.Empty;
        public static string CONFIG_APP_LOG_PATH_WARNING = string.Empty;
        public static string CONFIG_APP_LOG_PATH_ERROR = string.Empty;
        public static string CONFIG_APP_LOG_PATH_DEBUG = string.Empty;
        public static string CONFIG_APP_LOG_PATH_VERBOSE = string.Empty;

        // AppConfig: System setting
        public static bool CONFIG_GLOBAL_OPTION = true;
        public static bool CONFIG_DEFAULT_SIDEBAR_OPTION = false;
        public static string CONFIG_MASTER_BRANCH_ID = string.Empty;
        public static string CONFIG_CURRENCY_IN_USE = string.Empty;
        public static string CONFIG_SMTP_SERVER = string.Empty;
        public static int CONFIG_SMTP_PORT = 0;
        public static string CONFIG_SMTP_USER = string.Empty;
        public static string CONFIG_SMTP_USERNAME = string.Empty;
        public static string CONFIG_SMTP_PASSWORD = string.Empty;

        // AppConfig: Operator setting
        public static string CONFIG_SECRET_KEY = string.Empty;
        public static string CONFIG_OWNER_NAME = string.Empty;
        public static string CONFIG_OWNER_TEL = string.Empty;
        public static string CONFIG_OWNER_MAIL = string.Empty;
        public static string CONFIG_OWNER_MAIL_CC = string.Empty;
        public static string CONFIG_OWNER_MAIL_BCC = string.Empty;

        /// <summary>Config: Charset options</summary>
        public static string PAGE_CHARSET_OPTIONS = "utf-8";
        /// <summary>Config: language options</summary>
        public static string PAGE_LANGUAGE_OPTIONS = string.Empty;

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
        /// <summary>Default flag is OFF</summary>
        public const string DEFAULT_FLG_OFF = "0";
        /// <summary>Default flag is ON</summary>
        public const string DEFAULT_FLG_ON = "1";
    }
}
