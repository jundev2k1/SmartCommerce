using Domain.Enum;

namespace ErpManager.Web.ViewModels.Component
{
    public class ButtonComponent
    {
        public ButtonType Type { get; set; }

        public string Content { get; set; } = string.Empty;

        public string Icon { get; set; } = string.Empty;

        public ButtonColor Color { get; set; } = ButtonColor.None;

        public string Href { get; set; } = string.Empty;

        public string Route { get; set; } = string.Empty;

        public string OnClick { get; set; } = string.Empty;

        public string ID { get; set; } = string.Empty;

        public string ClassName { get; set; } = string.Empty;

        public bool IsRounded { get; set; }
    }
}
