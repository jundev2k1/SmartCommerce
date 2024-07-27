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
		public static string CONFIG_MASTER_OPERATOR_ID = string.Empty;
		public static string CONFIG_MASTER_OPERATOR_USERNAME = string.Empty;
		public static string CONFIG_MASTER_OPERATOR_PASSWORD = string.Empty;
		public static string CONFIG_CURRENCY_IN_USE = string.Empty;
		public static string CONFIG_SMTP_SERVER = string.Empty;
		public static int CONFIG_SMTP_PORT = 0;
		public static string CONFIG_SMTP_USER = string.Empty;
		public static string CONFIG_SMTP_USERNAME = string.Empty;
		public static string CONFIG_SMTP_PASSWORD = string.Empty;
		public static string CONFIG_IMAP_SERVER = string.Empty;
		public static int CONFIG_IMAP_PORT = 0;
		public static string CONFIG_IMAP_USER = string.Empty;
		public static string CONFIG_IMAP_PASSWORD = string.Empty;
		public static string CONFIG_SYSTEM_MAIL_HEADER = string.Empty;

		// AppConfig: Operator setting
		public static string CONFIG_SECRET_KEY = string.Empty;
		public static string CONFIG_OWNER_NAME = string.Empty;
		public static string CONFIG_OWNER_TEL = string.Empty;
		public static string CONFIG_OWNER_MAIL = string.Empty;
		public static string CONFIG_OWNER_MAIL_CC = string.Empty;
		public static string CONFIG_OWNER_MAIL_BCC = string.Empty;

		// AppConfig: Site information setting
		public static string CONFIG_SITE_DESCRIPTION = string.Empty;
		public static string CONFIG_SITE_KEYWORDS = string.Empty;
		public static string CONFIG_SITE_VIEWPORT = string.Empty;
		public static string CONFIG_SITE_OPENGRAPH_TITLE = string.Empty;
		public static string CONFIG_SITE_OPENGRAPH_DESCRIPTION = string.Empty;
		public static string CONFIG_SITE_OPENGRAPH_IMAGE = string.Empty;
		public static string CONFIG_SITE_OPENGRAPH_URL = string.Empty;
		public static string CONFIG_SITE_OPENGRAPH_TYPE = string.Empty;
		public static string CONFIG_SITE_TWITTER_CARD = string.Empty;
		public static string CONFIG_SITE_TWITTER_TITLE = string.Empty;
		public static string CONFIG_SITE_TWITTER_DESCRIPTION = string.Empty;
		public static string CONFIG_SITE_TWITTER_IMAGE = string.Empty;
		public static string CONFIG_SITE_CANONICAL = string.Empty;

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

		/// <summary>Page default</summary>
		public const string PAGE_DEFAULT = "/";
		/// <summary>Default page size</summary>
		public const int DEFAULT_PAGE_SIZE = 20;
		/// <summary>Default flag is OFF</summary>
		public const string DEFAULT_FLG_OFF = "0";
		/// <summary>Default flag is ON</summary>
		public const string DEFAULT_FLG_ON = "1";

		/// <summary>Created by default flag: System</summary>
		public const string DEFAULT_FLG_CREATED_BY_SYSTEM = "System";
	}
}
