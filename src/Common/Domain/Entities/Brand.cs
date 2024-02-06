// Copyright (c) 2024 - Jun Dev. All rights reserved

#nullable disable
using Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("Brand")]
public partial class Brand
{
    [Key, Required]
    [StringLength(20)]
    public string BranchID { get; set; }

    [Required]
    [StringLength(30)]
    public string Name { get; set; }

    public BrandStatusEnum Status { get; set; }

    [StringLength(255)]
    public string Avatar { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastChanged { get; set; }
}