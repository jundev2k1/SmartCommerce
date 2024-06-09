// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Areas.Users.Controllers
{
    [Area(Constants.MODULE_USER_AREA)]
    public sealed class UserDetailController : BaseController
    {
        private readonly IServiceFacade _serviceFacade;
        private readonly IValidatorFacade _validatorFacade;
        private readonly ILocalizer _localizer;
        private readonly SessionManager _sessionManager;

        /// <summary>
        /// Constructor
        /// </summary>
        public UserDetailController(
            IServiceFacade serviceFacade,
            IValidatorFacade validatorFacade,
            ILocalizer localizer,
            SessionManager sessionManager) : base(serviceFacade, sessionManager)
        {
            _serviceFacade = serviceFacade;
            _validatorFacade = validatorFacade;
            _localizer = localizer;
            _sessionManager = sessionManager;
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
