// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Repositories.Role
{
    public interface IRoleRepository
    {
        /// <summary>
        /// Search
        /// </summary>
        /// <param name="searchParams">Search parameters</param>
        /// <returns>Role model list</returns>
        public RoleModel[] Search(Dictionary<string, string> searchParams);

        /// <summary>
        /// Get all
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <returns>Role model list</returns>
        public RoleModel[] GetAll(string branchId);

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="branchID">Branch id</param>
        /// <param name="roleId">Role id</param>
        /// <returns>Role model</returns>
        public RoleModel? Get(string branchID, int roleId);

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
        /// Delete
        /// </summary>
        /// <param name="branchID">Branch id</param>
        /// <param name="roleID">Role id</param>
        /// <returns>Delete status</returns>
        public bool Delete(string branchID, int roleID);
    }
}
