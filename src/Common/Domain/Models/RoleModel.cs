// Copyright (c) 2024 - Jun Dev. All rights reserved

using Domain.Enum;

namespace Domain.Models;

public class RoleModel
{
    public string BranchID { get; set; } = string.Empty;

    public int RoleID { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Permission { get; set; } = string.Empty;

    public int Priority { get; set; } = 0;

    public DateTime DateCreated { get; set; }

    public DateTime DateChanged { get; set; }

    public string CreatedBy { get; set; } = string.Empty;

    public RoleStatusEnum Status { get; set; }
}