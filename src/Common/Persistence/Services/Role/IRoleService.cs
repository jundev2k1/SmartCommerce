// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Services
{
    public interface IRoleService
    {
        /// <summary>
        /// Get all
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <returns>Role model list</returns>
        public RoleModel[] GetAllRole(string branchId);

        /// <summary>
        /// Get role
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="roleId">Role id</param>
        /// <returns>Role model</returns>
        public RoleModel? GetRole(string branchId, int roleId);

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="model">Role model</param>
        /// <returns>Insert status</returns>
        public bool Insert(RoleModel model);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model">Role model</param>
        /// <returns>Update status</returns>
        public bool Update(RoleModel model);

        /// <summary>
        /// Delete temporary
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="roleId">Role id</param>
        /// <returns>Delete status</returns>
        public bool TempDelete(string branchId, int roleId);


    }
}
