// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class PermissionAttribute : Attribute
    {
        public Permission Permission { get; }

        public PermissionAttribute(Permission permission)
        {
            Permission = permission;
        }
    }
}
