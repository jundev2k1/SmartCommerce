#nullable disable
using Microsoft.Extensions.DependencyInjection;
using Persistence.Common;

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
