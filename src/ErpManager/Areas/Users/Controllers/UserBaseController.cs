// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Areas.Users.Controllers
{
    public class UserBaseController : BaseController
    {
        protected readonly ValueTextManager _valueTextManager;

        public UserBaseController(
            IServiceFacade serviceFacade,
            SessionManager sessionManager,
            ILocalizer localizer,
            IFileLogger logger,
            ValueTextManager valueTextManager) : base(serviceFacade, sessionManager, localizer, logger)
        {
            _valueTextManager = valueTextManager;
        }
    }
}
