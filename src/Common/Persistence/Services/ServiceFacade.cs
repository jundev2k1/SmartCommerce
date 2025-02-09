// Copyright (c) 2024 - Jun Dev. All rights reserved

#nullable disable
namespace SmartCommerce.Persistence.Services
{
	public sealed class ServiceFacade : IServiceFacade
	{
		private IServiceProvider _serviceProvider;
		public ServiceFacade(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public IBranchService Branches => _serviceProvider.GetService<IBranchService>();

		public IRoleService Roles => _serviceProvider.GetService<IRoleService>();

		public IUserService Users => _serviceProvider.GetService<IUserService>();

		public ICategoryService Categories => _serviceProvider.GetService<ICategoryService>();

		public IProductService Products => _serviceProvider.GetService<IProductService>();

		public ITokenService Tokens => _serviceProvider.GetService<ITokenService>();

		public IMemberService Members => _serviceProvider.GetService<IMemberService>();

		public IMailTemplateService MailTemplates => _serviceProvider.GetService<IMailTemplateService>();

		public INotificationService Notifications => _serviceProvider.GetService<INotificationService>();
	}
}
