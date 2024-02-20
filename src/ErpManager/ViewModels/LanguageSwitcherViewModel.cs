namespace ErpManager.ERP.ViewModels
{
    public class LanguageSwitcherViewModel
    {
        public string CurrentCulture { get; set; } = string.Empty;
        public CultureViewModel[] AvailableCultures { get; set; } = Array.Empty<CultureViewModel>();
    }

    public class CultureViewModel
    {
        public string Culture { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
    }
}
