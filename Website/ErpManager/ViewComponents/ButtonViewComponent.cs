using Domain.Enum;
using ErpManager.Web.ViewModels.Component;
using Microsoft.AspNetCore.Mvc;

namespace ErpManager.Web.ViewComponents
{
    public class ButtonViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ButtonComponent buttonInfo)
        {
            var color = (buttonInfo.Color != ButtonColor.None)
                ? string.Format("site-btn-{0}", Enum.GetName(buttonInfo.Color)?.ToLower())
                : string.Empty;

            if(string.IsNullOrEmpty(color) == false){
                buttonInfo.ClassName += $" {color}";
            }

            if(buttonInfo.IsRounded)
            {
                buttonInfo.ClassName += " rounded";
            }

            return View(buttonInfo);
        }
    }
}
