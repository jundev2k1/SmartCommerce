namespace ErpManager.ERP.Areas.Products.ViewModels
{
    public class ProductPreviewViewModel
    {
        /// <summary>Product detail</summary>
        public ProductModel Product { get; set; } = new ProductModel();

        /// <summary>Take over user</summary>
        public UserModel? AgentDetail { get; set; }

        /// <summary>Related product list</summary>
        public ProductModel[] RelatedProducts { get; set; } = Array.Empty<ProductModel>();

        /// <summary>QR Code</summary>
        public string QRCode { get; set; } = string.Empty;
    }
}
