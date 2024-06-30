// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Infrastructure.Common.Attributes
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public sealed class PermissionAttribute : Attribute
	{
		public Permission[] Permissions { get; }

		public PermissionAttribute(params Permission[] permissions)
		{
			Permissions = permissions;
		}
	}
}
