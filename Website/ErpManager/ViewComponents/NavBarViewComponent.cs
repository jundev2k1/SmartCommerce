using Common.Constants;
using ErpManager.Web.ViewModels.JSON;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ErpManager.Web.ViewComponents
{
    public class NavBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string currentMenu)
        {
            var sidebarJson = File.ReadAllText(Constants.FILE_PATH_SIDEBAR_SETTING);
            var menu = JsonConvert.DeserializeObject<List<Menu>>(sidebarJson);

            return View(menu);
        }
    }
}
