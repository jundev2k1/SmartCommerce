namespace ErpManager.Web.ViewModels
{
    public class LoginViewModel
    {
        public string LoginID { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; } = false;
    }
}
