// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Common
{
    public interface IServices
    {
        IBranchService Branches { get; }

        IRoleService Roles { get; }

        IUserService Users { get; }
    }
}
