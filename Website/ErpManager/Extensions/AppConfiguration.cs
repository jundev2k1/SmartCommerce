using Common.Utilities;

namespace ErpManager.Web
{
    public class AppConfiguration
    {
        public IConfiguration Configuration { get; }
        public AppConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>Config: Owner name</summary>
        public string OwnerName
        {
            get { return Configuration["OwnerName"].ToStringOrEmpty(); }
        }
        /// <summary>Config: Owner phone number</summary>
        public string PhoneNumber
        {
            get { return Configuration["PhoneNumber"].ToStringOrEmpty(); }
        }
        /// <summary>Config: secret key</summary>
        public string SecretKey
        {
            get { return Configuration["SecretKey"].ToStringOrEmpty(); }
        }
    }
}
