// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewModels
{
	public sealed class NotificationViewModel
	{
		public bool IsDisplay { get; set; }

		public int NotificationUnReadCount { get; set; }

		public NotificationContent[] Items { get; set; } = Array.Empty<NotificationContent>();
	}

	public sealed class NotificationContent
	{
		public string Title { get; set; } = string.Empty;

		public string Content { get; set; } = string.Empty;

		public bool Status { get; set; }
	}
}
