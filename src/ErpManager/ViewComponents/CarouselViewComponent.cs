// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.ViewComponents
{
    public class CarouselViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string images, string idTarget)
        {
            if (string.IsNullOrEmpty(images))
            {
                images = Constants.FILE_PATH_PUBLIC_NO_IMAGE;
            }

            var imageList = images.Split(',');

            return View((imageList, idTarget));
        }
    }
}
