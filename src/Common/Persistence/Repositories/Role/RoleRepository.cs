// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Repositories.Role
{
    public class RoleRepository : RepositoryBase, IRoleRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">Context</param>
        public RoleRepository(DBContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="searchParams">Search parameters</param>
        /// <returns>A collection of user following search parameters</returns>
        public RoleModel[] Search(Dictionary<string, string> searchParams)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all role
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <returns>A collection of user</returns>
        public RoleModel[] GetAll(string branchId)
        {
            var result = _dbContext.Roles
                .Where(role =>
                    (role.BranchId == branchId)
                    && (role.Status == RoleStatusEnum.Active))
                .Select(role => role.MapToRoleModel())
                .ToArray();

            return result;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="roleId">Role id</param>
        /// <returns>User model</returns>
        public RoleModel? Get(string branchId, int roleId)
        {
            var result = _dbContext.Roles
                .FirstOrDefault(role =>
                    (role.BranchId == branchId)
                    && (role.RoleId == roleId));

            return result?.MapToRoleModel();
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="model">Role model</param>
        /// <returns>Status insert</returns>
        public bool Insert(RoleModel model)
        {
            var user = Get(model.BranchId, model.RoleId);
            if (user != null) return false;

            var result = BeginTransaction(() =>
            {
                var insertModel = model.MapToRoleEntity();
                _dbContext.Add(insertModel);
                _dbContext.SaveChanges();
            });
            return result;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model">Role model</param>
        /// <returns>Status update</returns>
        public bool Update(RoleModel model)
        {
            var role = Get(model.BranchId, model.RoleId);
            if (role == null) return false;

            model.DateCreated = role.DateCreated;

            var result = BeginTransaction(() =>
            {
                var updateModel = model.MapToRoleEntity();
                _dbContext.Update(updateModel);
                _dbContext.SaveChanges();
            });

            return result;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="branchID">Branch id</param>
        /// <param name="roleId">Role id</param>
        /// <returns>Delete status</returns>
        public bool Delete(string branchID, int roleId)
        {
            var role = Get(branchID, roleId);
            if (role == null) return false;

            var result = BeginTransaction(() =>
            {
                _dbContext.Remove(role);
                _dbContext.SaveChanges();
            });

            return result;
        }
    }
}
