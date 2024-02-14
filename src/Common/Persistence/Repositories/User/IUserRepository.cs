// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Search
        /// </summary>
        /// <param name="expression">Expression</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>A tuple includes data, total page and total record</returns>
        public (UserModel[] Data, int TotalPage, int TotalRecord) Search(Expression<Func<User, bool>> expression, int pageIndex, int pageSize);

        /// <summary>
        /// Get all
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="isDeleted">Delete flag of user</param>
        /// <returns>User model list</returns>
        public UserModel[] GetAll(string branchId, bool isDeleted);

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="userId">User id</param>
        /// <returns>User model</returns>
        public UserModel? Get(string branchId, string userId);

        /// <summary>
        /// Get by user name
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="username">Username</param>
        /// <returns>User model</returns>
        public UserModel? GetByUserName(string branchId, string username);

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="model">User model</param>
        /// <returns>Insert status</returns>
        public bool Insert(UserModel model);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model">User model</param>
        /// <returns>Update status</returns>
        public bool Update(UserModel model);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="userId">User id</param>
        /// <returns>Delete status</returns>
        public bool Delete(string branchId, string userId);
    }
}
