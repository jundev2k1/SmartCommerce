// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Models;

public class UserOperatorModel
{
    public string BranchId { get; set; } = string.Empty;

    public UserModel? Profile { get; set; }

    public RoleModel? Role { get; set; }
}