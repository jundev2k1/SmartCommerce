namespace ErpManager.ERP.Common.Util
{
    public static class ProductUtilities
    {
        /// <summary>
        /// Get product status
        /// </summary>
        /// <param name="localizer">Localizer</param>
        /// <param name="enum">Enum value</param>
        /// <returns>Product status</returns>
        /// <exception cref="NotImplementedException">Throw if not exist</exception>
        public static string GetProductStatus(Dictionary<string, string> localizer, ProductStatusEnum @enum)
        {
            return @enum switch
            {
                ProductStatusEnum.Sold => localizer["ValTxt_ProductStatus_Sold"].ToStringOrEmpty(),
                ProductStatusEnum.Normal => localizer["ValTxt_ProductStatus_Normal"].ToStringOrEmpty(),
                ProductStatusEnum.UrgentSale => localizer["ValTxt_ProductStatus_UrgentSale"].ToStringOrEmpty(),
                ProductStatusEnum.GoodPrice => localizer["ValTxt_ProductStatus_GoodPrice"].ToStringOrEmpty(),
                _ => throw new NotImplementedException()
            };
        }

        /// <summary>
        /// Get product dislay price content
        /// </summary>
        /// <param name="localizer">Localizer</param>
        /// <param name="enum">Enum value</param>
        /// <returns>Product display price</returns>
        /// <exception cref="NotImplementedException">Throw if not exist</exception>
        public static string GetProductDislayPriceContent(Dictionary<string, string> localizer, DisplayPriceEnum @enum)
        {
            return @enum switch
            {
                DisplayPriceEnum.Price1 => localizer["ValTxt_ProductDisplayPrice1"].ToStringOrEmpty(),
                DisplayPriceEnum.Price2 => localizer["ValTxt_ProductDisplayPrice2"].ToStringOrEmpty(),
                DisplayPriceEnum.Price3 => localizer["ValTxt_ProductDisplayPrice3"].ToStringOrEmpty(),
                _ => throw new NotImplementedException()
            };
        }
    }
}
