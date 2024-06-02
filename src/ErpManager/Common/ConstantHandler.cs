using ErpManager.ERP.Common.Extensions;

namespace ErpManager.ERP.Common
{
    public static class ConstantHandler
    {
        public static void Initialize(IConfiguration configuration)
        {
            SetConfiguration(configuration);
        }

        /// <summary>
        /// Set configuration
        /// </summary>
        /// <param name="configuration">Configuration</param>
        private static void SetConfiguration(IConfiguration configuration)
        {
            Constants.PHYSICAL_APPLICATION_SITE_PATH = Environment.CurrentDirectory;
        }
    }
}
