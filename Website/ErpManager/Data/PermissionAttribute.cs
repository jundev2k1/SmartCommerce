using Domain.Enum;

namespace ErpManager.Web
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class PermissionAttribute : Attribute
    {
        public Permission Permission { get; }

        public PermissionAttribute(Permission permission)
        {
            Permission = permission;
        }
    }
}
