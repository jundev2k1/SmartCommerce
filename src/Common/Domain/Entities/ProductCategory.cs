// Copyright (c) 2025 - Jun Dev. All rights reserved

#nullable disable
namespace SmartCommerce.Domain.Entities;

[Table("ProductCategory")]
public partial class ProductCategory
{
	[Key, Required]
	[StringLength(20)]
	public string BranchId { get; set; }

	[Key, Required]
	[StringLength(256)]
	public string CategoryId { get; set; }

	[StringLength(256)]
	public string ParentId { get; set; }

	[StringLength(60)]
	public string Name { get; set; }

	[StringLength(256)]
	public string Avatar { get; set; } = string.Empty;

    [Column(TypeName = "nvarchar(max)")]
    public string Description { get; set; } = string.Empty;

    public int Priority { get; set; }

    public bool ValidFlg { get; set; }

	public bool DelFlg { get; set; }

	[Column(TypeName = "datetime")]
	public DateTime? DateCreated { get; set; }

	[Column(TypeName = "datetime")]
	public DateTime? DateChanged { get; set; }

	[StringLength(30)]
	public string CreatedBy { get; set; } = string.Empty;

	[StringLength(30)]
	public string LastChanged { get; set; } = string.Empty;
}
