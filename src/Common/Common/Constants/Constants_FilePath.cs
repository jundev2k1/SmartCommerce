// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Common
{
    public static partial class Constants
    {
        /// <summary>Physical path root</summary>
        public static string PHYSICAL_ROOT_PATH = string.Empty;
        public static string PHYSICAL_APPLICATION_CONTENT_PATH = Path.Combine(PHYSICAL_ROOT_PATH, "/wwwroot");

        /// <summary>File path: Sidebar setting</summary>
        public static string FILE_PATH_SIDEBAR_SETTING = "/Data/sidebar.json";

        /// <summary>File path: Js component nav bar</summary>
        public const string FILE_PATH_JS_COMPONENT_NAV_BAR = "~/js/component-script/Navbar/index.js";
        /// <summary>File path: Js component search input</summary>
        public const string FILE_PATH_JS_COMPONENT_SEARCH_INPUT = "~/js/component-script/SearchInput/index.js";
    }
}
