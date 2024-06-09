// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.ViewModels
{
    public sealed class AddressCommuneGroupListViewModel
    {
        [JsonProperty("provinceId")]
        public string ProvinceId { get; set; } = string.Empty;
        [JsonProperty("items")]
        public AddressCommuneGroupViewModel[] Items { get; set; } = Array.Empty<AddressCommuneGroupViewModel>();
    }

    public sealed class AddressCommuneGroupViewModel
    {
        [JsonProperty("districtId")]
        public string DistrictId { get; set; } = string.Empty;
        [JsonProperty("items")]
        public AddressCommuneViewModel[] Items { get; set; } = Array.Empty<AddressCommuneViewModel>();
    }

    public sealed class AddressCommuneViewModel
    {
        [JsonProperty("id")]
        public string CommuneId { get; set; } = string.Empty;
        [JsonProperty("name_vi")]
        public string VietnameseName { get; set; } = string.Empty;
        [JsonProperty("name_en")]
        public string EnglishName { get; set; } = string.Empty;
    }
}
