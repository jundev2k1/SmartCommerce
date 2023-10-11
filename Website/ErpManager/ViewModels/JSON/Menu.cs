using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ErpManager.Web.ViewModels.JSON
{
    public class Menu
    {
        [JsonProperty]
        public int Priority { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; } = string.Empty;
        
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("localizer")]
        public string Localizer { get; set; } = string.Empty;

        [JsonProperty("icon")]
        public string Icon { get; set; } = string.Empty;

        [JsonProperty("areas")]
        public string Areas { get; set; } = string.Empty;

        [JsonProperty("controller")]
        public string controller { get; set; } = string.Empty;

        [JsonProperty("items")]
        public List<SubMenu> Items { get; set; } = new List<SubMenu>();
    }
}
