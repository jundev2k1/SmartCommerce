// Copyright (c) 2024 - Jun Dev. All rights reserved

#nullable disable
using Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("User")]
public partial class User
{
    [Key, Required]
    [StringLength(20)]
    public string BranchID { get; set; }

    [Key, Required]
    [StringLength(30)]
    public string UserId { get; set; }

    [Key, Required]
    [StringLength(30)]
    public string UserName { get; set; } = string.Empty;

    [StringLength(30)]
    public string Password { get; set; } = string.Empty;

    [StringLength(255)]
    public string Avatar { get; set; } = string.Empty;

    [StringLength(30)]
    public string FirstName { get; set; } = string.Empty;

    [StringLength(30)]
    public string LastName { get; set; } = string.Empty;

    [StringLength(60)]
    public string Email { get; set; } = string.Empty;

    [StringLength(30)]
    public string PhoneNumber { get; set; } = string.Empty;

    [StringLength(255)]
    public string Address1 { get; set; } = string.Empty;

    [StringLength(255)]
    public string Address2 { get; set; } = string.Empty;

    [StringLength(255)]
    public string Address3 { get; set; } = string.Empty;

    [StringLength(255)]
    public string Address4 { get; set; } = string.Empty;

    public UserStatusEnum Status { get; set; }

    public SexEnum Sex { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Birthday { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DateCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DateChanged { get; set; }

    [StringLength(30)]
    public string CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastLogin { get; set; }

    [StringLength(30)]
    public string LastChanged { get; set; } = string.Empty;

    public int? RoleID { get; set; }
}