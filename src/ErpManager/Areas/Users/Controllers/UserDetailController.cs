// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Areas.Users.Controllers
{
    [Area(Constants.MODULE_USER_AREA)]
    public sealed class UserDetailController : UserBaseController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UserDetailController(
            IServiceFacade serviceFacade,
            IValidatorFacade validatorFacade,
            ILocalizer localizer,
            SessionManager sessionManager,
            ValueTextManager valueTextManager,
            IFileLogger logger) : base(serviceFacade, sessionManager, localizer, logger, valueTextManager)
        {
        }

        [HttpGet]
        [PermissionAttribute(Permission.CanReadListUser)]
        [Route($"{Constants.MODULE_USER_USERDETAIL_PATH}/{{id}}", Name = Constants.MODULE_USER_USERDETAIL_NAME)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
