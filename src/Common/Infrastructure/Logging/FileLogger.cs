// Copyright (c) 2024 - Jun Dev. All rights reserved

using Microsoft.Extensions.Logging;

namespace ErpManager.Infrastructure.Logging
{
    public sealed class FileLogger : IFileLogger
    {
        private readonly ILogger _logger;

        public FileLogger(ILogger<FileLogger> logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }

        public void LogError(string message)
        {
            _logger.LogError(message);
        }

        public void LogTrace(string message)
        {
            _logger.LogError(message);
        }
    }
}
