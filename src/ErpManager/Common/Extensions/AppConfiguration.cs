// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Common.Extensions
{
    public class AppConfiguration
    {
        private readonly IConfiguration _configuration;
        public AppConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
            Inititalize();
        }

        /// <summary>
        /// Inititalize
        /// </summary>
        private void Inititalize()
        {
            this.SecretKey = Constants.CONFIG_SECRET_KEY = _configuration["SecretKey"].ToStringOrEmpty();
            this.OwnerName = Constants.CONFIG_OWNER_NAME = _configuration["OwnerName"].ToStringOrEmpty();
            this.Tel = Constants.CONFIG_OWNER_TEL = _configuration["Tel"].ToStringOrEmpty();
            this.Mail = Constants.CONFIG_OWNER_MAIL = _configuration["Mail"].ToStringOrEmpty();
            this.MailCC = Constants.CONFIG_OWNER_MAIL_CC = _configuration["MailCC"].ToStringOrEmpty();
            this.MailBCC = Constants.CONFIG_OWNER_MAIL_BCC = _configuration["MailBCC"].ToStringOrEmpty();
        }

        /// <summary>App Config: secret key</summary>
        public string SecretKey { get; private set; } = string.Empty;
        /// <summary>App Config: Owner name</summary>
        public string OwnerName { get; private set; } = string.Empty;
        /// <summary>App Config: Owner phone number</summary>
        public string Tel { get; private set; } = string.Empty;
        /// <summary>App Config: owner mail</summary>
        public string Mail { get; private set; } = string.Empty;
        /// <summary>App Config: mail CC</summary>
        public string MailCC { get; private set; } = string.Empty;
        /// <summary>App Config: mail BCC</summary>
        public string MailBCC { get; private set; } = string.Empty;
    }
}
