// Copyright (c) 2024 - Jun Dev. All rights reserved

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
        public static string GetStatus(Dictionary<string, string> localizer, ProductStatusEnum @enum)
        {
            return @enum switch
            {
                ProductStatusEnum.Sold => localizer["ValTxt_Product_Status_Sold"].ToStringOrEmpty(),
                ProductStatusEnum.Normal => localizer["ValTxt_Product_Status_Normal"].ToStringOrEmpty(),
                ProductStatusEnum.UrgentSale => localizer["ValTxt_Product_Status_UrgentSale"].ToStringOrEmpty(),
                ProductStatusEnum.GoodPrice => localizer["ValTxt_Product_Status_GoodPrice"].ToStringOrEmpty(),
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
        public static string GetDislayPriceContent(Dictionary<string, string> localizer, DisplayPriceEnum @enum)
        {
            return @enum switch
            {
                DisplayPriceEnum.Price1 => localizer["ValTxt_Product_DisplayPrice1"].ToStringOrEmpty(),
                DisplayPriceEnum.Price2 => localizer["ValTxt_Product_DisplayPrice2"].ToStringOrEmpty(),
                DisplayPriceEnum.Price3 => localizer["ValTxt_Product_DisplayPrice3"].ToStringOrEmpty(),
                _ => throw new NotImplementedException()
            };
        }

        /// <summary>
        /// Get display price
        /// </summary>
        /// <param name="model">Product model</param>
        /// <returns>Display price</returns>
        public static string GetDisplayPrice(ProductModel model)
        {
            return model.DisplayPrice switch
            {
                DisplayPriceEnum.Price1 => Convert.ToInt32(model.Price1).ToStringOrEmpty(),
                DisplayPriceEnum.Price2 => Convert.ToInt32(model.Price2).ToStringOrEmpty(),
                DisplayPriceEnum.Price3 => Convert.ToInt32(model.Price3).ToStringOrEmpty(),
                _ => throw new NotImplementedException()
            };
        }

        /// <summary>
        /// Get main product image
        /// </summary>
        /// <param name="images">Images</param>
        /// <returns>Main product image</returns>
        public static string GetMainProductImage(string images)
        {
            if (string.IsNullOrEmpty(images)) return Constants.ERP_FILE_PATH_PUBLIC_NO_IMAGE;

            foreach(var image in images.Split(','))
            {
                var imagePath = string.Format("{0}{1}", Constants.PHYSICAL_APPLICATION_ROOT_PATH, image);
                if (File.Exists(imagePath)) return image;
            }

            return Constants.ERP_FILE_PATH_PUBLIC_NO_IMAGE;
        }

        /// <summary>
        /// Get product image
        /// </summary>
        /// <param name="path">Image path</param>
        /// <returns>Product image</returns>
        public static string GetProductImage(string path)
        {
            var imagePath = string.Format("{0}{1}", Constants.PHYSICAL_APPLICATION_ROOT_PATH, path);
            return File.Exists(imagePath) ? path : Constants.ERP_FILE_PATH_PUBLIC_NO_IMAGE;
        }
    }
}
