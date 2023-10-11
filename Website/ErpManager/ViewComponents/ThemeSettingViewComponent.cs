using Microsoft.AspNetCore.Mvc;

namespace ErpManager.Web.ViewComponents
{
    public class ThemeSettingViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
