using Domain.Models;

namespace Persistence.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Get all user
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <returns>A collection of users</returns>
        public UserModel?[] GetAllUser(string branchId);

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
        /// Get operator user
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="userId">User id</param>
        /// <returns>User model</returns>
        public UserModel? GetOperatorUser(string branchId, string userId);

        /// <summary>
        /// Try login
        /// </summary>
        /// <param name="branchId">Branch id</param>
        /// <param name="userName">User name</param>
        /// <param name="password">Password</param>
        /// <returns>User model</returns>
        public bool TryLogin(string branchId, string userName, string password);
    }
}
