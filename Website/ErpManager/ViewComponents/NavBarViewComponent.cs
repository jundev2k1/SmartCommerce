using Common.Constants;
using Common.Utilities;
using ErpManager.Web.JsonModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ErpManager.Web.ViewComponents
{
    public class NavBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string currentMenu)
        {
            var sidebarJson = File.ReadAllText(Constants.FILE_PATH_SIDEBAR_SETTING);
            var menu = JsonConvert.DeserializeObject<List<MenuJsonModel>>(sidebarJson);

            ViewBag.OperatorPermisson = GetOperatorPermisson();
            return View(menu);
        }

        /// <summary>
        /// Get operator permisson
        /// </summary>
        /// <returns>Permission list</returns>
        private string[] GetOperatorPermisson()
        {
            var result = HttpContext.Session.GetString(Constants.SESSION_KEY_OPERATOR_PERMISSION).ToStringOrEmpty();
            return result.Split(",");
        }

        protected string GetA() => "";
    }
}
