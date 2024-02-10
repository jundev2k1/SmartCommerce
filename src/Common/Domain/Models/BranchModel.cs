// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Models;

public partial class BranchModel
{
    public string BranchId { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public BranchStatusEnum Status { get; set; }

    public string Avatar { get; set; } = string.Empty;

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastChanged { get; set; }
}