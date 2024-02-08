// Copyright (c) 2024 - Jun Dev. All rights reserved

using Microsoft.AspNetCore.Mvc;

namespace ErpManager.ERP.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
