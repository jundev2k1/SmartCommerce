// Copyright (c) 2024 - Jun Dev. All rights reserved

#nullable disable
namespace ErpManager.Domain.Entities;

[Table("MailTemplate")]
public partial class MailTemplate
{
	[Key, Required]
	[StringLength(20)]
	public string BranchId { get; set; }

	[Key, Required]
	[StringLength(10)]
	public string MailId { get; set; }

	[Key, Required]
	[StringLength(255)]
	public string Subject { get; set; } = string.Empty;

	[StringLength(4000)]
	public string Body { get; set; } = string.Empty;

	[StringLength(60)]
	public string From { get; set; } = string.Empty;

	[StringLength(60)]
	public string To { get; set; } = string.Empty;

	[StringLength(60)]
	public string Cc { get; set; } = string.Empty;

	[StringLength(60)]
	public string Bcc { get; set; } = string.Empty;

	public MailTemplateStatusEnum Status { get; set; }

	[Column(TypeName = "datetime")]
	public DateTime DateCreated { get; set; }

	[Column(TypeName = "datetime")]
	public DateTime DateChanged { get; set; }
}
