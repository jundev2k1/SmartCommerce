using ErpManager.Web;
using ErpManager.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;

namespace ErpManager.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IStringLocalizer<GlobalLocalizer> _localizer;

        public AccountController(IStringLocalizer<GlobalLocalizer> localizer)
        {
            _localizer = localizer;
        }

        [Route("/dang-nhap")]
        [Route("/login",Name ="Login")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
