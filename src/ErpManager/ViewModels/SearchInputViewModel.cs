namespace ErpManager.ERP.ViewModels
{
    public class SearchInputViewModel
    {
        public string Name { get; set; } = string.Empty;

        public string Value { get; set; } = string.Empty;

        public string PlaceHolderText { get; set; } = string.Empty;

        public InputTypeEnum Type { get; set; } = InputTypeEnum.Text;

        public string ClassName { get; set; } = string.Empty;
    }
}
