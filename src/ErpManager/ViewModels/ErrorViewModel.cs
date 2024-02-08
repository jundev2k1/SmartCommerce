// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.ViewModels
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}