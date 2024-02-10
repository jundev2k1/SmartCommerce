// Copyright (c) 2024 - Jun Dev. All rights reserved

#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErpManager.Domain.Entities;

[Table("Branch")]
public partial class Branch
{
    [Key, Required]
    [StringLength(20)]
    public string BranchId { get; set; }

    [Required]
    [StringLength(30)]
    public string Name { get; set; }

    public BranchStatusEnum Status { get; set; }

    [StringLength(255)]
    public string Avatar { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastChanged { get; set; }
}