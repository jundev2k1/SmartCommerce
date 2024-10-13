// Copyright (c) 2024 - Jun Dev. All rights reserved

#nullable disable
namespace ErpManager.Domain.Entities;

[Table("Category")]
public partial class Category
{
	[Key, Required]
	[StringLength(20)]
	public string BranchId { get; set; }

	[Key, Required]
	[StringLength(20)]
	public string CategoryId { get; set; }

	[StringLength(60)]
	public string CategoryName { get; set; }

	[StringLength(255)]
	public string Avatar { get; set; } = string.Empty;

	[StringLength(4000)]
	public string Description { get; set; } = string.Empty;

	[StringLength(20)]
	public string ParentCategoryId { get; set; } = string.Empty;

	public int Priority { get; set; }

	public CategoryStatusEnum Status { get; set; }

	public bool DelFlg { get; set; }

	[Column(TypeName = "datetime")]
	public DateTime DateCreated { get; set; }

	[Column(TypeName = "datetime")]
	public DateTime? DateChanged { get; set; }

	[StringLength(30)]
	public string CreatedBy { get; set; } = string.Empty;

	[StringLength(30)]
	public string LastChanged { get; set; } = string.Empty;
}
