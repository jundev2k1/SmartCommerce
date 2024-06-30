// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Infrastructure.Hubs
{
	public class NotificationHub : Hub
	{
		public async Task SendNotification(string message)
		{
			await Clients.All.SendAsync(Constants.HUB_METHOD_NAME_USER_NOTIFICATION, message);
		}
	}
}
