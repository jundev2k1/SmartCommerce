// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Common.ValueText
{
    public sealed class ValueTextModel
    {
        [JsonProperty("product")]
        public Dictionary<string, ValueTextItemModel[]> Product { get; set; } = new Dictionary<string, ValueTextItemModel[]>();

        [JsonProperty("member")]
        public Dictionary<string, ValueTextItemModel[]> Member { get; set; } = new Dictionary<string, ValueTextItemModel[]>();

        [JsonProperty("user")]
        public Dictionary<string, ValueTextItemModel[]> User { get; set; } = new Dictionary<string, ValueTextItemModel[]>();

        [JsonProperty("common")]
        public Dictionary<string, ValueTextItemModel[]> Common { get; set; } = new Dictionary<string, ValueTextItemModel[]>();
    }

    public sealed class ValueTextItemModel
    {
        [JsonProperty("text")]
        public string Text { get; set; } = string.Empty;

        [JsonProperty("localizer")]
        public string LocalizerKey { get; set; } = string.Empty;

        [JsonProperty("value")]
        public string Value { get; set; } = string.Empty;
    }

}
