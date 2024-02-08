// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Domain.Enum;

namespace ErpManager.Domain.Models;

public class UserModel
{
    public string BranchID { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Avatar { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Address1 { get; set; } = string.Empty;

    public string Address2 { get; set; } = string.Empty;

    public string Address3 { get; set; } = string.Empty;

    public string Address4 { get; set; } = string.Empty;

    public UserStatusEnum Status { get; set; }

    public bool DelFlg { get; set; }

    public SexEnum Sex { get; set; }

    public DateTime? Birthday { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateChanged { get; set; }

    public string CreatedBy { get; set; } = string.Empty;

    public DateTime? LastLogin { get; set; }

    public string LastChanged { get; set; } = string.Empty;

    public int? RoleID { get; set; }
}