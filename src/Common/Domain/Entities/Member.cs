// Copyright (c) 2024 - Jun Dev. All rights reserved

#nullable disable
namespace ErpManager.Domain.Entities;

[Table("Member")]
public partial class Member
{
	[Key, Required]
	[StringLength(20)]
	public string BranchId { get; set; }

	[Key, Required]
	[StringLength(30)]
	public string MemberId { get; set; }

	[StringLength(30)]
	public string FirstName { get; set; } = string.Empty;

	[StringLength(30)]
	public string LastName { get; set; } = string.Empty;

	[StringLength(255)]
	public string Avatar { get; set; } = string.Empty;

	[StringLength(60)]
	public string Email { get; set; } = string.Empty;

	[StringLength(60)]
	public string CardNumber { get; set; } = string.Empty;

	[StringLength(30)]
	public string PhoneNumber { get; set; } = string.Empty;

	[StringLength(30)]
	public string BackupPhoneNumber { get; set; } = string.Empty;

	[StringLength(30)]
	public string Address1 { get; set; } = string.Empty;

	[StringLength(30)]
	public string Address2 { get; set; } = string.Empty;

	[StringLength(30)]
	public string Address3 { get; set; } = string.Empty;

	[StringLength(255)]
	public string Address4 { get; set; } = string.Empty;

	[StringLength(30)]
	public string SubAddress1 { get; set; } = string.Empty;

	[StringLength(30)]
	public string SubAddress2 { get; set; } = string.Empty;

	[StringLength(30)]
	public string SubAddress3 { get; set; } = string.Empty;

	[StringLength(255)]
	public string SubAddress4 { get; set; } = string.Empty;

	[StringLength(255)]
	public string BackupAddress { get; set; } = string.Empty;

	public MemberStatusEnum Status { get; set; }

	public bool DelFlg { get; set; }

	public MemberSexEnum Sex { get; set; }

	[Column(TypeName = "datetime")]
	public DateTime Birthday { get; set; }

	[StringLength(255)]
	public string Note { get; set; }

	[Column(TypeName = "datetime")]
	public DateTime DateCreated { get; set; }

	[Column(TypeName = "datetime")]
	public DateTime? DateChanged { get; set; }

	[StringLength(30)]
	public string CreatedBy { get; set; }

	[StringLength(30)]
	public string LastChanged { get; set; } = string.Empty;
}
