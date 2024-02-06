// Copyright (c) 2024 - Jun Dev. All rights reserved

using Common.Constants;

namespace Domain.Models;

public class UserOperatorModel
{
    public string BranchId { get; set; } = Constants.CONFIG_DEFAULT_BRANCH_ID;

    public UserModel? Profile { get; set; }

    public RoleModel? Role { get; set; }
}