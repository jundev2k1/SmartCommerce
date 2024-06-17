// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Repositories
{
    public sealed class UserRepository : RepositoryBase, IUserRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">Context</param>
        public UserRepository(DBContext dbContext, IFileLogger logger) : base(dbContext, logger)
        {
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="expression">Expression</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Search result model</returns>
        public SearchResultModel<UserModel> Search(Expression<Func<User, bool>> expression, int pageIndex, int pageSize)
        {
            var query = _dbContext.Users
                .AsQueryable()
                .Where(expression);

            var queryCount = query.Count();
            var isSurplus = (queryCount % pageSize) > 0;
            var totalPage = queryCount / pageSize + (isSurplus ? 1 : 0);

            var pageSkip = (pageIndex - 1) * pageSize;
            var data = query
                .Skip(pageSkip)
                .Take(pageSize)
                .Select(user => user.MapToModel())
                .ToArray();

            var result = new SearchResultModel<UserModel>
            {
                Items = data,
                TotalPage = totalPage,
                TotalRecord = queryCount
            };
            return result;
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
                .Select(user => user.MapToModel())
                .ToArray();

            return result;
        }

        /// <summary>
        /// Gets
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="userIds">User id list</param>
        /// <returns>User model list</returns>
        public UserModel[] Gets(string branchId, string[] userIds)
        {
            var result = _dbContext.Users
                .Where(user => (user.BranchId == branchId) && userIds.Contains(user.UserId))
                .Select(user => user.MapToModel())
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
            var result = _dbContext.Users.FirstOrDefault(user =>
                (user.BranchId == branchId)
                && (user.UserId == userId));

            return result?.MapToModel();
        }

        /// <summary>
        /// Get by user name
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="username">User name</param>
        /// <returns>User model</returns>
        public UserModel? GetByUserName(string branchId, string username)
        {
            var result = _dbContext.Users.FirstOrDefault(user =>
                (user.BranchId == branchId)
                && (user.UserName == username)
                && (user.DelFlg == false));

            return result?.MapToModel();
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>Status insert</returns>
        public bool Insert(UserModel model)
        {
            var result = BeginTransaction(() =>
            {
                var user = _dbContext.Users.FirstOrDefault(item =>
                    (item.BranchId == model.BranchId)
                    && (item.UserId == model.UserId));
                if (user != null) throw new ExistInDBException();

                var insertModel = model.MapToEntity();
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
            var result = BeginTransaction(() =>
            {
                var user = _dbContext.Users.FirstOrDefault(item =>
                    (item.BranchId == model.BranchId)
                    && (item.UserId == model.UserId));
                if (user == null) throw new NotExistInDBException();

                var updateModel = model.MapToEntity();
                updateModel.DateChanged = DateTime.Now;
                _dbContext.Update(updateModel);
                _dbContext.SaveChanges();
            });
            return result;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="userId">User id</param>
        /// <param name="UpdateAction">Update action</param>
        /// <returns>Update status</returns>
        public bool Update(string branchId, string userId, Action<User> UpdateAction)
        {
            var result = BeginTransaction(() =>
            {
                var user = _dbContext.Users.FirstOrDefault(item =>
                    (item.BranchId == branchId)
                    && (item.UserId == userId));
                if (user == null) throw new NotExistInDBException();

                UpdateAction(user);
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
            var result = BeginTransaction(() =>
            {
                var user = _dbContext.Users.FirstOrDefault(item =>
                    (item.BranchId == branchId)
                    && (item.UserId == userId));
                if (user == null) throw new NotExistInDBException();

                _dbContext.Remove(user);
                _dbContext.SaveChanges();
            });
            return result;
        }
    }
}
