// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Mapping
{
    public static class RoleMapping
    {
        /// <summary>
        /// Map to role model
        /// </summary>
        /// <param name="roleEntity">Role entity</param>
        /// <returns>Role model</returns>
        public static RoleModel MapToRoleModel(this Role roleEntity)
        {
            var model = new RoleModel
            {
                BranchId = roleEntity.BranchId,
                RoleId = roleEntity.RoleId,
                Name = roleEntity.Name,
                Permission = roleEntity.Permission,
                Priority = roleEntity.Priority,
                Status = roleEntity.Status,
                DateCreated = roleEntity.DateCreated,
                DateChanged = roleEntity.DateChanged,
                CreatedBy = roleEntity.CreatedBy,
            };

            return model;
        }

        /// <summary>
        /// Map to role entity
        /// </summary>
        /// <param name="roleModel">Role model</param>
        /// <returns>Role entity</returns>
        public static Role MapToRoleEntity(this RoleModel roleModel)
        {
            var entity = new Role
            {
                BranchId = roleModel.BranchId,
                RoleId = roleModel.RoleId,
                Name = roleModel.Name,
                Permission = roleModel.Permission,
                Priority = roleModel.Priority,
                Status = roleModel.Status,
                DateCreated = roleModel.DateCreated,
                DateChanged = roleModel.DateChanged,
                CreatedBy = roleModel.CreatedBy,
            };

            return entity;
        }
    }
}
