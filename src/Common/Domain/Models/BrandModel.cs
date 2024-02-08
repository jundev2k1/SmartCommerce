// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Domain.Enum;

namespace ErpManager.Domain.Models;

public partial class BrandModel
{
    public string BranchID { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public BrandStatusEnum Status { get; set; }

    public string Avatar { get; set; } = string.Empty;

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastChanged { get; set; }
}