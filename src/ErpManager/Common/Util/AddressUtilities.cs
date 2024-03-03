// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.ERP.Common.Extensions;

namespace ErpManager.ERP.Common.Util
{
    public static class AddressUtilities
    {
        /// <summary>
        /// Get province name
        /// </summary>
        /// <param name="provinceId">Province id</param>
        /// <param name="culture">Culture</param>
        /// <returns>Province name</returns>
        public static string GetProvinceName(string provinceId, string culture = "en")
        {
            var province = AddressProvider.Instance.Provinces.FirstOrDefault(address => address.ProvinceId == provinceId);
            if (province == null) return string.Empty;

            return culture switch
            {
                "en" => province.EnglishName,
                "vi" => province.VietnameseName,
                _ => string.Empty
            };
        }

        /// <summary>
        /// Get district name
        /// </summary>
        /// <param name="districtId">District id</param>
        /// <param name="culture">Culture</param>
        /// <returns>District name</returns>
        public static string GetDistrictName(string districtId, string culture = "en")
        {
            var district = AddressProvider.Instance.Districts
                .SelectMany(address => address.Items)
                .FirstOrDefault(address => address.DistrictId == districtId);
            if (district == null) return string.Empty;

            return culture switch
            {
                "en" => district.EnglishName,
                "vi" => district.VietnameseName,
                _ => string.Empty
            };
        }

        /// <summary>
        /// Get commune name
        /// </summary>
        /// <param name="communeId">Commune id</param>
        /// <param name="culture">Culture</param>
        /// <returns>Commune name</returns>
        public static string GetCommuneName(string communeId, string culture = "en")
        {
            var commune = AddressProvider.Instance.Communes
                .SelectMany(address => address.Items)
                .SelectMany(item => item.Items)
                .FirstOrDefault(address => address.CommuneId == communeId);
            if (commune == null) return string.Empty;

            return culture switch
            {
                "en" => commune.EnglishName,
                "vi" => commune.VietnameseName,
                _ => string.Empty
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
        public static string GetFullAddress(string provinceId, string districtId, string communeId, string addressContent, string culture = "en")
        {
            var addressParts = new List<string>();

            var provinceName = GetProvinceName(provinceId, culture);
            if (string.IsNullOrEmpty(provinceName) == false) addressParts.Add(provinceName);

            var districtName = GetDistrictName(districtId, culture);
            if (string.IsNullOrEmpty(districtName) == false) addressParts.Add(districtName);

            var cummuneName = GetCommuneName(communeId, culture);
            if (string.IsNullOrEmpty(districtName) == false) addressParts.Add(cummuneName);

            if (string.IsNullOrEmpty(addressContent) == false) addressParts.Add(addressContent);

            return String.Join(", ", addressParts);
        }
    }
}
