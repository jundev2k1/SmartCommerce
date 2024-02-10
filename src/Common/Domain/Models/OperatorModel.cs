// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Models;

public class OperatorModel
{
    public string BranchId { get; set; } = string.Empty;

    public UserModel Profile { get; set; } = new UserModel();

    public string Permission { get; set; } = string.Empty;
}