// Copyright (c) 2024 - Jun Dev. All rights reserved

using Persistence.Services;

namespace Persistence.Common
{
    public interface IServices
    {
        IUserService Users { get; }
    }
}
