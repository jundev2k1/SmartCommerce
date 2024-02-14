// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Search
        /// </summary>
        /// <param name="searchParams">Search parameters</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>A tuple includes data, total page and total record</returns>
        public (UserModel[] Data, int TotalPage, int TotalRecord) Search(UserSearchDto searchParams, int pageIndex, int pageSize);

        /// <summary>
        /// Get all user
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="isDeleted">Delete flag of user</param>
        /// <returns>A collection of users</returns>
        public UserModel[] GetAllUser(string branchId, bool isDeleted = false);

        /// <summary>
        /// Get user
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="userId">User id</param>
        /// <returns>User model</returns>
        public UserModel? GetUser(string branchId, string userId);

        /// <summary>
        /// Get user
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="userName">Username (login id)</param>
        /// <returns>User model</returns>
        public UserModel? GetUserByUsername(string branchId, string userName);

        /// <summary>
        /// Try login
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="userName">User name</param>
        /// <param name="password">Password</param>
        /// <returns>Operator model</returns>
        public OperatorModel? TryLogin(string branchId, string userName, string password);

        /// <summary>
        /// Insert user
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
        /// Delete temporary
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="userId">User id</param>
        /// <remarks>Update delete flag to "true"</remarks>
        /// <returns>Delete status</returns>
        public bool TempDelete(string branchId, string userId);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="userId">User id</param>
        /// <returns>Delete status</returns>
        public bool Delete(string branchId, string userId);
    }
}
