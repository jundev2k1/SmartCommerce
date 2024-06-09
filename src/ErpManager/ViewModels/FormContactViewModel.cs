// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.ViewModels
{
    public sealed class FormContactViewModel
    {
        public string TargetButtonId { get; set; } = string.Empty;

        public FormContactTypeEnum TypeForm { get; set; }

        public bool IsShowType { get; set; }
    }
}
