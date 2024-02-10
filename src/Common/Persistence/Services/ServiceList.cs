// Copyright (c) 2024 - Jun Dev. All rights reserved

#nullable disable
namespace ErpManager.Persistence.Services
{
    public class ServiceList : IServices
    {
        private IServiceProvider _serviceProvider;
        public ServiceList(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IBranchService Branches => _serviceProvider.GetService<IBranchService>();

        public IRoleService Roles => _serviceProvider.GetService<IRoleService>();

        public IUserService Users => _serviceProvider.GetService<IUserService>();

    }
}
