// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Common.Extensions
{
    public sealed class AppConfiguration
    {
        private readonly IConfiguration _configuration;
        public AppConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Initialize()
        {
            AppSettingInititalize();
            SystemInititalize();
            OperatorInititalize();
        } 

        /// <summary>
        /// System Inititalize
        /// </summary>
        private void AppSettingInititalize()
        {
            Constants.CONFIG_APP_DOMAIN = _configuration["ApplicationSetting:AppDomain"].ToStringOrEmpty();
            Constants.CONFIG_APP_PORT = _configuration["ApplicationSetting:AppPort"].ToStringOrEmpty();
            Constants.CONFIG_APP_NAME = _configuration["ApplicationSetting:AppName"].ToStringOrEmpty();
            Constants.CONFIG_APP_LOG_PATH = _configuration["ApplicationSetting:LogPath"].ToStringOrEmpty();
            Constants.CONFIG_APP_LOG_PATH_INFO = Path.Combine(Constants.CONFIG_APP_LOG_PATH, "log-info-.txt");
            Constants.CONFIG_APP_LOG_PATH_WARNING = Path.Combine(Constants.CONFIG_APP_LOG_PATH, "log-warning-.txt");
            Constants.CONFIG_APP_LOG_PATH_ERROR = Path.Combine(Constants.CONFIG_APP_LOG_PATH, "log-error-.txt");
            Constants.CONFIG_APP_LOG_PATH_DEBUG = Path.Combine(Constants.CONFIG_APP_LOG_PATH, "log-debug-.txt");
            Constants.CONFIG_APP_LOG_PATH_VERBOSE = Path.Combine(Constants.CONFIG_APP_LOG_PATH, "log-verbose-.txt");
        }

        /// <summary>
        /// System Inititalize
        /// </summary>
        private void SystemInititalize()
        {
            bool.TryParse(_configuration["SystemSetting:GlobalOption"].ToStringOrEmpty(), out Constants.CONFIG_GLOBAL_OPTION);
            bool.TryParse(_configuration["SystemSetting:DefaultSidebarOption"].ToStringOrEmpty(), out Constants.CONFIG_DEFAULT_SIDEBAR_OPTION);
            Constants.CONFIG_MASTER_BRANCH_ID = _configuration["SystemSetting:MasterBranchId"].ToStringOrEmpty();
            Constants.CONFIG_CURRENCY_IN_USE = _configuration["SystemSetting:CurencyInUse"].ToStringOrEmpty();
            Constants.CONFIG_SMTP_SERVER = _configuration["SystemSetting:SmtpServer"].ToStringOrEmpty();
            int.TryParse(_configuration["SystemSetting:SmtpPort"].ToStringOrEmpty(), out Constants.CONFIG_SMTP_PORT);
            Constants.CONFIG_SMTP_USER = _configuration["SystemSetting:SmtpUser"].ToStringOrEmpty();
            Constants.CONFIG_SMTP_USERNAME = _configuration["SystemSetting:SmtpUserName"].ToStringOrEmpty();
            Constants.CONFIG_SMTP_PASSWORD = _configuration["SystemSetting:SmtpPassword"].ToStringOrEmpty();
        }

        /// <summary>
        /// Operator Inititalize
        /// </summary>
        private void OperatorInititalize()
        {
            Constants.CONFIG_SECRET_KEY = _configuration["OperatorSetting:SecretKey"].ToStringOrEmpty();
            Constants.CONFIG_OWNER_NAME = _configuration["OperatorSetting:OwnerName"].ToStringOrEmpty();
            Constants.CONFIG_OWNER_TEL = _configuration["OperatorSetting:Tel"].ToStringOrEmpty();
            Constants.CONFIG_OWNER_MAIL = _configuration["OperatorSetting:Mail"].ToStringOrEmpty();
            Constants.CONFIG_OWNER_MAIL_CC = _configuration["OperatorSetting:MailCC"].ToStringOrEmpty();
        }
    }
}
