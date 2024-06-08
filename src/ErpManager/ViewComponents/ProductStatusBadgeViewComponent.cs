// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.ViewComponents
{
    public sealed class ProductStatusBadgeViewComponent : ViewComponent
    {
        private readonly ILocalizer _localizer;
        public ProductStatusBadgeViewComponent(ILocalizer localizer)
        {
            _localizer = localizer;
        }

        public IViewComponentResult Invoke(ProductStatusEnum status, bool isPill = true)
        {
            var className = status switch
            {
                ProductStatusEnum.Sold => "text-bg-secondary",
                ProductStatusEnum.Normal => "text-bg-info",
                ProductStatusEnum.UrgentSale => "text-bg-danger",
                ProductStatusEnum.GoodPrice => "text-bg-warning",
                _ => throw new ArgumentNullException(),
            };
            className += isPill ? " rounded-pill" : "";

            ViewBag.ClassName = className.Trim();
            ViewBag.Content = ProductUtilities.GetStatus(_localizer.Dictionary, status);
            return View();
        }
    }
}
