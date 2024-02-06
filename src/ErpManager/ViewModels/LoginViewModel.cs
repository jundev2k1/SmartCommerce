// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Web.ViewModels
{
    public class LoginViewModel
    {
        public string LoginID { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; } = false;
    }
}
