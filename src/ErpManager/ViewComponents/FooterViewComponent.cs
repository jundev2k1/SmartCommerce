using Microsoft.AspNetCore.Mvc;

namespace ErpManager.Web.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
