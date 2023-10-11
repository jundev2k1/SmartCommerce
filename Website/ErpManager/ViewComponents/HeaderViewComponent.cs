using Microsoft.AspNetCore.Mvc;

namespace ErpManager.Web.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
