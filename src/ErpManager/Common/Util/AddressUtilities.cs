// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Common.Util
{
    public static class AddressUtilities
    {
        /// <summary>Supported culture</summary>
        private static string[] SupportedCulture = new string[]
        {
            Constants.FLG_GLOBAL_CULTURE_VN,
            Constants.FLG_GLOBAL_CULTURE_ENG
        };

        /// <summary>
        /// Get province name
        /// </summary>
        /// <param name="provinceId">Province id</param>
        /// <param name="culture">Culture</param>
        /// <returns>Province name</returns>
        public static string GetProvinceName(string provinceId, string culture = "")
        {
            culture = SupportedCulture.Contains(culture) ? culture : Constants.CONFIG_LANGUAGE_OPTIONS;

            var province = AddressProvider.Instance.Provinces.FirstOrDefault(address => address.ProvinceId == provinceId);
            if (province == null) return string.Empty;

            return culture switch
            {
                Constants.FLG_GLOBAL_CULTURE_ENG => province.EnglishName,
                Constants.FLG_GLOBAL_CULTURE_VN => province.VietnameseName,
                _ => string.Empty
            };
        }

        /// <summary>
        /// Get district name
        /// </summary>
        /// <param name="districtId">District id</param>
        /// <param name="culture">Culture</param>
        /// <returns>District name</returns>
        public static string GetDistrictName(string districtId, string culture = "")
        {
            culture = SupportedCulture.Contains(culture) ? culture : Constants.CONFIG_LANGUAGE_OPTIONS;

            var district = AddressProvider.Instance.Districts
                .SelectMany(address => address.Items)
                .FirstOrDefault(address => address.DistrictId == districtId);
            if (district == null) return string.Empty;

            return culture switch
            {
                Constants.FLG_GLOBAL_CULTURE_ENG => district.EnglishName,
                Constants.FLG_GLOBAL_CULTURE_VN => district.VietnameseName,
                _ => string.Empty
            };
        }

        /// <summary>
        /// Get commune name
        /// </summary>
        /// <param name="communeId">Commune id</param>
        /// <param name="culture">Culture</param>
        /// <returns>Commune name</returns>
        public static string GetCommuneName(string communeId, string culture = "")
        {
            culture = SupportedCulture.Contains(culture) ? culture : Constants.CONFIG_LANGUAGE_OPTIONS;

            var commune = AddressProvider.Instance.Communes
                .SelectMany(address => address.Items)
                .SelectMany(item => item.Items)
                .FirstOrDefault(address => address.CommuneId == communeId);
            if (commune == null) return string.Empty;

            return culture switch
            {
                Constants.FLG_GLOBAL_CULTURE_ENG => commune.EnglishName,
                Constants.FLG_GLOBAL_CULTURE_VN => commune.VietnameseName,
                _ => string.Empty
            };
        }

        /// <summary>
        /// Get address extend
        /// </summary>
        /// <param name="address">Address</param>
        /// <param name="culture">Culture</param>
        /// <returns>Address</returns>
        public static string GetAddressExtend(string address, string culture = "")
        {
            culture = SupportedCulture.Contains(culture) ? culture : Constants.CONFIG_LANGUAGE_OPTIONS;
            return culture switch
            {
                Constants.FLG_GLOBAL_CULTURE_VN => culture,
                _ => culture.RemoveTextSign(),
            };
        }

        /// <summary>
        /// Get full address
        /// </summary>
        /// <param name="provinceId">Province id</param>
        /// <param name="districtId">District id</param>
        /// <param name="communeId">Commune Id</param>
        /// <param name="addressContent">Address content</param>
        /// <param name="culture">Culture code</param>
        /// <returns>Full address</returns>
        public static string GetFullAddress(string provinceId, string districtId, string communeId, string addressContent, string culture = "")
        {
            var addressParts = new List<string>();

            var provinceName = GetProvinceName(provinceId, culture);
            if (string.IsNullOrEmpty(provinceName) == false) addressParts.Add(provinceName);

            var districtName = GetDistrictName(districtId, culture);
            if (string.IsNullOrEmpty(districtName) == false) addressParts.Add(districtName);

            var cummuneName = GetCommuneName(communeId, culture);
            if (string.IsNullOrEmpty(districtName) == false) addressParts.Add(cummuneName);

            if (string.IsNullOrEmpty(addressContent) == false) addressParts.Add(addressContent.RemoveTextSign());

            return String.Join(", ", addressParts);
        }
    }
}
