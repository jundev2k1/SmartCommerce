// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Infrastructure.Interface
{
    public interface IFileLogger
    {
        public void LogInformation(string message);

        public void LogWarning(string message);

        public void LogError(string message);

        public void LogTrace(string message);
    }
}
