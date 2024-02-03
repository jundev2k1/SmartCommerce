namespace Common.Constants
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

        /// <summary>Config: Global options</summary>
        public const bool CONFIG_GLOBAL_OPTIONS = true;
        /// <summary>Default sidebar options</summary>
        public const bool CONFIG_DEFAULT_SIDEBAR_OPTIONS = false;

        /// <summary>Authentication expires cookies (days)</summary>
        public const int AUTH_EXPIRES_COOKIE = 30;
        /// <summary>Authentication expires session (minutes)</summary>
        public const int AUTH_EXPIRES_SESSION = 30;
        /// <summary>Authentication login count expires (minutes)</summary>
        public const int AUTH_LOGIN_COUNT_EXPIRES = 5;
        /// <summary>Authentication limit login count</summary>
        public const int AUTH_LOGIN_COUNT_LIMIT = 3;
    }
}
