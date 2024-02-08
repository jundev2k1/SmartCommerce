// Copyright (c) 2024 - Jun Dev. All rights reserved

#nullable disable
using Microsoft.Extensions.DependencyInjection;

namespace Persistence.Services
{
    public class ServiceList : IServices
    {
        private IServiceProvider _serviceProvider;
        public ServiceList(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IUserService Users => _serviceProvider.GetService<IUserService>();
    }
}
