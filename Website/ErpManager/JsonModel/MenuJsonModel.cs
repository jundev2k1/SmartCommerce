using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ErpManager.Web.JsonModel
{
    public class MenuJsonModel
    {
        [JsonProperty]
        public int Priority { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("permission")]
        public string Permission { get; set; } = string.Empty;

        [JsonProperty("localizer")]
        public string Localizer { get; set; } = string.Empty;

        [JsonProperty("icon")]
        public string Icon { get; set; } = string.Empty;

        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;

        [JsonProperty("items")]
        public List<SubMenuJsonModel> Items { get; set; } = new List<SubMenuJsonModel>();
    }

    public class SubMenuJsonModel
    {
        [JsonProperty("label")]
        public string Label { get; set; } = string.Empty;

        [JsonProperty("localizer")]
        public string Localizer { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("permission")]
        public string Permission { get; set; } = string.Empty;

        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;
    }
}
