// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Infrastructure.BackgroundServices
{
    internal class NotificationBackgroundService : BackgroundService
    {
        // DI
        private readonly IFileLogger _logger;
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationBackgroundService(IFileLogger logger, IHubContext<NotificationHub> hubContent)
        {
            _logger = logger;
            _hubContext = hubContent;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("NotificationBackgroundService is starting.");

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("NotificationBackgroundService is sending notification.");

                string message = "New notification message";

                await _hubContext.Clients.All.SendAsync(Constants.HUB_METHOD_NAME_USER_NOTIFICATION, message);

                await Task.Delay(TimeSpan.FromSeconds(15), stoppingToken);
            }

            _logger.LogInformation("NotificationBackgroundService is stopping.");
        }
    }
}
