// Copyright (c) 2024 - Jun Dev. All rights reserved

#nullable disable
namespace ErpManager.Domain.Entities;

[Table("Notification")]
public partial class Notification
{
    [Key, Required]
    [StringLength(20)]
    public string BranchId { get; set; }

    [Key, Required]
    public long Id { get; set; }

    [Key, Required]
    public string UserId { get; set; }

    [StringLength(255)]
    public string Title { get; set; } = string.Empty;

    [StringLength(4000)]
    public string Content { get; set; } = string.Empty;

    [StringLength(255)]
    public string Path { get; set; } = string.Empty;

    public NotificationTypeEnum Type { get; set; }

    public NotificationPriorityEnum Priority { get; set; }

    public NotificationStatusEnum Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DateCreated { get; set; }

    [StringLength(30)]
    public string CreatedBy { get; set; }
}
