// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.ViewComponents
{
    public class UserNotificationViewComponent : ViewComponent
    {
        private readonly IServiceFacade _serviceFacade;
        public UserNotificationViewComponent(IServiceFacade serviceFacade)
        {
            _serviceFacade = serviceFacade;
        }

        public IViewComponentResult Invoke()
        {
            var data = new NotificationViewModel
            {
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
        protected string OperatorBranchId => HttpContext.Session.GetString(Constants.SESSION_KEY_OPERATOR_BRANCH_ID).ToStringOrEmpty();
        /// <summary>User operator id</summary>
        protected string OperatorId => HttpContext.Session.GetString(Constants.SESSION_KEY_OPERATOR_ID).ToStringOrEmpty();
    }
}
