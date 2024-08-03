// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Manager.Common.Extensions
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
			PageInfoInititalize();
		}

		/// <summary>
		/// System Inititalize
		/// </summary>
		private void AppSettingInititalize()
		{
			Constants.CONFIG_APP_BASE_PATH = _configuration["ApplicationSetting:BasePath"].ToStringOrEmpty();
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
			Constants.CONFIG_SECRET_KEY = _configuration["SystemSetting:SecretKey"].ToStringOrEmpty();
			bool.TryParse(_configuration["SystemSetting:GlobalOption"].ToStringOrEmpty(), out Constants.CONFIG_GLOBAL_OPTION);
			bool.TryParse(_configuration["SystemSetting:DefaultSidebarOption"].ToStringOrEmpty(), out Constants.CONFIG_DEFAULT_SIDEBAR_OPTION);
			Constants.CONFIG_CURRENCY_IN_USE = _configuration["SystemSetting:CurencyInUse"].ToStringOrEmpty();
			Constants.CONFIG_SMTP_SERVER = _configuration["SystemSetting:SmtpServer"].ToStringOrEmpty();
			int.TryParse(_configuration["SystemSetting:SmtpPort"].ToStringOrEmpty(), out Constants.CONFIG_SMTP_PORT);
			Constants.CONFIG_SMTP_USER = _configuration["SystemSetting:SmtpUser"].ToStringOrEmpty();
			Constants.CONFIG_SMTP_USERNAME = _configuration["SystemSetting:SmtpUserName"].ToStringOrEmpty();
			Constants.CONFIG_SMTP_PASSWORD = _configuration["SystemSetting:SmtpPassword"].ToStringOrEmpty();
			Constants.CONFIG_IMAP_SERVER = _configuration["SystemSetting:ImapServer"].ToStringOrEmpty();
			int.TryParse(_configuration["SystemSetting:ImapPort"].ToStringOrEmpty(), out Constants.CONFIG_IMAP_PORT);
			Constants.CONFIG_IMAP_USER = _configuration["SystemSetting:ImapUser"].ToStringOrEmpty();
			Constants.CONFIG_IMAP_PASSWORD = _configuration["SystemSetting:ImapPassword"].ToStringOrEmpty();
			Constants.CONFIG_SYSTEM_MAIL_HEADER = _configuration["SystemSetting:SystemMailHeader"].ToStringOrEmpty();
		}

		/// <summary>
		/// Operator Inititalize
		/// </summary>
		private void OperatorInititalize()
		{
			Constants.CONFIG_OWNER_NAME = _configuration["OperatorSetting:OwnerName"].ToStringOrEmpty();
			Constants.CONFIG_OWNER_TEL = _configuration["OperatorSetting:Tel"].ToStringOrEmpty();
			Constants.CONFIG_OWNER_MAIL = _configuration["OperatorSetting:Mail"].ToStringOrEmpty();
			Constants.CONFIG_MASTER_BRANCH_ID = _configuration["OperatorSetting:BranchId"].ToStringOrEmpty();
			Constants.CONFIG_MASTER_OPERATOR_ID = _configuration["OperatorSetting:UserId"].ToStringOrEmpty();
			Constants.CONFIG_MASTER_OPERATOR_USERNAME = _configuration["OperatorSetting:UserName"].ToStringOrEmpty();
			Constants.CONFIG_MASTER_OPERATOR_PASSWORD = _configuration["OperatorSetting:Password"].ToStringOrEmpty();
		}

		/// <summary>
		/// Page Information Inititalize
		/// </summary>
		private void PageInfoInititalize()
		{
			Constants.CONFIG_SITE_DESCRIPTION = _configuration["SiteInfo:SiteDescription"].ToStringOrEmpty();
			Constants.CONFIG_SITE_KEYWORDS = _configuration["SiteInfo:SiteKeywords"].ToStringOrEmpty();
			Constants.CONFIG_SITE_VIEWPORT = _configuration["SiteInfo:SiteViewport"].ToStringOrEmpty();
			Constants.CONFIG_SITE_OPENGRAPH_TITLE = _configuration["SiteInfo:SiteOpenGraphTitle"].ToStringOrEmpty();
			Constants.CONFIG_SITE_OPENGRAPH_DESCRIPTION = _configuration["SiteInfo:SiteOpenGraphDescription"].ToStringOrEmpty();
			Constants.CONFIG_SITE_OPENGRAPH_IMAGE = _configuration["SiteInfo:SiteOpenGraphImage"].ToStringOrEmpty();
			Constants.CONFIG_SITE_OPENGRAPH_URL = _configuration["SiteInfo:SiteOpenGraphUrl"].ToStringOrEmpty();
			Constants.CONFIG_SITE_OPENGRAPH_TYPE = _configuration["SiteInfo:SiteOpenGraphType"].ToStringOrEmpty();
			Constants.CONFIG_SITE_TWITTER_CARD = _configuration["SiteInfo:SiteTwitterCard"].ToStringOrEmpty();
			Constants.CONFIG_SITE_TWITTER_TITLE = _configuration["SiteInfo:SiteTwitterTitle"].ToStringOrEmpty();
			Constants.CONFIG_SITE_TWITTER_DESCRIPTION = _configuration["SiteInfo:SiteTwitterDescription"].ToStringOrEmpty();
			Constants.CONFIG_SITE_TWITTER_IMAGE = _configuration["SiteInfo:SiteTwitterImage"].ToStringOrEmpty();
			Constants.CONFIG_SITE_CANONICAL = _configuration["SiteInfo:SiteCanonical"].ToStringOrEmpty();
		}
	}
}
