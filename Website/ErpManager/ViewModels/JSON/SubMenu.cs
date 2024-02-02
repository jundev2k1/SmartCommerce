using Newtonsoft.Json;

namespace ErpManager.Web.ViewModels.JSON
{
    public class SubMenu
    {
        [JsonProperty("label")]
        public string Label { get; set; } = string.Empty;

        [JsonProperty("localizer")]
        public string Localizer { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;
    }
}
