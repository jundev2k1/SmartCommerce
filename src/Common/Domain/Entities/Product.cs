// Copyright (c) 2024 - Jun Dev. All rights reserved

#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErpManager.Domain.Entities;

[Table("Product")]
public partial class Product
{
    [Key, Required]
    [StringLength(20)]
    public string BranchId { get; set; }

    [Key, Required]
    [StringLength(20)]
    public string ProductId { get; set; }

    [StringLength(60)]
    public string Name { get; set; }

    [StringLength(4000)]
    public string Images { get; set; } = string.Empty;

    [StringLength(60)]
    public string Address1 { get; set; } = string.Empty;

    [StringLength(60)]
    public string Address2 { get; set; } = string.Empty;

    [StringLength(60)]
    public string Address3 { get; set; } = string.Empty;

    [StringLength(60)]
    public string Address4 { get; set; } = string.Empty;

    public decimal Price1 { get; set; }

    public decimal Price2 { get; set; }

    public decimal Price3 { get; set; }

    public DisplayPriceEnum DisplayPrice { get; set;}

    public ProductStatusEnum Status { get; set; }

    public bool DelFlg { get; set; }

    public decimal Size1 { get; set; }

    public decimal Size2 { get; set; }

    public decimal Size3 { get; set; }

    [StringLength(30)]
    public string TakeOverId { get; set; } = string.Empty;

    [StringLength(4000)]
    public string Description { get; set; } = string.Empty;

    [StringLength(4000)]
    public string EmbeddedLink { get; set; } = string.Empty;

    [Column(TypeName = "datetime")]
    public DateTime? DateCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateChanged { get; set; }

    [StringLength(30)]
    public string CreatedBy { get; set; } = string.Empty;

    [StringLength(30)]
    public string LastChanged { get; set; } = string.Empty;
}
