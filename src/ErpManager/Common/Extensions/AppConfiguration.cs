// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Common.Extensions
{
    public class AppConfiguration
    {
        private readonly IConfiguration _configuration;
        public AppConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>Config: Owner name</summary>
        public string OwnerName
        {
            get { return _configuration["OwnerName"].ToStringOrEmpty(); }
        }
        /// <summary>Config: Owner phone number</summary>
        public string PhoneNumber
        {
            get { return _configuration["PhoneNumber"].ToStringOrEmpty(); }
        }
        /// <summary>Config: secret key</summary>
        public string SecretKey
        {
            get { return _configuration["SecretKey"].ToStringOrEmpty(); }
        }
    }
}
