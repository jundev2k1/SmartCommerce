// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Services
{
    public sealed class RoleService : ServiceBase, IRoleService
    {
        #region Constructor
        /// <summary>Context singleton</summary>
        private readonly IRoleRepository _roleRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        #endregion

        #region Queries
        /// <summary>
        /// Get all role
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns>A collection of role</returns>
        public RoleModel[] GetAllRole(string branchId)
        {
            return _roleRepository.GetAll(branchId);
        }

        /// <summary>
        /// Get role
        /// </summary>
        /// <param name="branchID"></param>
        /// <param name="roleId"></param>
        /// <returns>Role model</returns>
        public RoleModel? GetRole(string branchId, int roleId)
        {
            return _roleRepository.Get(branchId, roleId);
        }
        #endregion

        #region Command
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="model">Role model</param>
        /// <returns>Inser status</returns>
        public bool Insert(RoleModel model)
        {
            return _roleRepository.Insert(model);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model">Role model</param>
        /// <returns>Update status</returns>
        public bool Update(RoleModel model)
        {
            return _roleRepository.Update(model);
        }

        /// <summary>
        /// Delete temporary
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="roleId">Role id</param>
        /// <returns>Update status</returns>
        public bool TempDelete(string branchId, int roleId)
        {
            var role = _roleRepository.Get(branchId, roleId);
            if (role == null) return false;

            role.Status = RoleStatusEnum.Active;
            return true;
        }

        #endregion
    }
}
