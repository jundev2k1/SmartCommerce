// Copyright (c) 2024 - Jun Dev. All rights reserved

using Microsoft.AspNetCore.Mvc;

namespace ErpManager.ERP.ViewComponents
{
    public class BackToTopViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
