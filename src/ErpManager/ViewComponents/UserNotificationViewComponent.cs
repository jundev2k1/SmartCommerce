// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.ViewComponents
{
    public sealed class UserNotificationViewComponent : ViewComponent
    {
        private readonly SessionManager _sessionManager;
        private readonly IServiceFacade _serviceFacade;
        public UserNotificationViewComponent(IServiceFacade serviceFacade, SessionManager sessionManager)
        {
            _serviceFacade = serviceFacade;
            _sessionManager = sessionManager;
        }

        public IViewComponentResult Invoke()
        {
            var isLogin = _sessionManager.IsLogin;
            var data = new NotificationViewModel
            {
                IsDisplay = isLogin,
                NotificationUnReadCount = 2,
                Items = new NotificationContent[]
                {
                    new NotificationContent {
                        Title = "Pro1 sắp đến hạn",
                        Content = "Sản phẩm Pro1 còn 4 ngày nữa đến hạn (29/2/2024)",
                        Status = true
                    },
                    new NotificationContent {
                        Title = "Pro2 sắp đến hạn",
                        Content = "Sản phẩm Pro2 còn 2 ngày nữa đến hạn (27/2/2024)",
                        Status = true
                    },
                    new NotificationContent {
                        Title = "Pro2 sắp đến hạn",
                        Content = "Sản phẩm Pro2 còn 3 ngày nữa đến hạn (27/2/2024)",
                        Status = false
                    },
                    new NotificationContent {
                        Title = "Pro2 sắp đến hạn",
                        Content = "Sản phẩm Pro2 còn 4 ngày nữa đến hạn (27/2/2024)",
                        Status = false
                    },
                }
            };

            return View(data);
        }

        /// <summary>User operator branch id</summary>
        private string OperatorBranchId => _sessionManager.Get(Constants.SESSION_KEY_OPERATOR_BRANCH_ID);
        /// <summary>User operator id</summary>
        private string OperatorId => _sessionManager.Get(Constants.SESSION_KEY_OPERATOR_ID);
    }
}
