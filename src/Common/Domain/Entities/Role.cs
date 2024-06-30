// Copyright (c) 2024 - Jun Dev. All rights reserved

#nullable disable
namespace ErpManager.Domain.Entities;

[Table("Role")]
public partial class Role
{
	[Key, Required]
	[StringLength(20)]
	public string BranchId { get; set; }

	[Key, Required]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int RoleId { get; set; }

	[Required]
	[StringLength(60)]
	public string Name { get; set; }

	[StringLength(4000)]
	public string Permission { get; set; }

	public int Priority { get; set; } = 0;

	[Column(TypeName = "datetime")]
	public DateTime DateCreated { get; set; }

	[Column(TypeName = "datetime")]
	public DateTime? DateChanged { get; set; }

	[StringLength(30)]
	public string CreatedBy { get; set; }

	public RoleStatusEnum Status { get; set; }
}
