// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Models
{
    public sealed class NotificationModel : ModelBase<NotificationModel>
    {
        public string BranchId { get; set; } = string.Empty;

        public long Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public string Path { get; set; } = string.Empty;

        public NotificationTypeEnum Type { get; set; }

        public NotificationPriorityEnum Priority { get; set; }

        public NotificationStatusEnum Status { get; set; }

        public DateTime DateCreated { get; set; }

        public string CreatedBy { get; set; } = string.Empty;
    }
}
