namespace Domain.Enum
{
    public enum Permission
    {
        // Administrator permission
        HasAllPermission = 0,

        // System permission

        // User permission
        CanReadUser = 21,
        CanCreateUser = 22,
        CanEditUser = 23,
        CanDeleteUser = 24,
    }
}
