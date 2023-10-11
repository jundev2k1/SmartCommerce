using Newtonsoft.Json;

namespace ErpManager.Web.ViewModels.JSON
{
    public class SubMenu
    {
        [JsonProperty("label")]
        public string Label { get; set; } = string.Empty;

        [JsonProperty("localizer")]
        public string Localizer { get; set; } = string.Empty;

        [JsonProperty("route")]
        public string Route { get; set; } = string.Empty;
    }
}
