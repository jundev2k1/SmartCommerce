// Copyright (c) 2024 - Jun Dev. All rights reserved

#nullable disable
namespace ErpManager.Domain.Entities;

[Table("Token")]
public partial class Token
{
	[Key, Required]
	[StringLength(20)]
	public string BranchId { get; set; }

	[Key, Required]
	[StringLength(4000)]
	public string TokenId { get; set; }

	public TokenTypeEnum Type { get; set; }

	[Column(TypeName = "datetime")]
	public DateTime ExpirationDate { get; set; }

	[Column(TypeName = "datetime")]
	public DateTime DateCreated { get; set; }

	[Column(TypeName = "datetime")]
	public DateTime? DateChanged { get; set; }

	[StringLength(30)]
	public string CreatedBy { get; set; }
}
