// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Repositories.User
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">Context</param>
        public UserRepository(DBContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="searchParams">Search parameters</param>
        /// <returns>A collection of user following search parameters</returns>
        public UserModel[] Search(Dictionary<string, string> searchParams)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all user
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="isDeleted">Delete flag of user</param>
        /// <returns>A collection of user</returns>
        public UserModel[] GetAll(string branchId, bool isDeleted)
        {
            var result = _dbContext.Users
                .Where(user =>
                    (user.BranchId == branchId)
                    && (user.DelFlg == isDeleted))
                .Select(user => user.MapToUserModel())
                .ToArray();

            return result;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="userId">User id</param>
        /// <returns>User model</returns>
        public UserModel? Get(string branchId, string userId)
        {
            var result = _dbContext.Users
                .FirstOrDefault(user => (user.BranchId == branchId) && (user.UserId == userId));

            return result?.MapToUserModel();
        }

        /// <summary>
        /// Get by user name
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="username">User name</param>
        /// <returns>User model</returns>
        public UserModel? GetByUserName(string branchId, string username)
        {
            var result = _dbContext.Users
                .FirstOrDefault(user =>
                    (user.BranchId == branchId)
                    && (user.UserName == username)
                    && (user.DelFlg == false));

            return result?.MapToUserModel();
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>Status insert</returns>
        public bool Insert(UserModel model)
        {
            var user = Get(model.BranchId, model.UserId);
            if (user != null) return false;

            var result = BeginTransaction(() =>
            {
                var insertModel = model.MapToUserEntity();
                _dbContext.Add(insertModel);
                _dbContext.SaveChanges();
            });
            return result;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>Status update</returns>
        public bool Update(UserModel model)
        {
            var user = Get(model.BranchId, model.UserId);
            if (user == null) return false;

            // Reset date created
            model.DateCreated = user.DateCreated;

            var result = BeginTransaction(() =>
            {
                var updateModel = model.MapToUserEntity();
                _dbContext.Update(updateModel);
                _dbContext.SaveChanges();
            });
            return result;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="userId">User id</param>
        /// <returns>Delete status</returns>
        public bool Delete(string branchId, string userId)
        {
            var user = Get(branchId, userId);
            if (user == null) return false;

            var result = BeginTransaction(() =>
            {
                _dbContext.Remove(user);
                _dbContext.SaveChanges();
            });
            return result;
        }
    }
}
